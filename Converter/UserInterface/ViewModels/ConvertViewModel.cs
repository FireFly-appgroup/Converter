using Converter.DataAccessLayer;
using Converter.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Converter.BusinessLogicLayer.Interfaces;
using Converter.BusinessLogicLayer;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;
using Converter.UserInterface.Models;

namespace Converter.ViewModels
{
    public class ConvertViewModel : ObservableObject
    {
        #region vars
        private IConvertFactory _fromBinToCSV = new ConvertFactory();
        private RelayCommand _convertCommand;
        private RelayCommand _openCommand;
        private ObservableCollection<TradeRecord> _listOfTrade = new ObservableCollection<TradeRecord>();
        private FileType _filyTypeFrom;
        private FileType _filyTypeTo;
        private DataAccessLayer.Structures.File _file = new DataAccessLayer.Structures.File();
        private ObservableCollection<FilesModel> _convertList = new ObservableCollection<FilesModel>();
        private FilesModel files = new FilesModel();
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
        public ObservableCollection<TradeRecord> ListOfTrade
        {
            get { return _listOfTrade; }
            set
            {
                _listOfTrade = value;
                RaisePropertyChanged(nameof(ListOfTrade));
            }
        }
        public ObservableCollection<FilesModel> ConvertList
        {
            get { return _convertList; }
            set
            {
                _convertList = value;
                RaisePropertyChanged(nameof(ConvertList));
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
            files.Name = _file.Name;
            files.Progress = "Not Completed";
            ConvertList.Add(files);
        }
        private async void Converter()
        {  
            await TaskCompleted();
        }
        private async Task TaskCompleted()
        {
            var progressHandler = new Progress<string>(value =>
            {
                files.Progress = value;
            });
            var progress = progressHandler as IProgress<string>;
            await Task.Run(() =>
            {
                var listOfPathes = _fromBinToCSV.GetConverter(FileType.BinaryToCsv).ToConvert(ListOfTrade);
                foreach (var item in listOfPathes)
                    files.ConvertedFile = item;
                Thread.Sleep(100);
            });
            foreach (var item in ConvertList)
            {
                files.Progress = "Completed";
            }
        }
    }
}