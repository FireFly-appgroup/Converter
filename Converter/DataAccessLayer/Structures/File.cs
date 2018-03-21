using Converter.DataAccessLayer.Interfaces;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Converter.DataAccessLayer.Structures
{
    public class File : IFile
    {
        public double Size { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<string> tradeRecord = new List<string>();
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
        public string Load()
        {
            string BinaryFile = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary File (*.bin)|*.bin";
            if (openFileDialog.ShowDialog() == true)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                StreamReader reader = new StreamReader(fileInfo.Open(FileMode.Open, FileAccess.Read), Encoding.GetEncoding(1251));
                BinaryFile = reader.ReadToEnd();
                Name = fileInfo.Name;
                Path = fileInfo.DirectoryName;
                Size = fileInfo.Length;
                tradeRecord.Add(BinaryFile);
                reader.Close();
            }
            return BinaryFile;
        }
    }
}