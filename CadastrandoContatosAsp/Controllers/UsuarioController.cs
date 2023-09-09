using CadastrandoContatosAsp.Models;
using CadastrandoContatosAsp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CadastrandoContatosAsp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepository)
        {
            _usuarioRepositorio = usuarioRepository;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuario = _usuarioRepositorio.BuscarTodos();
            return View(usuario);
        }
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";
                    return RedirectToAction("Index");

                }
                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, Não conseguimos cadastrar seu usuario! detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");

            }
        }

    }
}
