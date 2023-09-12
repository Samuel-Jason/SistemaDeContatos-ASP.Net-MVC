using CadastrandoContatosAsp.Data;
using CadastrandoContatosAsp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace CadastrandoContatosAsp.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListaPorId(usuario.Id);

            if (usuarioDB == null) throw new SystemException("Houve um erro na atualização do usuario");
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }


        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }


        public UsuarioModel ListaPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(p => p.Id == id);
        }


        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListaPorId(id);
            if (usuarioDB != null)
            {
                _bancoContext.Usuarios.Remove(usuarioDB);
            }
            else
            {
                throw new Exception("Houveu um erro ao deletar");
            }

            _bancoContext.SaveChanges();
            return true;
        }

        List<UsuarioModel> IUsuarioRepositorio.BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        //public UsuarioModel Adicionar(UsuarioModel usuario)
        //{
        //    _bancoContext.Usuarios.Add(usuario);
        //    _bancoContext.SaveChanges();
        //    return usuario;
        //}

        // public UsuarioModel Atualizar(UsuarioModel usuario)
        //   {
        //    throw new NotImplementedException();
        // }
    }
}
