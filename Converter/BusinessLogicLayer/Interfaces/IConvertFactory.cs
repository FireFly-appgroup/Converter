using Converter.DataAccessLayer;

namespace Converter.BusinessLogicLayer.Interfaces
{
    public interface IConvertFactory
    {
        IConverter GetConverter(FileType ConvertType);
    }
}
