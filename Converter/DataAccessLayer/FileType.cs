using System.ComponentModel;

namespace Converter.DataAccessLayer
{
    public enum FileType
    {
        [Description(".csv")]
        csv,
        [Description(".txt")]
        txt,
        [Description(".pdf")]
        pdf,
        [Description(".doc")]
        doc,
        [Description(".bin")]
        bin
    }
}
