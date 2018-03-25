using Converter.DataAccessLayer;
using Converter.DataAccessLayer.Structures;
using Converter.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Converter.ViewModels
{
    public class CreateBinaryViewModel : ObservableObject
    {
        #region vars
        private ObservableCollection<TradeRecord> _tradeList = new ObservableCollection<TradeRecord>();
        private TradeRecord _trade = new TradeRecord();
        private File _file = new File();
        private int _idTextBox;
        private int _accountTextBox;
        private double _volumeTextBox;
        private string _commentTextBox;
        private RelayCommand _createBinaryFileCommand;
        #endregion
        #region Properties
        public int IdTextBox
        {
            get { return _idTextBox; }
            set
            {
                _idTextBox = value;
                RaisePropertyChanged(nameof(IdTextBox));
            }
        }
        public int AccountTextBox
        {
            get { return _accountTextBox; }
            set
            {
                _accountTextBox = value;
                RaisePropertyChanged(nameof(AccountTextBox));
            }
        }
        public double VolumeTextBox
        {
            get { return _volumeTextBox; }
            set
            {
                _volumeTextBox = value;
                RaisePropertyChanged(nameof(VolumeTextBox));
            }
        }
        public string CommentTextBox
        {
            get { return _commentTextBox; }
            set
            {
                _commentTextBox = value;
                RaisePropertyChanged(nameof(CommentTextBox));
            }
        }
        public RelayCommand CreateBinaryFileCommand
        {
            get
            {
                return _createBinaryFileCommand = _createBinaryFileCommand ??
                  new RelayCommand(CreateBinaryFile);
            }
        }
        public ObservableCollection<TradeRecord> TradeList
        {
            get { return _tradeList; }
            set
            {
                _tradeList = value;
                RaisePropertyChanged(nameof(TradeList));
            }
        }
        #endregion
        private void CreateBinaryFile()
        {
            _trade.id = IdTextBox;
            _trade.account = AccountTextBox;
            _trade.volume = VolumeTextBox;
            _trade.comment = CommentTextBox;
            _tradeList.Add(_trade);
            _file.Save(_tradeList);
        }
    }
}
