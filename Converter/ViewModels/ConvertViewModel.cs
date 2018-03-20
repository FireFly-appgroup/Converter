using Converter.DataAccessLayer;
using Converter.Models;
using Converter.Utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Converter.ViewModels
{
    public class ConvertViewModel : ObservableObject
    {
        private string _HeadText;
        private RelayCommand _convertCommand;
        private RelayCommand _openCommand;
        private ItemsModel items = new ItemsModel();
        private ObservableCollection<ItemsModel> _listOfTrade = new ObservableCollection<ItemsModel>();
        private FileType _filyType;
        public ConvertViewModel()
        {
            HeadText = "Converter";
        }
        public FileType FilyTypeProperty
        {
            get { return _filyType; }
            set
            {
                _filyType = value;
                RaisePropertyChanged(nameof(_filyType));
            }
        }
        public IEnumerable<FileType> MyEnumTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(FileType))
                    .Cast<FileType>();
            }
        }
        public ObservableCollection<ItemsModel> ListOfTrade
        {
            get { return _listOfTrade; }
            set
            {
                _listOfTrade = value;
                RaisePropertyChanged(nameof(ListOfTrade));
            }
        }
        public string HeadText
        {
            get { return _HeadText; }
            set
            {
                _HeadText = value;
                RaisePropertyChanged(nameof(HeadText));
            }
        }
        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand = _openCommand ??
                  new RelayCommand(ToOpen);
            }
        }
        public RelayCommand ConvertCommand
        {
            get
            {
                return _convertCommand = _convertCommand ??
                  new RelayCommand(ToConvert);
            }
        }
        private void ToOpen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary File (*.bin)|*.bin";
            if (openFileDialog.ShowDialog() == true)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                StreamReader reader = new StreamReader(fileInfo.Open(FileMode.Open, FileAccess.Read), Encoding.GetEncoding(1251));
                int i = 0;
                string line = reader.ReadToEnd();
                string[] t = line.Split('\n');
                items.Id = t[i];
                items.Account = t[i + 1];
                items.Volume = t[i + 2];
                items.Comment = t[i + 3];
                ListOfTrade.Add(items);
                reader.Close();
            }
        }
        private void ToConvert()
        {

        }
    }
}