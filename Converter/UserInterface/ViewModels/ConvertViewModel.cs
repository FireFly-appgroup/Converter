using Converter.DataAccessLayer;
using Converter.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Converter.BusinessLogicLayer.Interfaces;
using Converter.BusinessLogicLayer;
using System.Collections.ObjectModel;

namespace Converter.ViewModels
{
    public class ConvertViewModel : ObservableObject
    {
        #region vars
        private IConvertFactory _fromBinToCSV = new ConvertFactory();
        private RelayCommand _convertCommand;
        private RelayCommand _openCommand;
        private List<TradeRecord> _listOfTrade = new List<TradeRecord>();
        private FileType _filyTypeFrom;
        private FileType _filyTypeTo;
        private string _progress;
        private DataAccessLayer.Structures.File _file = new DataAccessLayer.Structures.File();
        private ObservableCollection<string> _listOfname = new ObservableCollection<string>();
        private string Path { get; set; }
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
        public List<TradeRecord> ListOfTrade
        {
            get { return _listOfTrade; }
            set
            {
                _listOfTrade = value;
                RaisePropertyChanged(nameof(ListOfTrade));
            }
        }
        public ObservableCollection<string> ListOfName
        {
            get { return _listOfname; }
            set
            {
                _listOfname = value;
                RaisePropertyChanged(nameof(ListOfName));
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
            ListOfTrade = _file.Load();
            var Size = _file.Size;
            Path = _file.Path;
            ListOfName = _file.ListOfNames;
        }
        private void Converter()
        { 
            _fromBinToCSV.GetConverter(FileType.BinaryToCsv).ToConvert(ListOfTrade, Path);
        }
    }
}