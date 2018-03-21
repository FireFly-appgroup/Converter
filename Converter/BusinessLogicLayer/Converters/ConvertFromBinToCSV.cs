using Converter.BusinessLogicLayer.Interfaces;
using Converter.DataAccessLayer;
using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;

namespace Converter.BusinessLogicLayer.Structures
{
    public class ConvertFromBinToCSV : IConverter
    {
       public void ToConvert(List<TradeRecord> FileForConvert)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "File (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.OpenFile(), System.Text.Encoding.Default))
                {
                    foreach (var item in FileForConvert)
                    sw.WriteLine(item.id + "\n" + item.account + "\n" + item.volume + "\n" + item.comment + "\n");
                    sw.Close();
                }
            }
        }
    }
}
