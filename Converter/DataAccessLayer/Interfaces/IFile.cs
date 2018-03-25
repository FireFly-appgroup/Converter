using System.Collections.ObjectModel;

namespace Converter.DataAccessLayer.Interfaces
{
    interface IFile
    {
        void Save<T>(T trade);
        ObservableCollection<TradeRecord> Load();
    }
}
