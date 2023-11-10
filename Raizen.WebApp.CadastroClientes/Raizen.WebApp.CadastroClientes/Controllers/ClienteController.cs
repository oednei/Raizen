using Microsoft.AspNetCore.Mvc;
using Raizen.WebApp.CadastroClientes.Models;
using Raizen.WebApp.CadastroClientes.Repositorio;

namespace Raizen.WebApp.CadastroClientes.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio repositorio)
        {
            _clienteRepositorio = repositorio;
        }
        public IActionResult Index()
        {
            List<ClienteModel> clientes = _clienteRepositorio.BuscarTodos();
            return View(clientes);
        }

        public IActionResult Criar() 
        {
            return View();
        }

        public IActionResult Editar(int Id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(Id);
            return View(cliente);
        }

        public IActionResult Apagar(int Id)
        {
            try
            {
                bool apagado = _clienteRepositorio.Apagar(Id);

                if (apagado)
                    TempData["MensagemSucesso"] = "Cliente apagado com sucesso!";
                else
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar o Cliente!";

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar o Cliente, tente novamente. Detalhes: {err.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ConfirmaApagar(int Id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(Id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Criar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Adicionar(cliente);
                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu cliente, tente novamente. Detalhes: {err.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", cliente);
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar o cliente, tente novamente. Detalhes: {err.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
