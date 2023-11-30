using Microsoft.Data.SqlClient;
using Snapbites.Models;
using SnapBites.Controllers;
using SnapBites.Models;
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
                    command.CommandText = "select id_user, nome_usuario, senha, email, atividade from Usuarios";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Usuario usuario= new  Usuario();

                        usuario.idUsuario = (int)dr["id_user"];
                        usuario.nome = dr["nome_usuario"].ToString();
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
                    command.CommandText = "select id_user, nome_usuario, senha, email, atividade from Usuarios";
                    command.Parameters.Add(new SqlParameter("@id_user", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {

                        usuario.idUsuario = (int)dr["id_user"];
                        usuario.nome = dr["nome_usuario"].ToString();
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
                    command.CommandText = "update Usuarios, set nome_usuario = @nome, senha = @senha, email = @email, atividade = @atividade where id_user = @id ";
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
                    command.CommandText = "insert into Usuarios (nome_usuario, senha, email, atividade) values (@nome, @senha, @email, @atividade); select convert(int,@@identity) as id_user;;";

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
                    string verifica = command.CommandText = "SELECT Atividade FROM Usuarios WHERE id_user = @id;";

                    if (verifica == "0")
                    {

                    }
                    command.Connection = connection;
                    command.CommandText= "UPDADTE Usuarios SET Atividade = 0;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool check(Usuario usuario)
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_usuario FROM Usuarios WHERE nome_usuario=@usuario AND senha=@senha";
                    command.Parameters.Add(new SqlParameter("@usuario", System.Data.SqlDbType.VarChar)).Value = usuario.nome;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = usuario.senha;

                    SqlDataReader dr = command.ExecuteReader();
                    result = dr.Read();
                }
            }

            return result;
        }

        public LoginResultado getTipo(Usuario usuario)
        {
            Niveis niveis = new Niveis();

            LoginResultado result = new LoginResultado();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT usu.id_user, ni.nivel FROM Usuarios AS usu INNER JOIN niveis AS ni ON (ni.id_usuario = usu.id_usuario)WHERE nome_usuario=@nome AND senha=@senha";
                    command.Parameters.Add(new SqlParameter("nome", System.Data.SqlDbType.VarChar)).Value=usuario.nome;
                    command.Parameters.Add(new SqlParameter("senha", System.Data.SqlDbType.VarChar)).Value = usuario.senha;

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        
                        result.Sucesso = dr.Read();

                        if (result.Sucesso)
                        {
                            result.Id = (int)dr["id_usuario"];
                            result.TipoUsuario = dr["nivel"].ToString();

                            usuario.idUsuario = result.Id;
                            niveis.nivel = result.TipoUsuario;
                        }
                    }
                }
            }
            return result;
        }


    }
}
