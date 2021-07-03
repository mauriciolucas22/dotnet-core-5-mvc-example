using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace dotnet_mvc.Controllers
{
    [Route("auth")] // nome da rota
    public class AdminController : Controller
    {
        [HttpGet("content/{name}")] // uri
        public IActionResult Index(string name)
        {
            return Content("Jesus " + name);
        }

        [HttpGet("numeros/{number:int}")] // uri
        //[HttpGet("numeros/{number:int?}")] // ? fica opcional
        public IActionResult Numbers(string number)
        {
            return Content("Numero " + number);
        }

        [HttpGet("query")]
        public IActionResult QueryString()
        {
            var value = Request.Query["value"];
            return Content("Value: " + value);
        }

        [HttpGet("view")]
        public IActionResult MyView()
        {
            ViewData["hello"] = "Mauricio";
            return View();
        }

        [HttpGet("outra_view")]
        public IActionResult OtherView()
        {
            ViewData["hello"] = "Mauricio";
            return View("nd");
        }

        [HttpGet("form")]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost("data")]
        public IActionResult Data()
        {
            StringValues email;
            Request.Form.TryGetValue("email", out email);
            return Content("Form enviado para " + email);
        }
    }
}