using AppLoginCore.Libraries.Filtro;
using AppLoginCore.Models.Constant;
using AppLoginCore.Repository.Contract;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;

namespace AppLoginCore.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao(ColaboradorTipoConstant.Gerente)]

    public class ColaboradorController : Controller
    {
        private IColaboradorRepository _colaboradorepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorepository = colaboradorRepository;
        }

        public IActionResult Index()
        {
            return View(_colaboradorepository.ObterTodosColaboradores());
        }
    }
}
