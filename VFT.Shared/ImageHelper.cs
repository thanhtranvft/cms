using System.Drawing;
using System.Drawing.Imaging;

namespace VFT.Shared
{
    public static class ImageHelper
    {
        public static string ParseToString(Stream data)
        {
            Image image = Image.FromStream(data, true, true);
            // Compute thumbnail size.
            Size thumbnailSize = GetThumbnailSizeCat(image);
            Image thumbnail = image.GetThumbnailImage(thumbnailSize.Width, thumbnailSize.Height, null, IntPtr.Zero);
            MemoryStream memoryStream = new MemoryStream();
            thumbnail.Save(memoryStream, ImageFormat.Png);
            Byte[] bytes = new Byte[memoryStream.Length];
            memoryStream.Position = 0;
            memoryStream.Read(bytes, 0, (int)bytes.Length);

            return Convert.ToBase64String(bytes, 0, bytes.Length);
        }

        public static string ParseToString(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    Image image = Image.FromFile(path);

                    // Compute thumbnail size.
                    Size thumbnailSize = GetThumbnailSizeCat(image);
                    Image thumbnail = image.GetThumbnailImage(thumbnailSize.Width, thumbnailSize.Height, null, IntPtr.Zero);
                    MemoryStream memoryStream = new MemoryStream();
                    thumbnail.Save(memoryStream, ImageFormat.Png);
                    Byte[] bytes = new Byte[memoryStream.Length];
                    memoryStream.Position = 0;
                    memoryStream.Read(bytes, 0, (int)bytes.Length);

                    return Convert.ToBase64String(bytes, 0, bytes.Length);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Size GetThumbnailSizeCat(Image original)
        {
            // Maximum size of any dimension.
            const int maxPixels = 480;

            // Width and height.
            int originalWidth = original.Width;
            int originalHeight = original.Height;

            // Compute best factor to scale entire image based on larger dimension.
            double factor;
            if (originalWidth > originalHeight)
            {
                factor = (double)maxPixels / originalWidth;
            }
            else
            {
                factor = (double)maxPixels / originalHeight;
            }

            // Return thumbnail size.
            return new Size((int)(originalWidth * factor), (int)(originalHeight * factor));
        }
    }
}