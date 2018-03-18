using Converter.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.DataAccessLayer.Structures
{
    public class File : IFile
    {
        public double Size { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<TradeRecord> tradeRecord = new List<TradeRecord>();

        public void ToBinary()
        {

        }
        public void Save()
        {

        }
    }
}
