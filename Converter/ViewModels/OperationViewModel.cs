using Converter.Utils;

namespace Converter.ViewModels
{
    public class OperationViewModel : ObservableObject
    {
        private string _HeadText;
        private RelayCommand _ChangeHeadTextCommand;

        public OperationViewModel(string name)
        {
            HeadText = name;
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
        public RelayCommand ChangeHeadTextCommand
        {
            get
            {
                return _ChangeHeadTextCommand = _ChangeHeadTextCommand ??
                  new RelayCommand(OnChangeHeadText);
            }
        }
        private void OnChangeHeadText()
        {
            HeadText = "Привет!";
        }
    }
}
