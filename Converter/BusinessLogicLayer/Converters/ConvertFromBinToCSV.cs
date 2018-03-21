using Converter.BusinessLogicLayer.Interfaces;
using Converter.DataAccessLayer;
using Microsoft.Win32;
using System.IO;
using System;

namespace Converter.BusinessLogicLayer.Structures
{
   public  interface IConvertFactory
    {
        IConverter GetConverter(FileType ConvertType);
    }

    public class ConvertFactory : IConvertFactory
    {
        private IConverter B2C;
        public ConvertFactory()
        {
            B2C = new ConvertFromBinToCSV();
        }

        public IConverter GetConverter(FileType ConvertType)
        {
            if (ConvertType == FileType.BinaryToCsv)
                return B2C;
            throw new NotImplementedException();
        }
    }


    public class ConvertFromBinToCSV : IConverter
    {
       
       public void ToConvert(string FileForConvert)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "File (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.WriteLine(FileForConvert);
                    sw.Close();
                }
            }
        }
    }
}
