using System.Collections.Generic;

namespace Converter.DataAccessLayer.Interfaces
{
    interface IFile
    {
        void Save(List<TradeRecord> trade);
        string Open();
    }
}
