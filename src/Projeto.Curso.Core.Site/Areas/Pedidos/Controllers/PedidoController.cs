using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Projeto.Curso.Core.Application.Pedido.Interfaces;
using Projeto.Curso.Core.Application.Pedido.Interfaces.AgregracaoPedidos;

namespace Projeto.Curso.Core.Site.Areas.Pedidos.Controllers
{
    [Area("Pedidos")]
    public class PedidoController : Controller
    {
        private readonly IApplicationPedidos apppedidos;
        private readonly IApplicationClientes appclientes;
        private readonly IApplicationProdutos appprodutos;

        public PedidoController(IApplicationPedidos _apppedidos,
                                IApplicationClientes _appclientes,
                                IApplicationProdutos _appprodutos)
        {
            apppedidos = _apppedidos;
            appclientes = _appclientes;
            appprodutos = _appprodutos;
        }

        [Route("Pedidos-Cadastro-Listagem")]
        public IActionResult Index()
        {
            ViewBag.RetornoPost = TempData["RetornoPost"];
            return View();
        }

        public JsonResult ListagemPedidosJson()
        {
            var lista = apppedidos.ObterListagemPedidos();
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        }

        [Route("Pedidos-Cadastro-Incluir")]
        public IActionResult Incluir()
        {
            ViewBag.ListaClientes = new SelectList(appclientes.ObterTodos(), "Id", "Apelido", "-- Selecione --");
            ViewBag.ListaProdutos = new SelectList(appprodutos.ObterTodos(), "Id", "Apelido", "-- Selecione --");
            return View();
        }




    }
}