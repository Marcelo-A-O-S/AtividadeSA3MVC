using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace AtividadeSA3MVC.Models
{
    public class Pessoa
    {
        private Pessoa pessoa;

        public Pessoa(string nome, int Idade)
        {

            this.Nome = nome;
            this.idade = Idade;
        }
        public Pessoa() 
        {
            
        }
        //[Key]
        //public int Id { get; set; }
        public string Nome { get; set; }
        public int idade { get; set; }
    }
}
