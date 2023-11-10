using Raizen.WebApp.CadastroClientes.Data;
using Raizen.WebApp.CadastroClientes.Models;

namespace Raizen.WebApp.CadastroClientes.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private DataContext _dataContext { get; set; }

        public ClienteRepositorio(DataContext contexto)
        {
            _dataContext = contexto;
        }
        public ClienteModel Adicionar(ClienteModel cliente)
        {
            _dataContext.Clientes.Add(cliente);
            _dataContext.SaveChanges();
            return cliente;
        }

        public bool Apagar(int Id)
        {
            ClienteModel cliente = ListarPorId(Id);

            if (cliente == null) throw new Exception("Houve um erro ao tentar apagar o Cliente informado.");

            _dataContext.Clientes.Remove(cliente);
            _dataContext.SaveChanges();

            return true;
        }

        public ClienteModel Atualizar(ClienteModel cliente)
        {
            ClienteModel clienteSalvo = ListarPorId(cliente.Id);

            if (clienteSalvo == null) throw new Exception("Houve um erro ao editar o cliente");

            clienteSalvo.Nome = cliente.Nome;
            clienteSalvo.Email = cliente.Email;
            clienteSalvo.CEP = cliente.CEP;

            _dataContext.Update(clienteSalvo);
            _dataContext.SaveChanges();

            return clienteSalvo;

        }

        public List<ClienteModel> BuscarTodos()
        {
            return _dataContext.Clientes.ToList();
        }

        public ClienteModel ListarPorId(int Id)
        {
            return _dataContext.Clientes.FirstOrDefault(c => c.Id == Id);
        }
    }
}
