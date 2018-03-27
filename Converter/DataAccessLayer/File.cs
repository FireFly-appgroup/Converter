using Converter.BusinessLogicLayer;
using Converter.BusinessLogicLayer.Interfaces;
using Converter.DataAccessLayer.Interfaces;
using Converter.UserInterface.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Converter.DataAccessLayer.Structures
{
    [Serializable]
    public class File : IFile
    {
        private IConvertFactory _fromBinToCSV = new ConvertFactory();
        public double Size { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public ObservableCollection<TradeRecord> TradeRecord = new ObservableCollection<TradeRecord>();
        private bool IsOpenFile { get; set; }
        private FilesModel files = new FilesModel();
        public void Save<T>(T trade)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary File (*.bin)|*.bin";
            if (saveFileDialog.ShowDialog() == true)
            {
                BinaryWriter write = new BinaryWriter(new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate));
                byte[] buffer = Boxing(trade as object);
                write.Write(buffer, 0, buffer.Length);
                write.Close();
            }
        }
        public FilesModel Load()
        {
            string BinaryFile = string.Empty;
            Name = String.Empty; Path = String.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary File (*.bin)|*.bin";
            openFileDialog.Title = "Convert Browser";
            openFileDialog.FileOk += new CancelEventHandler(OnFileOpenOK);
            if (openFileDialog.ShowDialog() == true && IsOpenFile == true)
            {
                BinaryReader read = new BinaryReader(new FileStream(openFileDialog.FileName, FileMode.Open));
                files.Name = openFileDialog.SafeFileName;
                files.Progress = "Not Completed";
                Path = openFileDialog.FileName;
                Size = read.BaseStream.Length;
                int k = 0;
                byte[] tree = new byte[1];
                while (read.BaseStream.Position != read.BaseStream.Length)
                {
                    Array.Resize(ref tree, tree.Length + 1);
                    tree[k++] = read.ReadByte();
                }
                read.Close();
                TradeRecord = Unboxing(tree) as ObservableCollection<TradeRecord>;
            }
            return files;
        }
        private byte[] Boxing(object item)
        {
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, item);
                return ms.ToArray();
            }
        }
        private object Unboxing(byte[] item)
        {
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                ms.Write(item, 0, item.Length);
                ms.Position = 0;
                return bf.Deserialize(ms) as object;
            }
        }
        public bool TaskCompleted()
        {
            return _fromBinToCSV.GetConverter(FileType.BinaryToCsv).ToConvert(TradeRecord);
        }
        public void OnFileOpenOK(Object sender, CancelEventArgs e)
        {
            IsOpenFile = true;
        }
    }
}