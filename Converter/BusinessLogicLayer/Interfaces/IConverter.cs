using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Converter.BusinessLogicLayer.Interfaces
{
    public interface IConverter
    {
        bool ToConvert<T>(ObservableCollection<T> File);
    }
}
