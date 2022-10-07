using System.Diagnostics;
using AtividadeSA3MVC.Models;

namespace AtividadeSA3MVC.services
{

    public class Repositorio
    {
        public static string Caminho()
        {
            string path = Directory.GetCurrentDirectory();
            var resultado = path.Split("\\bin\\Debug\\net6.0");
            var caminho = resultado[0] + @"\Dados\pessoa.txt";
            return caminho;
        }
        public void Gravar(Pessoa pessoa)
        {
            var arquivo = File.Exists(Caminho());
            if (arquivo == false)
            {
                using (var criaArquivo = new StreamWriter(Caminho()))
                {
                    criaArquivo.WriteLine("Nome,Idade");
                }
            }
            var escreva = File.AppendText(Caminho());
            escreva.WriteLine($"{pessoa.Nome},{pessoa.idade}");
            escreva.Close();

        }
        public List<Pessoa> Ler()
        {
            List<Pessoa> registroPessoa = new List<Pessoa>();
            Pessoa pessoa = new Pessoa();
            
            var checar = File.Exists(Caminho());
            if(checar == false)
            {
                using (var criaArquivo = new StreamWriter(Caminho()))
                {
                    criaArquivo.WriteLine("Id,Nome,Idade");
                }
            }
            using StreamReader ler = new StreamReader(Caminho());
            var texto = ler.ReadLine();
            string[] linhas = File.ReadAllLines(Caminho());
            int count = 0;
            foreach (var linha in linhas)
            {
                if (linha.Contains("Nome")) 
                {
                    continue;
                }
                else 
                {               
                    char delimitador = ',';
                    var teste = linha.Split(delimitador);
                    pessoa.Nome = teste[0];
                    pessoa.idade = int.Parse(teste[1]);
                    registroPessoa.Add(new Pessoa(pessoa.Nome,pessoa.idade));
                    
                    count = count + 1;
                }
            }
            return registroPessoa;
        }
    }
}
