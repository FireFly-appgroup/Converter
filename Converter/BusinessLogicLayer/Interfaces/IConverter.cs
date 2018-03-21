using Converter.DataAccessLayer;
using System.Collections.Generic;

namespace Converter.BusinessLogicLayer.Interfaces
{
    public interface IConverter
    {
        void ToConvert(List<TradeRecord> File);
    }
}
