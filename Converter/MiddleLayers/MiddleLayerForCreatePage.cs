using Converter.ViewModels;
using Converter.Views;
using System.Windows.Controls;

namespace Converter.Utils
{
    public class MiddleLayerForCreatePage : ModuleBase
    {
        public override string Name
        {
            get { return "1) Create Binary Files"; }
        }
        protected override UserControl CreateViewAndViewModel()
        {
            return new CreateBinaryFiles() { DataContext = new OperationViewModel() };
        }
    }
}