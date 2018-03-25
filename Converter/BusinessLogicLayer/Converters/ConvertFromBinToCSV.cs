using Converter.BusinessLogicLayer.Interfaces;
using System.IO;
using System;
using System.Reflection;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Converter.BusinessLogicLayer.Structures
{
    public class ConvertFromBinToCSV : IConverter
    {
        private List<string> ListOfcsvCompletePath = new List<string>();
       public  List<string> ToConvert<T>(ObservableCollection<T> FileForConvert)
        {
            foreach (T item in FileForConvert)
            {
                var csvCompletePath = String.Format(AppDomain.CurrentDomain.BaseDirectory + "{0}.csv", Guid.NewGuid());
                ListOfcsvCompletePath.Add(csvCompletePath);
                Type type = FileForConvert[0].GetType();
                string newLine = Environment.NewLine;
                if (!Directory.Exists(Path.GetDirectoryName(csvCompletePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(csvCompletePath));
                using (StreamWriter sw = new StreamWriter(csvCompletePath))
                {
                    object o = Activator.CreateInstance(type);
                    PropertyInfo[] props = o.GetType().GetProperties();
                    sw.Write(string.Join(Environment.NewLine, props.Select(d => d.Name).ToArray()) + newLine);
                        var row = string.Join(",", props.Select(d => item.GetType()
                                                                        .GetProperty(d.Name)
                                                                        .GetValue(item, null)
                                                                        .ToString())
                                                                        .ToArray());
                        sw.Write(row + newLine);
                }
            }
            return ListOfcsvCompletePath;
        }
    }
}
