using CadastrandoContatosAsp.Models;

namespace CadastrandoContatosAsp.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListaPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel  contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
