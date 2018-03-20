using Converter.BusinessLogicLayer.Interfaces;
using Converter.DataAccessLayer;
using Microsoft.Win32;
using System.IO;

namespace Converter.BusinessLogicLayer.Structures
{
    public class ConvertFromBinToCSV : IConverter
    {
       public void ToConvert(FileType From, FileType To, string FileForConvert)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "File (*"+ To +")|*" + To;
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.WriteLine(FileForConvert);
                    sw.Close();
                }
            }
        }
    }
}
