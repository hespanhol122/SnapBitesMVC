using Snapbites.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace Snapbites.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider(); // não esquecer de colocar using System.Security.Cryptography;
        
        
        public int idUsuario { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public int atividade { get; set; }

        // Define o relacionamento com a classe niveis abaixo:

        public int idNivel { get; set; }
        public Niveis Niveis { get; set; }

        public int idGenero { get; set; }
        public Genero Genero { get; set; }

        public List<Imagem> rImagem { get; set; }

        public List<perfilUsuario> rPerfilUsuario { get; set; }

        public List<Comentario> rComentario { get; set; }

        public List<Endereco> rEndereco { get; set; }

        public List<interessesUsuario> rInteressesUsuario { get; set; }

        public void Criptografar(string senha)
        {
            this.senha = senha;

            byte[] salt = new byte[16];
            rngCsp.GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 1000);

            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string hashSenha = Convert.ToBase64String(hashBytes);
        }
    }
}