using System;
using System.Collections.Generic;
using System.Windows;

namespace Converter.Services
{
    public static class MessageService
    {
        public static void ShowMessage(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
