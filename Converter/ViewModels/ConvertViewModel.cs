using Converter.DataAccessLayer;
using Converter.BusinessLogicLayer.Structures;
using Converter.Models;
using Converter.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Converter.ViewModels
{
    public class ConvertViewModel : ObservableObject
    {
        #region vars
        private IConvertFactory _fromBinToCSV = new ConvertFactory();
        private RelayCommand _convertCommand;
        private RelayCommand _openCommand;
        private ItemsModel items = new ItemsModel();
        private ObservableCollection<ItemsModel> _listOfTrade = new ObservableCollection<ItemsModel>();
        private FileType _filyTypeFrom;
        private FileType _filyTypeTo;
        private string _progress;
        private DataAccessLayer.Structures.File _file = new DataAccessLayer.Structures.File();
        private string _fileName {get; set;}
        #endregion
        #region Properties
        public FileType FilyTypePropertyFrom
        {
            get { return _filyTypeFrom; }
            set
            {
                _filyTypeFrom = value;
                RaisePropertyChanged(nameof(_filyTypeFrom));
            }
        }
        public FileType FilyTypePropertyTo
        {
            get { return _filyTypeTo; }
            set
            {
                _filyTypeTo = value;
                RaisePropertyChanged(nameof(_filyTypeTo));
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
        public string Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                RaisePropertyChanged(nameof(Progress));
            }
        }
        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand = _openCommand ??
                  new RelayCommand(DownloadFile);
            }
        }
        public RelayCommand ConvertCommand
        {
            get
            {
                return _convertCommand = _convertCommand ??
                  new RelayCommand(Converter);
            }
        }
        #endregion
        private void DownloadFile()
        {
            _fileName = _file.Load();
            AddingInformationToDataGrid();
        }
        private void Converter()
        { 
            var convertType = FileType.BinaryToCsv;
            _fromBinToCSV.GetConverter(convertType).ToConvert(_fileName);
        }
        private void AddingInformationToDataGrid()
        {
            int i = 0;
            string[] t = _fileName.Split('\n');
            items.Id = t[i];
            items.Account = t[i + 1];
            items.Volume = t[i + 2];
            items.Comment = t[i + 3];
            ListOfTrade.Add(items);
        }
    }
}