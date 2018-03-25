using System.Collections.Generic;

namespace Converter.BusinessLogicLayer.Interfaces
{
    public interface IConverter
    {
        void ToConvert<T>(List<T> File, string Path);
    }
}
