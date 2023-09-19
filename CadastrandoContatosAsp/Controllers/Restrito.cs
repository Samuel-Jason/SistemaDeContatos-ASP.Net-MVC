using CadastrandoContatosAsp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CadastrandoContatosAsp.Controllers
{
    public class Restrito : Controller
    {
        [PaginaParaUsuarioLogado]
        public IActionResult Index()
        {
            return View();
        }
    }
}
