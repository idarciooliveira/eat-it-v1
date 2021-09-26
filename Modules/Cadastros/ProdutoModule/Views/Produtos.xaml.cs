using System.Windows.Controls;
using ProdutoModule.ViewModels;

namespace ProdutoModule.Views
{
    /// <summary>
    /// Interação lógica para Produtos.xam
    /// </summary>
    public partial class Produtos
    {
        public Produtos()
        {
            InitializeComponent();
        }

        private void OnPesquisar(object sender, TextChangedEventArgs e)
        {
            ProdutoBase.SeachOnDataGrid(DataGrid.Items,TextBoxPesquisar.Text);
        }
    }
}
