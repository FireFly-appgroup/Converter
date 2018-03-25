namespace Converter.UserInterface.Models
{
    public class FilesModel : ObservableObject
    {
        public string Name { get; set; }
        public string ConvertedFile { get; set; }
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
    }
}
