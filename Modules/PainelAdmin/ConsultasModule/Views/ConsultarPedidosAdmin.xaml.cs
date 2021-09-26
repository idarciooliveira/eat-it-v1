using System;
using System.Diagnostics;
using System.Windows.Controls;
using EAT.Infrastruture.WPF.Extensions;

namespace ConsultasModule.Views
{
    /// <summary>
    /// Interação lógica para ConsultarPedidos.xam
    /// </summary>
    public partial class ConsultarPedidosAdmin
    {
        public ConsultarPedidosAdmin() => InitializeComponent();

        private void OnSeachByCode(object sender, TextChangedEventArgs e)
        {
            var code = int.Parse(string.IsNullOrEmpty(TextBoxPesquisa.Text) ? "0" : TextBoxPesquisa.Text);
            PedidoExtensions.SeachOnDataGrid(DataGridPedidos.Items, code);
        }
    }
}
