using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.DataAccessLayer.Interfaces
{
    interface IFile
    {
        void ToBinary();
        void Save(TradeRecord trade);
    }
}
