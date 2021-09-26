namespace EAT.Infrastruture.WPF.Models
{
    public class Message
    {
        public string AlreadyExist = "Produto Já Adicionado";
        public const string Registed = "Salvo Com Sucesso";
        public const string Removed = "Excluir Com Sucesso";
        public const string EmptyData = "Deve Preencher os Campos vazios";
        public const string DbConnectionError = "Erro ao Conectar-se com a Base de dados";
        public const string Updated = "Actualizado com Sucesso";
        public const string Exit = "Deseja Realmente Sair do Sistema?";
        public const string PedidoSaved = "Pedido Registrado com Sucesso";
        public const string PedidoChanged = "Pedido Alterado com Sucesso";
        public const string PedidoCancel = "Deseja Realmente Anular o Pedido?";
        public const string ItemRemoved = "Item Removido Com Sucesso";
        public const string ItemExist = "Item Já Adicionado";
        public const string ItemChanged = "Item Alterado Com Sucesso";
        public const string PedidoCantChange = "Não Pode Alterar Pedidos Finalizados/Entregues";
        public const string ItemCantChange = "Não Pode Alterar Items de Pedido Finalizado/Entregue";
        public const string PedidoAberto = "Este cliente já passui um Pedido Aberto";

        public const string LoginError = "Username ou Password incorretos";
        public const string CantRemoveCategory = "Não pode remover uma categoira em uso";

    }
}
