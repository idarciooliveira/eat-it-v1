using System.IO;
using Microsoft.Win32;

namespace ProdutoModule.Models
{
    public class ByteExtension
    {
        private static byte[] ConvertStringPathToByteArray(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath)) return null;
            return File.ReadAllBytes(imagePath);
        }
        private static string ChooseImagePath()
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() != true) return null;
            return fileDialog.FileName;
        }
        public static byte[] LoadImagem()
        {
            return ConvertStringPathToByteArray(ChooseImagePath());
        }
    }
}
