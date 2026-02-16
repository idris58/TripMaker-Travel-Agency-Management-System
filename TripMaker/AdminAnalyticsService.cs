using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace TripMaker
{
    internal class AdminAnalyticsSnapshot
    {
        public int TotalBookings { get; set; }
        public decimal TotalRevenue { get; set; }
        public DataTable ByType { get; set; }
        public DataTable DailyTrend { get; set; }
        public DataTable TopRoutes { get; set; }
        public DataTable TopHotels { get; set; }
        public DataTable TopActivities { get; set; }
    }

    internal static class AdminAnalyticsService
    {
        public static AdminAnalyticsSnapshot Load(DateTime fromDate, DateTime toDate, out string error)
        {
            error = string.Empty;
            var snapshot = new AdminAnalyticsSnapshot();

            DateTime from = fromDate.Date;
            DateTime toExclusive = toDate.Date.AddDays(1);

            string totalBookingsQuery = @"
                SELECT COUNT(*) AS Total_Bookings
                FROM Booking_Info b
                WHERE b.Booking_Date >= :fromDate
                  AND b.Booking_Date < :toDateExclusive";

            string totalRevenueQuery = @"
                SELECT NVL(SUM(
                    CASE
                        WHEN b.Booking_Type IN ('Bus','Flight','Train') THEN NVL(ti.Ticket_Price, 0)
                        WHEN b.Booking_Type = 'Hotel' THEN NVL(r.Price, 0)
                        WHEN b.Booking_Type = 'Activity' THEN NVL(a.Price, 0)
                        ELSE 0
                    END
                ), 0) AS Total_Revenue
                FROM Booking_Info b
                LEFT JOIN Ticket ti ON b.Ticket_Number = ti.Ticket_Number
                LEFT JOIN Room_Booking rb ON b.Room_Booking_Id = rb.Room_Booking_Id
                LEFT JOIN Room r ON rb.Room_Id = r.Room_Id
                LEFT JOIN Activity_Booking ab ON b.Act_Booking_Id = ab.Act_Booking_Id
                LEFT JOIN Activity a ON ab.Activity_Id = a.Activity_Id
                WHERE b.Booking_Date >= :fromDate
                  AND b.Booking_Date < :toDateExclusive";

            string byTypeQuery = @"
                SELECT b.Booking_Type,
                       COUNT(*) AS Booking_Count,
                       NVL(SUM(
                           CASE
                               WHEN b.Booking_Type IN ('Bus','Flight','Train') THEN NVL(ti.Ticket_Price, 0)
                               WHEN b.Booking_Type = 'Hotel' THEN NVL(r.Price, 0)
                               WHEN b.Booking_Type = 'Activity' THEN NVL(a.Price, 0)
                               ELSE 0
                           END
                       ), 0) AS Revenue
                FROM Booking_Info b
                LEFT JOIN Ticket ti ON b.Ticket_Number = ti.Ticket_Number
                LEFT JOIN Room_Booking rb ON b.Room_Booking_Id = rb.Room_Booking_Id
                LEFT JOIN Room r ON rb.Room_Id = r.Room_Id
                LEFT JOIN Activity_Booking ab ON b.Act_Booking_Id = ab.Act_Booking_Id
                LEFT JOIN Activity a ON ab.Activity_Id = a.Activity_Id
                WHERE b.Booking_Date >= :fromDate
                  AND b.Booking_Date < :toDateExclusive
                GROUP BY b.Booking_Type
                ORDER BY Booking_Count DESC";

            string dailyTrendQuery = @"
                SELECT TRUNC(b.Booking_Date) AS Booking_Day,
                       COUNT(*) AS Booking_Count
                FROM Booking_Info b
                WHERE b.Booking_Date >= :fromDate
                  AND b.Booking_Date < :toDateExclusive
                GROUP BY TRUNC(b.Booking_Date)
                ORDER BY Booking_Day";

            string topRoutesQuery = @"
                SELECT *
                FROM (
                    SELECT t.From_Location || ' -> ' || t.To_Location AS Route,
                           COUNT(*) AS Booking_Count
                    FROM Booking_Info b
                    JOIN Ticket ti ON b.Ticket_Number = ti.Ticket_Number
                    JOIN Transport t ON ti.Transport_Id = t.Transport_Id
                    WHERE b.Booking_Date >= :fromDate
                      AND b.Booking_Date < :toDateExclusive
                    GROUP BY t.From_Location, t.To_Location
                    ORDER BY COUNT(*) DESC
                )
                WHERE ROWNUM <= 5";

            string topHotelsQuery = @"
                SELECT *
                FROM (
                    SELECT h.Hotel_Name,
                           COUNT(*) AS Booking_Count
                    FROM Booking_Info b
                    JOIN Room_Booking rb ON b.Room_Booking_Id = rb.Room_Booking_Id
                    JOIN Room r ON rb.Room_Id = r.Room_Id
                    JOIN Hotel h ON r.Hotel_Id = h.Hotel_Id
                    WHERE b.Booking_Date >= :fromDate
                      AND b.Booking_Date < :toDateExclusive
                    GROUP BY h.Hotel_Name
                    ORDER BY COUNT(*) DESC
                )
                WHERE ROWNUM <= 5";

            string topActivitiesQuery = @"
                SELECT *
                FROM (
                    SELECT a.Activity_Name,
                           COUNT(*) AS Booking_Count
                    FROM Booking_Info b
                    JOIN Activity_Booking ab ON b.Act_Booking_Id = ab.Act_Booking_Id
                    JOIN Activity a ON ab.Activity_Id = a.Activity_Id
                    WHERE b.Booking_Date >= :fromDate
                      AND b.Booking_Date < :toDateExclusive
                    GROUP BY a.Activity_Name
                    ORDER BY COUNT(*) DESC
                )
                WHERE ROWNUM <= 5";

            object totalBookingsObj = DataAccess.GetSingleValueParameterized(
                totalBookingsQuery,
                BuildDateParams(from, toExclusive),
                out error);
            if (!string.IsNullOrEmpty(error)) return null;

            object totalRevenueObj = DataAccess.GetSingleValueParameterized(
                totalRevenueQuery,
                BuildDateParams(from, toExclusive),
                out error);
            if (!string.IsNullOrEmpty(error)) return null;

            snapshot.TotalBookings = Convert.ToInt32(totalBookingsObj ?? 0);
            snapshot.TotalRevenue = Convert.ToDecimal(totalRevenueObj ?? 0m);

            snapshot.ByType = DataAccess.GetData(byTypeQuery, BuildDateParams(from, toExclusive), out error);
            if (!string.IsNullOrEmpty(error)) return null;

            snapshot.DailyTrend = DataAccess.GetData(dailyTrendQuery, BuildDateParams(from, toExclusive), out error);
            if (!string.IsNullOrEmpty(error)) return null;

            snapshot.TopRoutes = DataAccess.GetData(topRoutesQuery, BuildDateParams(from, toExclusive), out error);
            if (!string.IsNullOrEmpty(error)) return null;

            snapshot.TopHotels = DataAccess.GetData(topHotelsQuery, BuildDateParams(from, toExclusive), out error);
            if (!string.IsNullOrEmpty(error)) return null;

            snapshot.TopActivities = DataAccess.GetData(topActivitiesQuery, BuildDateParams(from, toExclusive), out error);
            if (!string.IsNullOrEmpty(error)) return null;

            return snapshot;
        }

        private static OracleParameter[] BuildDateParams(DateTime fromDate, DateTime toDateExclusive)
        {
            return new[]
            {
                new OracleParameter("fromDate", OracleDbType.Date) { Value = fromDate },
                new OracleParameter("toDateExclusive", OracleDbType.Date) { Value = toDateExclusive }
            };
        }
    }
}
