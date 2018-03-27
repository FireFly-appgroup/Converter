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
using Converter.BusinessLogicLayer.Structures;

namespace Converter.ViewModels
{
    public class ConvertViewModel : ObservableObject
    {
        #region vars
        private RelayCommand _convertCommand;
        private RelayCommand _openCommand;
        private RelayCommand _clearCommand;
        private ObservableCollection<TradeRecord> _listOfTrade = new ObservableCollection<TradeRecord>();
        private FileType _filyTypeFrom;
        private FileType _filyTypeTo;
        private DataAccessLayer.Structures.File _file = new DataAccessLayer.Structures.File();
        private ObservableCollection<FilesModel> _convertList = new ObservableCollection<FilesModel>();
        private ObservableCollection<string> _convertedFiles = new ObservableCollection<string>();
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
        public ObservableCollection<string> ConvertedFiles
        {
            get { return _convertedFiles; }
            set
            {
                _convertedFiles = value;
                RaisePropertyChanged(nameof(ConvertedFiles));
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
        public RelayCommand ClearCommand
        {
            get
            {
                return _clearCommand = _clearCommand ??
                  new RelayCommand(Clear);
            }
        }
        #endregion
        private void DownloadFile()
        {
            if (files.Name != String.Empty)
            {
                var model = _file.Load();
                var files = new FilesModel();
                files.Name = model.Name;
                files.Progress = model.Progress;
                ConvertList.Add(files);
            }
        }
        private void Converter()
        {
            if (_file.TaskCompleted() == true)
            {
                ConvertList.Where(w => w.Progress == "Not Completed").ToList().ForEach(s => s.Progress = "Completed");
                ConvertedFiles = ConvertFromBinToCSV.ListOfcsvCompletePath;
            }       
        }
        private void Clear()
        {
            ConvertList.Clear();
            ConvertedFiles.Clear();
        }
    }
}