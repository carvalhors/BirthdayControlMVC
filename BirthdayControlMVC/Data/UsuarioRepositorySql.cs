using BirthdayControlMVC.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BirthdayControlMVC.Data
{
    public class UsuarioRepositorySql : IUsuarioRepositoy
    {
        string ConnStrSqlServer = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DR2_AT;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<UsuarioModel> ListarTodosUsuarios(string Tipo)
        {

            using var Conn = new SqlConnection(ConnStrSqlServer);
            var Cmd = Conn.CreateCommand();

            switch (Tipo)
            {
                case "T":
                    Cmd.CommandText = "select * from Usuarios";
                    break;
                case "D":
                    Cmd.CommandText = "select * from Usuarios where DataNascimento = convert(date, GETDATE())";
                    break;
                case "N":
                    Cmd.CommandText = "select * from Usuarios order by DataNascimento desc";
                    break;
                default:
                    Cmd.CommandText = "select * from Usuarios";
                    break;
            }

            Conn.Open();

            var Reader = Cmd.ExecuteReader();
            List<UsuarioModel> ListaDeUsuarios = new List<UsuarioModel>();

            while (Reader.Read())
            {
                var Usr = new UsuarioModel()
                {
                    UsuarioID = Reader.GetInt32("UsuarioID"),
                    Nome = Reader.GetString("Nome"),
                    Sobrenome = Reader.GetString("Sobrenome"),
                    Email = Reader.GetString("Email"),
                    DataNascimento = Reader.GetDateTime("DataNascimento")
                };
                ListaDeUsuarios.Add(Usr);
            }

            Conn.Close();

            return ListaDeUsuarios;

        }

        public void SalvarUsuarioDb(UsuarioModel usuario)
        {
            using var Conn = new SqlConnection(ConnStrSqlServer);
            var Cmd = Conn.CreateCommand();

            var SqlIns = @"insert into dbo.Usuarios (Nome, Sobrenome, Email, DataNascimento)
                            values (@nome, @sobrenome, @email, @dtnasc)";

            Cmd.CommandText = SqlIns;
            Cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            Cmd.Parameters.AddWithValue("@sobrenome", usuario.Sobrenome);
            Cmd.Parameters.AddWithValue("@email", usuario.Email);
            Cmd.Parameters.AddWithValue("@dtnasc", usuario.DataNascimento);

            Conn.Open();
            Cmd.ExecuteNonQuery();
            Conn.Close();
        }

        public void DeletarUsuarioDb(UsuarioModel usuario)
        {
            using var Conn = new SqlConnection(ConnStrSqlServer);
            var Cmd = Conn.CreateCommand();

            var SqlDel = @"delete from dbo.Usuarios where UsuarioID = @UsuarioID";

            Cmd.CommandText = SqlDel;
            Cmd.Parameters.AddWithValue("@UsuarioID", usuario.UsuarioID);

            Conn.Open();
            Cmd.ExecuteNonQuery();
            Conn.Close();
        }

        public void EditarUsuarioDb(UsuarioModel usuario)
        {
            using var Conn = new SqlConnection(ConnStrSqlServer);
            var Cmd = Conn.CreateCommand();

            var SqlUpd = @"update dbo.Usuarios set Nome = @nome, Sobrenome = @sobrenome, Email = @email, DataNascimento = @dtnasc
                            where UsuarioID = @UsuarioID";

            Cmd.CommandText = SqlUpd;
            Cmd.Parameters.AddWithValue("@UsuarioID", usuario.UsuarioID);
            Cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            Cmd.Parameters.AddWithValue("@sobrenome", usuario.Sobrenome);
            Cmd.Parameters.AddWithValue("@email", usuario.Email);
            Cmd.Parameters.AddWithValue("@dtnasc", usuario.DataNascimento);

            Conn.Open();
            Cmd.ExecuteNonQuery();
            Conn.Close();
        }

    }
}
