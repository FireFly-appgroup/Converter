using System.Collections.Generic;

namespace Converter.DataAccessLayer.Interfaces
{
    interface IFile
    {
        void ToBinary();
        void Save(List<TradeRecord> trade);
    }
}
