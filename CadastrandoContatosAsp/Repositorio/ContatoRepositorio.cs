using CadastrandoContatosAsp.Data;
using CadastrandoContatosAsp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace CadastrandoContatosAsp.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }
            
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel ListaPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(p => p.Id == id);
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListaPorId(contato.Id);

            if (contatoDB == null) throw new SystemException("Houve um erro na atualização do contato");
                  contatoDB.Nome = contato.Nome;
                  contatoDB.Email = contato.Email;
                  contatoDB.Celular = contato.Celular;

            _bancoContext.Update(contatoDB);
            _bancoContext.SaveChanges();
            
            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListaPorId(id);
            if(contatoDB !=  null)
            {
                _bancoContext.Contatos.Remove(contatoDB);
            }
            else
            {
                throw new Exception("Houveu um erro ao deletar");
            }

            _bancoContext.SaveChanges();
            return true;
        }
    }
}
