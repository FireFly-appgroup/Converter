using System;
using System.Runtime.InteropServices;

namespace Converter.DataAccessLayer
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [Serializable]
    public struct TradeRecord
    {
        public int id { get; set; }
        public int account { get; set; }
        public double volume { get; set; }
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string comment;
    }
}
