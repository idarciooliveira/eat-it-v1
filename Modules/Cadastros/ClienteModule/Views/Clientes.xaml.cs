using System.Windows.Controls;
using ClienteModule.ViewModels;

namespace ClienteModule.Views
{
    /// <summary>
    /// Interação lógica para Clientes.xam
    /// </summary>
    public partial class Clientes
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void OnSeach(object sender, TextChangedEventArgs e)
        {
            ClientesBase.SeachOnDataGrid(DataGrid.Items,TextBox.Text);
        }
    }
}
