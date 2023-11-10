using Raizen.WebApp.CadastroClientes.Models;

namespace Raizen.WebApp.CadastroClientes.Repositorio
{
    public interface IClienteRepositorio
    {
        ClienteModel ListarPorId(int Id);
        List<ClienteModel> BuscarTodos();
        ClienteModel Adicionar(ClienteModel cliente);

        ClienteModel Atualizar(ClienteModel cliente);
        bool Apagar(int Id);
    }
}
