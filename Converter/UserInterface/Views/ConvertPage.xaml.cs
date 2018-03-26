using Converter.DataAccessLayer;
using Converter.UserInterface.Models;
using System.Windows;
using System.Windows.Controls;

namespace Converter.Views
{
    public partial class ConvertPage : UserControl
    {
        public ConvertPage()
        {
            InitializeComponent();    
        }
        private void DataGridWithBinaryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cellInfo = DataGridWithBinaryList.SelectedItem as FilesModel;
            MessageBox.Show("Status: " + cellInfo.Progress);
        }
    }
}
