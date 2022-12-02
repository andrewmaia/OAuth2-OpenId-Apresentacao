using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [Route("contato")]
    public class ContatoController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            List<Contato> contatos = new List<Contato> ();
            contatos.Add(new Contato { Nome="José", Telefone="11111111" });
            contatos.Add(new Contato { Nome = "Maria", Telefone = "222222222" });

            return new JsonResult(from c in contatos select new { c.Nome, c.Telefone });
        }
    }

    public class Contato
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }

    }
}

