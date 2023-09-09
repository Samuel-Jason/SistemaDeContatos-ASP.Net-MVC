using CadastrandoContatosAsp.Models;

namespace CadastrandoContatosAsp.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel ListaPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel  usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
    }
}
