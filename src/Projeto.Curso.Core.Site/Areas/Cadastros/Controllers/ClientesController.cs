using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Projeto.Curso.Core.Application.Pedido.Interfaces;
using Projeto.Curso.Core.Application.Pedido.ViewModels;
using Projeto.Curso.Core.Application.Shared.Intefaces;

namespace Projeto.Curso.Core.Site.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class ClientesController : CadastroBaseController
    {

        private readonly IApplicationClientes appclientes;
        private readonly IApplicationShared appshared;

        public ClientesController(IApplicationClientes _appclientes,
                                  IApplicationShared _appshared)
        {
            appclientes = _appclientes;
            appshared = _appshared;
        }

        [Route("Pedidos-Clientes-Listagem")]
        public IActionResult Index()
        {
            ViewBag.RetornoPost = TempData["RetornoPost"];
            return View();
        }

        public JsonResult ListagemClientesJson()
        {
            var lista = appclientes.ObterTodos();
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        }

        [Route("Pedidos-Clientes-Incluir")]
        public IActionResult Incluir()
        {
            ViewBag.ListaEstados = appshared.ObterEstados();
            return View();
        }

        [Route("Pedidos-Clientes-Incluir")]
        [HttpPost]
        public IActionResult Incluir(ClientesViewModel model)
        {
            ViewBag.ListaEstados = appshared.ObterEstados();
            if (!ModelState.IsValid) return View();
            var cliente = appclientes.Adicionar(model);
            ViewBag.RetornoPost = "success,Cliente incluído com sucesso!";
            if (VerificaErros(cliente.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível incluir o cliente!";
            }
            return View(model);
        }

        [Route("Pedidos-Clientes-Alterar")]
        public IActionResult Alterar(int id)
        {
            ViewBag.ListaEstados = appshared.ObterEstados();
            var model = appclientes.ObterPorId(id);
            return View(model);
        }

        [Route("Pedidos-Clientes-Alterar")]
        [HttpPost]
        public IActionResult Alterar(ClientesViewModel model)
        {
            ViewBag.ListaEstados = appshared.ObterEstados();
            if (!ModelState.IsValid) return View();
            var cliente = appclientes.Atualizar(model);
            ViewBag.RetornoPost = "success,Cliente alerado com sucesso!";
            if (VerificaErros(cliente.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível alterar o cliente!";
            }
            return View(model);
        }

        [Route("Pedidos-Clientes-Detalhar")]
        public IActionResult Detalhar(int id)
        {
            var model = appclientes.ObterPorId(id);
            return View(model);
        }

        [Route("Pedidos-Clientes-Excluir")]
        public IActionResult Excluir(int id)
        {
            var model = appclientes.ObterPorId(id);
            return View(model);
        }

        [Route("Pedidos-Clientes-Excluir")]
        [HttpPost]
        public IActionResult Excluir(ClientesViewModel model)
        {
            var cliente = appclientes.Remover(model);
            TempData["RetornoPost"] = "success,Cliente excluído com sucesso!";
            if (VerificaErros(cliente.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível excluir o cliente!";
                return View(model);
            }
            return RedirectToAction("Index");
        }

    }
}