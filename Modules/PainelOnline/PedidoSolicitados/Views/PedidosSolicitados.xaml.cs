using System.Windows.Controls;
using EAT.Infrastruture.WPF.Extensions;

namespace PedidoSolicitados.Views
{
    /// <summary>
    /// Interação lógica para PedidosSolicitados.xam
    /// </summary>
    public partial class PedidosSolicitados 
    {
        public PedidosSolicitados()
        {
            InitializeComponent();
        }

        private void OnSeachByCode(object sender, TextChangedEventArgs e)
        {
            var code = int.Parse(string.IsNullOrEmpty(TextBoxPesquisa.Text) ? "0" : TextBoxPesquisa.Text);
            PedidoExtensions.SeachOnDataGrid(DataGrid.Items, code);
        }
    }
}
