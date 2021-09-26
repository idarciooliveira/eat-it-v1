using System.Windows.Controls;
using FuncionarioModule.ViewModels;

namespace FuncionarioModule.Views
{
    /// <summary>
    /// Interação lógica para Funcionarios.xam
    /// </summary>
    public partial class Funcionarios 
    {
        public Funcionarios()
        {
            InitializeComponent();
        }

        private void OnSeach(object sender, TextChangedEventArgs e)
        {
            FuncionarioBase.SeachOnDataGrid(DataGrid.Items,TextBox.Text);
        }
    }
}
