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
            var cellInfo = DataGridWithBinaryList.SelectedCells[0];
            var content = cellInfo.Column.GetCellContent(cellInfo.Item);
        }
    }
}
