using Converter.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Converter
{
    public class MainWindowViewModel : ObservableObject
    {
        public List<IModule> Modules { get; private set; }
        private IModule _SelectedModule;

        public MainWindowViewModel(IEnumerable<IModule> modules)
        {
            Modules = modules.OrderBy(m => m.Name).ToList();
            if (this.Modules.Count > 0)
            {
                SelectedModule = this.Modules[0];
            }
        }
        public IModule SelectedModule
        {
            get { return _SelectedModule; }
            set
            {
                if (value == _SelectedModule) return;
                if (_SelectedModule != null) _SelectedModule.Deactivate();
                _SelectedModule = value;
                RaisePropertyChanged(nameof(SelectedModule));
                RaisePropertyChanged("UserInterface");
            }
        }
        public UserControl UserInterface
        {
            get
            {
                if (SelectedModule == null) return null;
                return SelectedModule.UserInterface;
            }
        }
    }
}
