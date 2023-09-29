using CadastrandoContatosAsp.Models;

namespace CadastrandoContatosAsp.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos(int usuarioId);
        ContatoModel ListaPorId(int id);
        ContatoModel Adicionar(ContatoModel  contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
