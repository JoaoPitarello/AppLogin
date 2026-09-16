using AppLoginCore.Libraries.Filtro;
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


        public IActionResult Index()
        {
            return View(_clienteRepository.ObterTodosClientes());
        }
    }
}
