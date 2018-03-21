using System.Collections.Generic;

namespace Converter.DataAccessLayer.Interfaces
{
    interface IFile
    {
        void Save<T>(T trade);
        List<TradeRecord> Load();
    }
}
