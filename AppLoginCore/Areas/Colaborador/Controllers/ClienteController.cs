using AppLoginCore.Libraries.Filtro;
using AppLoginCore.Models;
using AppLoginCore.Models.Constant;
using AppLoginCore.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AppLoginCore.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class ClienteController : Controller
    {
        private IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [ValidateHttpReferer]
        public IActionResult Ativar(int id)
        {
            _clienteRepository .Ativar(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Desativar(int id)
        {
            _clienteRepository.Desativar(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar([FromForm] Cliente cliente)
        {
            cliente.Situacao = SituacaoConstant.Ativo;

            _clienteRepository.Cadastrar(cliente);
            return RedirectToAction(nameof(Cadastrar));
        }


        public IActionResult Index()
        {
            return View(_clienteRepository.ObterTodosClientes());
        }
    }
}
