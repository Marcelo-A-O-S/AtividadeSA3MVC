using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AtividadeSA3MVC.Models;
using AtividadeSA3MVC.services;

namespace AtividadeSA3MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Repositorio db = new Repositorio();
            //var resultado = db.Ler();

            return View();
        }

        public IActionResult Listar()
        {
            Repositorio db = new Repositorio();
            var resultado = db.Ler();

            return View(resultado);
        }
        public IActionResult Cadastrar(Pessoa pessoa)
        {
            return View();
        }
        public ActionResult Salvar(Pessoa pessoa)
        {
            Repositorio db = new Repositorio();
            Pessoa pessoa1 = new Pessoa();
            pessoa1.Nome = pessoa.Nome;
            pessoa1.idade = pessoa.idade;
            db.Gravar(pessoa1);
            return NoContent();

        }
        public IActionResult Desenvolvedor()
        {
            return View(); 
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}