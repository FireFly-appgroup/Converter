using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Converter.BusinessLogicLayer.Interfaces
{
    public interface IConverter
    {
        Task ToConvert<T>(ObservableCollection<T> File);
    }
}
