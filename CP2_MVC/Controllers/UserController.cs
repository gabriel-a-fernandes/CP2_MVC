using CP2_MVC.Data;
using CP2_MVC.DTOs;
using Microsoft.AspNetCore.Mvc;
using CP2_MVC.Models;

namespace CP2_MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Register(RegisterDTO request)
        {
            var user = _dataContext.PZ_Users.FirstOrDefault(x => x.UserEmail == request.UserEmail);
            if (user != null)
            {
                return BadRequest("Usuário ja existe");
            }
            User newUser = new User
            {
                UserEmail = request.UserEmail,
                UserName = request.UserName,
                UserPassword = request.UserPassword,
                UserPhone = request.UserPhone,
            };
            _dataContext.Add(newUser);
            _dataContext.SaveChanges();
            return View();
        }


        public IActionResult Login(LoginDTO request)
        {
            var find = _dataContext.PZ_Users.FirstOrDefault(x => x.UserEmail == request.UserEmail);
            if (find == null)
            {
                return NotFound();
            }
            if (find.UserPassword != request.UserPassword)
            {
                return BadRequest("Senha inválida");
            }
            ViewBag.userData = find;
            return View(find);
        }


    }
}
