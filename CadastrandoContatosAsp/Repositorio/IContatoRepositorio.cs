using CadastrandoContatosAsp.Models;

namespace CadastrandoContatosAsp.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel  contato);


    }
}
