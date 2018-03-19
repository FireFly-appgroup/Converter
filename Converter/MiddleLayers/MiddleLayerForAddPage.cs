using Converter.Utils;
using Converter.ViewModels;
using Converter.Views;
using System.Windows.Controls;

namespace Converter.MiddleLayers
{
    public class MiddleLayerForAddPage : ModuleBase
    {
        public override string Name
        {
            get { return "3) Add Binary Files"; }
        }
        protected override UserControl CreateViewAndViewModel()
        {
            return new AddBinaryFiles() { DataContext = new OperationViewModel(Name) };
        }
    }
}
