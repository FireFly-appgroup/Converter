namespace Converter.UserInterface.Models
{
    public class FilesModel : ObservableObject
    {
        public string Name { get; set; }
        public string _convertedFile { get; set; }
        public string _progress;
        public string Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                RaisePropertyChanged(nameof(Progress));
            }
        }
        public string ConvertedFile
        {
            get { return _convertedFile; }
            set
            {
                _convertedFile = value;
                RaisePropertyChanged(nameof(ConvertedFile));
            }
        }
    }
}
