using Converter.DataAccessLayer;
using Converter.DataAccessLayer.Structures;
using Converter.Utils;

namespace Converter.ViewModels
{
    public class OperationViewModel : ObservableObject
    {
        private TradeRecord trade = new TradeRecord();
        private File _file = new File();
        private string _HeadText;
        private int _idTextBox;
        private int _accountTextBox;
        private double _volumeTextBox;
        private string _commentTextBox;
        private RelayCommand _createBinaryFileCommand;

        public OperationViewModel(string name)
        {
            HeadText = name;
        }
        #region Properties
        public string HeadText
        {
            get { return _HeadText; }
            set
            {
                _HeadText = value;
                RaisePropertyChanged(nameof(HeadText));
            }
        }
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
        #endregion
        private void CreateBinaryFile()
        {
            trade.id = IdTextBox;
            trade.account = AccountTextBox;
            trade.volume = VolumeTextBox;
            trade.comment = CommentTextBox;
            _file.Save(trade);
        }
    }
}
