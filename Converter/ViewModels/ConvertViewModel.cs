using Converter.Services;
using Converter.Utils;
using System;

namespace Converter.ViewModels
{
    public class ConvertViewModel : ObservableObject
    {
        private string _HeadText;
        private string _InputText;
        private RelayCommand _ChangeHeadTextCommand;

        public ConvertViewModel()
        {
            HeadText = "Converter";
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
        public string InputText
        {
            get { return _InputText; }
            set
            {
                _InputText = value;
                RaisePropertyChanged(nameof(InputText));
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
            if (String.IsNullOrEmpty(InputText))
            {
                MessageService.ShowMessage("Введите текст, пожалуйста.");
                return;
            }

            HeadText = InputText;
        }
    }
}