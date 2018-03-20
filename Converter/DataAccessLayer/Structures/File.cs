using Converter.DataAccessLayer.Interfaces;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;

namespace Converter.DataAccessLayer.Structures
{
    public class File : IFile
    {
        public double Size { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<TradeRecord> tradeRecord = new List<TradeRecord>();

        public void ToBinary()
        {

        }
        public void Save(List<TradeRecord> trade)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Binary File (*.bin)|*.bin";

            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.OpenFile(), System.Text.Encoding.Default))
                {
                    foreach (var item in trade)
                    sw.WriteLine(item.id + "\n" + item.account + "\n" + item.volume + "\n" + item.comment);
                    sw.Close();
                }
            } 
        }
    }
}
