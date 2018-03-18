using Converter.ViewModels;
using Converter.Views;
using System.Windows.Controls;

namespace Converter.Utils
{
   public class MiddeLayerForEditPage : ModuleBase
    {
        public override string Name
        {
            get { return "Edit Binary Files"; }
        }
        protected override UserControl CreateViewAndViewModel()
        {
            return new EditBinaryFiles() { DataContext = new OperationViewModel(Name) };
        }
    }
}