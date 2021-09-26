using System.Windows.Controls;
using ConsultarClienteModule.ViewModels;

namespace ConsultarClienteModule.Views
{
    /// <summary>
    /// Interação lógica para ClientesRegistrados.xam
    /// </summary>
    public partial class ClientesRegistrados 
    {
        public ClientesRegistrados()
        {
            InitializeComponent();
        }

        private void OnPesquisar(object sender, TextChangedEventArgs e)
        {
            ClientesRegistradosViewModel.SeachOnDataGrid(DataGridClientes.Items,TextBox.Text);
        }
    }
}
