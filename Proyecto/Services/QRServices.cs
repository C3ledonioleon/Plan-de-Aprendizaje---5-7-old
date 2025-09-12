using QRCoder;

namespace Proyecto.Services
{
    public class QRService
    {
        public byte[] GenerarQR(string contenido)
        {
            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode(contenido, QRCodeGenerator.ECCLevel.Q);
                var pngQrCode = new PngByteQRCode(qrCodeData);
                return pngQrCode.GetGraphic(20); // devuelve byte[] directamente
            }
        }
    }
}