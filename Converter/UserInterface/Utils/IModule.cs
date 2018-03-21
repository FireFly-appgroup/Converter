using System.Windows.Controls;

namespace Converter.Utils
{
    public interface IModule
    {
        string Name { get; }
        UserControl UserInterface { get; }
        void Deactivate();
    }
}
