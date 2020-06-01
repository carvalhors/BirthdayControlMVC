using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayControlMVC.Models
{
    public class Usuarios
    {
        public List<UsuarioModel> ListaUsuarios = new List<UsuarioModel>();
        private static int SetIdUsuario = 1;
  

        public void CriarUsuario(UsuarioModel UsuarioModelo)
        {
            UsuarioModelo.UsuarioID = SetIdUsuario++;
            ListaUsuarios.Add(UsuarioModelo);
        }

        public void AtualizaUsuario(UsuarioModel UsuarioModelo)
        {
            foreach (UsuarioModel usuario in ListaUsuarios)
            {
                if(usuario.UsuarioID == UsuarioModelo.UsuarioID)
                { 
                    usuario.Nome = UsuarioModelo.Nome;
                    usuario.Sobrenome = UsuarioModelo.Sobrenome;
                    usuario.Email = UsuarioModelo.Email;
                    usuario.DataNascimento = UsuarioModelo.DataNascimento;                  
                    break;
                }
            }
        } 

        public void DeletarUsuario(UsuarioModel UsuarioModelo)
        {
            ListaUsuarios.RemoveAll(x => x.UsuarioID == UsuarioModelo.UsuarioID);
        }

        public UsuarioModel BuscaUsuario(string Nome)
        {
            UsuarioModel _usuarioModel = null;

            foreach (UsuarioModel _usuario in ListaUsuarios)
            {
                if (_usuario.Nome == Nome)
                {
                    _usuarioModel = _usuario;
                }
            }
            return _usuarioModel;

        }
    }
}
