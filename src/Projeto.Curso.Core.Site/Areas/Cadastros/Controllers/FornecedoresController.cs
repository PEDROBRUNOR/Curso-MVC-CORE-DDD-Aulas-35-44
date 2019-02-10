using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projeto.Curso.Core.Application.Pedido.Interfaces;
using Projeto.Curso.Core.Application.Pedido.ViewModels;
using Projeto.Curso.Core.Application.Shared.Intefaces;

namespace Projeto.Curso.Core.Site.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class FornecedoresController : CadastroBaseController
    {
        private readonly IApplicationFornecedores appfornecedor;
        private readonly IApplicationShared appshared;

        public FornecedoresController(IApplicationFornecedores _appfornecedor,
                                      IApplicationShared _appshared)
        {
            appfornecedor = _appfornecedor;
            appshared = _appshared;
        }

        [Route("Pedidos-Fornecedores-Listagem")]
        public IActionResult Index()
        {
            ViewBag.RetornoPost = TempData["RetornoPost"];
            return View();
        }

        public JsonResult ListagemFornecedoresJson()
        {
            var lista = appfornecedor.ObterTodos();
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        }

        [Route("Pedidos-Fornecedores-Incluir")]
        public IActionResult Incluir()
        {
            ViewBag.ListaEstados = appshared.ObterEstados();
            return View();
        }

        [Route("Pedidos-Fornecedores-Incluir")]
        [HttpPost]
        public IActionResult Incluir(FornecedoresViewModel model)
        {
            ViewBag.ListaEstados = appshared.ObterEstados();
            if (!ModelState.IsValid) return View();
            var cliente = appfornecedor.Adicionar(model);
            ViewBag.RetornoPost = "success,Fornecedor incluído com sucesso!";
            if (VerificaErros(cliente.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível incluir o fornecedor!";
            }
            return View(model);
        }


        [Route("Pedidos-Fornecedores-Alterar")]
        public IActionResult Alterar(int id)
        {
            ViewBag.ListaEstados = appshared.ObterEstados();
            var model = appfornecedor.ObterPorId(id);
            return View(model);
        }

        [Route("Pedidos-Fornecedores-Alterar")]
        [HttpPost]
        public IActionResult Alterar(FornecedoresViewModel model)
        {
            ViewBag.ListaEstados = appshared.ObterEstados();
            if (!ModelState.IsValid) return View();
            var cliente = appfornecedor.Atualizar(model);
            ViewBag.RetornoPost = "success,Fornecedor alerado com sucesso!";
            if (VerificaErros(cliente.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível alterar o fornecedor!";
            }
            return View(model);
        }

        [Route("Pedidos-Fonrecedores-Detalhar")]
        public IActionResult Detalhar(int id)
        {
            var model = appfornecedor.ObterPorId(id);
            return View(model);
        }

        [Route("Pedidos-Fornecedores-Excluir")]
        public IActionResult Excluir(int id)
        {
            var model = appfornecedor.ObterPorId(id);
            return View(model);
        }

        [Route("Pedidos-Fornecedores-Excluir")]
        [HttpPost]
        public IActionResult Excluir(FornecedoresViewModel model)
        {
            var fornecedor = appfornecedor.Remover(model);
            TempData["RetornoPost"] = "success,Fornecedor excluído com sucesso!";
            if (VerificaErros(fornecedor.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível excluir o fornecedor!";
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}