using System.Collections.Generic;

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

        public void AtualizarUsuario(UsuarioModel UsuarioModelo)
        {
            foreach (UsuarioModel U in ListaUsuarios)
            {
                if (U.UsuarioID == UsuarioModelo.UsuarioID)
                {
                    U.Nome = UsuarioModelo.Nome;
                    U.Sobrenome = UsuarioModelo.Sobrenome;
                    U.Email = UsuarioModelo.Email;
                    U.DataNascimento = UsuarioModelo.DataNascimento;
                    break;
                }
            }
        }

        public void DeletarUsuario(UsuarioModel UsuarioModelo)
        {
            ListaUsuarios.RemoveAll(x => x.UsuarioID == UsuarioModelo.UsuarioID);
        }

        public UsuarioModel BuscarUsuario(string Nome)
        {
            UsuarioModel UsuarioModelo = null;

            foreach (UsuarioModel Usr in ListaUsuarios)
            {
                if (Usr.Nome == Nome)
                {
                    UsuarioModelo = Usr;
                }
            }
            return UsuarioModelo;

        }
    }
}
