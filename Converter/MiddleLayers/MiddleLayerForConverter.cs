using Converter.Utils;
using Converter.ViewModels;
using Converter.Views;
using System.Windows.Controls;

namespace Converter.MiddleLayers
{
    public class MiddleLayerForConverter : ModuleBase
    {
        public override string Name
        {
            get { return "2) Converter"; }
        }
        protected override UserControl CreateViewAndViewModel()
        {
            return new ConvertPage() { DataContext = new ConvertViewModel() };
        }
    }
}