using Converter.BusinessLogicLayer.Interfaces;
using Converter.BusinessLogicLayer.Structures;
using Converter.DataAccessLayer;
using System;

namespace Converter.BusinessLogicLayer
{
    public class ConvertFactory : IConvertFactory
    {
        private IConverter BinToCsv;
        public ConvertFactory()
        {
            BinToCsv = new ConvertFromBinToCSV();
        }
        public IConverter GetConverter(FileType ConvertType)
        {
            if (ConvertType == FileType.BinaryToCsv)
                return BinToCsv;
            throw new NotImplementedException();
        }
    }
}
