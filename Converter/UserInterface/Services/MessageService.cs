using System.Windows;

namespace Converter.Services
{
    public static class MessageService
    {
        public static void ShowMessage(string message)
        {
            MessageBox.Show(message, "Messange", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
