using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec.Contexts;
using Bibliotec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bibliotec.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        Context context = new Context();

        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form){
           string emailInformado = form["Email"];
           string senhaInformado = form["Senha"];


           //Busca no banco de dados
           Usuario usuarioBuscado = context.Usuario.FirstOrDefault(usuario => usuario.Email == emailInformado && usuario.Senha == senhaInformado)!;

        //    //De outra Forma:
        //    //criei uma lista de usuarios
        //    List<Usuario> listaUsuario = context.Usuario.ToList();

        //    foreach(Usuario usuario_ in listaUsuario){
        //     if(usuario_.Email == emailInformado && usuario_.Senha == senhaInformado){
        //     //usuario logado
        //    }else{
        //     //usuario nao encontrado
        //    }

        //se meu usuario buscado for igual a nulo
        if(usuarioBuscado == null){
            Console.WriteLine($"Dados inválidos !");
            return LocalRedirect("~/Login");
        }else{
            Console.WriteLine($"Eba voce entrou!");
            HttpContext.Session.SetString("edzinho",usuarioBuscado.
            UsuarioID.ToString());
              HttpContext.Session.SetString("Admin",usuarioBuscado.Admin.
            ToString());
            return LocalRedirect("~/Livro");
            
        }

        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}