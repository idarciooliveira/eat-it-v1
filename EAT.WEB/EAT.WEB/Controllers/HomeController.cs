using EAT.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EAT.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public HomeController(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }
        

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var funcionarios = _funcionarioRepositorio.GetAll();
            return View(funcionarios);
        }

        public IActionResult Contact()
        {
            var funcionarios = _funcionarioRepositorio.GetAll();

            return View(funcionarios);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
