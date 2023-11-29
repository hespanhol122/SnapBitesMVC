using static System.Net.Mime.MediaTypeNames;

namespace Snapbites.Models
{

    public class Endereco
    {
        public int idEndereco { get; set; }
        public string logradouro { get; set; }
        public string cep { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }

        public int idUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        /*private void LocalizarCEP()
        {
            if (!string.isNullOrWhiteSpace(txtCep.Text))
            {
                Addres endereco SearchZip.GetAddres(txt.Cep.Text);
                if (endereco.Zip != null)
                {
                    this.estado = endereco.state;
                    this.cidade = endereco.City;
                    this.bairro = endereco.District;
                    this.logradouro = endereci.street;
                }
                else
                {
                    Console.WriteLine("Cep Não localizado... ")
                }
            }
            else
            {
                Console.WriteLine("Informe um Cep válido")
            }

        }
        */

    }
}