using Converter.DataAccessLayer.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
        public void Save(TradeRecord trade)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Binary File (*.bin)|*.bin";

            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.WriteLine(trade);
                    sw.Close();
                }
            } 
        }
    }
}
