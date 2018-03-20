using System.Collections.Generic;

namespace Converter.DataAccessLayer.Interfaces
{
    interface IFile
    {
        string ToBinary();
        void Save(List<TradeRecord> trade);
        string Open();
    }
}
