using CadastrandoContatosAsp.Helper;
using CadastrandoContatosAsp.Models;
using CadastrandoContatosAsp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CadastrandoContatosAsp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            //SE O USUARIO ESTIVER LOGADO REDIRECIONAR PARA A HOME 
            if(_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }
                    
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");

        }
        
        [HttpPost]

        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                            TempData["MensagemErro"] = $"Usuario ou senha invalida!";
                    }
                            TempData["MensagemErro"] = $"Usuario ou senha invalida!";
                }

                return View("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, Não conseguimos Logar! detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
