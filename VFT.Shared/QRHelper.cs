using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFT.Shared
{
    public static class QRHelper
    {
        public static string CreateQRImagePng(string url)
        {
            string result = null;

            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);

                result = Convert.ToBase64String(qrCodeAsPngByteArr);
            }
            catch (Exception ex)
            {
                //LogManager.LogException(ex);
            }

            return result;
        }
    }
}
