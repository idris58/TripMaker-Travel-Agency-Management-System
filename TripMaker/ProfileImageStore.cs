using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace TripMaker
{
    internal static class ProfileImageStore
    {
        private static readonly string BaseDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "TripMaker",
            "ProfileImages");

        private static string GetPath(string username)
        {
            string safe = (username ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(safe))
            {
                return null;
            }
            return Path.Combine(BaseDir, safe + ".jpg");
        }

        public static void Save(string username, Image image)
        {
            if (image == null) return;
            string path = GetPath(username);
            if (string.IsNullOrEmpty(path)) return;

            Directory.CreateDirectory(BaseDir);
            image.Save(path, ImageFormat.Jpeg);
        }

        public static Image Load(string username)
        {
            string path = GetPath(username);
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                return null;
            }

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var img = Image.FromStream(fs))
            {
                return new Bitmap(img);
            }
        }
    }
}
