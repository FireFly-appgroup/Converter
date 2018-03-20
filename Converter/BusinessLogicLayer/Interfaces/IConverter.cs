using Converter.DataAccessLayer;

namespace Converter.BusinessLogicLayer.Interfaces
{
    interface IConverter
    {
        void ToConvert(FileType From, FileType To, string File);
    }
}
