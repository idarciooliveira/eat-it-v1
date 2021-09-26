using System.Windows.Controls;
using EAT.Infrastruture.WPF.Extensions;

namespace ConsultarPedidosOnline.Views
{
    /// <summary>
    /// Interação lógica para ConsultarPedidosOnline.xam
    /// </summary>
    public partial class ConsultarPedidosOnline : UserControl
    {
        public ConsultarPedidosOnline()
        {
            InitializeComponent();
        }

        private void OnSeach(object sender, TextChangedEventArgs e)
        {
            var code = int.Parse(string.IsNullOrEmpty(TextBox.Text) ? "0" : TextBox.Text);
            PedidoExtensions.SeachOnDataGrid(DataGrid.Items, code);
        }
    }
}
