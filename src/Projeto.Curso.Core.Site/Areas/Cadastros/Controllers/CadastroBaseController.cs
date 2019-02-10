using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Projeto.Curso.Core.Site.Areas.Cadastros.Controllers
{
    public class CadastroBaseController : Controller
    {
        public bool VerificaErros(List<string> Erros)
        {
            if (Erros.Any())
            {
                ViewBag.ListaErros = Erros;
                return true;
            }
            return false;
        }

    }
}