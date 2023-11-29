using Snapbites.Models;
using System.Data.SqlClient;
using System.Runtime.ConstrainedExecution;

namespace SnapBites.Repositories.ADO.SQLServer
{
    public class UsuarioDAO
    {
        private readonly string connectionString;

        public UsuarioDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Usuario> getAll() 
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id_user, nome, senha, email, atividade from usuario";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Usuario usuario= new  Usuario();

                        usuario.idUsuario = (int)dr["id_user"];
                        usuario.nome = dr["nome"].ToString();
                        usuario.email = (string)dr["email"];
                        usuario.senha = (string)dr["senha"];
                        usuario.atividade = (int)dr["atividade"];

                        usuarios.Add(usuario);
                    }
                }
            }

                return usuarios;
        }

        public Usuario getByIdUsuario(int id)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id_user, nome, senha, email, atividade from usuario";
                    command.Parameters.Add(new SqlParameter("@id_user", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {

                        usuario.idUsuario = (int)dr["id_user"];
                        usuario.nome = dr["nome"].ToString();
                        usuario.email = (string)dr["email"];
                        usuario.senha = (string)dr["senha"];
                        usuario.atividade = (int)dr["atividade"];                        
                    }
                }
            }
            return usuario;
        }

        public void update(int id, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Usuario, set nome = @nome, senha = @senha, email = @email, atividade = @atividade where id = @id ";
                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = usuario.nome;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = usuario.senha;
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = usuario.email;
                    command.Parameters.Add(new SqlParameter("@atividade", System.Data.SqlDbType.VarChar)).Value = usuario.atividade;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void add(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Usuario (nome, senha, email, atividade) values (@nome, @senha, @email, @atividade); select convert(int,@@identity) as id_usuario;;";

                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = usuario.nome;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = usuario.senha;
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = usuario.email;
                    command.Parameters.Add(new SqlParameter("@atividade", System.Data.SqlDbType.VarChar)).Value = usuario.atividade;

                    usuario.idUsuario =(int)command.ExecuteScalar();
                }
            }
        }

        public void delete(int id) 
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    string verifica = command.CommandText = "SELECT Atividade FROM Usuario WHERE id = @id;";

                    if (verifica == "0")
                    {

                    }
                    command.Connection = connection;
                    command.CommandText= "UPDADTE Usuario SET Atividade = 0;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    command.ExecuteNonQuery();
                }
            }

        }
    }
}
