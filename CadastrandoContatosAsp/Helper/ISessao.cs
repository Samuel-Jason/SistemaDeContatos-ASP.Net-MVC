using CadastrandoContatosAsp.Models;

namespace CadastrandoContatosAsp.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuarioModel usuario);
        void RemoverSessaoUsuario(UsuarioModel usuario);
        UsuarioModel BuscarSessaoDoUsuario();
    }
}
