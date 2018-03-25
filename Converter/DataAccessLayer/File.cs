using Converter.DataAccessLayer.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace Converter.DataAccessLayer.Structures
{
    [Serializable]
    public class File : IFile
    {
        public double Size { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }    
        public ObservableCollection<TradeRecord> tradeRecord = new ObservableCollection<TradeRecord>();
        private bool IsOpenFile { get; set; }
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
        public ObservableCollection<TradeRecord> Load()
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
                Name = openFileDialog.SafeFileName;
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
                tradeRecord = Unboxing(tree) as ObservableCollection<TradeRecord>;
            }
            return tradeRecord;
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
        public void OnFileOpenOK(Object sender, CancelEventArgs e)
        {
            IsOpenFile = true;
        }
    }
}