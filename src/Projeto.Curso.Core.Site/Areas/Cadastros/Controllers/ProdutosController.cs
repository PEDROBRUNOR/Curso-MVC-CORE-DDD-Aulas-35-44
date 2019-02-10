using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Projeto.Curso.Core.Application.Pedido.Interfaces;
using Projeto.Curso.Core.Application.Pedido.ViewModels;
using System.IO;
using System.Net.Mime;

namespace Projeto.Curso.Core.Site.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class ProdutosController : CadastroBaseController
    {
        private readonly IApplicationProdutos appprodutos;
        private readonly IApplicationFornecedores appfornecedores;

        public ProdutosController(IApplicationProdutos _appprodutos,
                                  IApplicationFornecedores _appfornecedores)
        {
            appprodutos = _appprodutos;
            appfornecedores = _appfornecedores;
        }


        [Route("Pedidos-Produtos-Listagem")]
        public IActionResult Index()
        {
            ViewBag.RetornoPost = TempData["RetornoPost"];
            return View();
        }

        public JsonResult ListagemProdutosJson()
        {
            var lista = appprodutos.ObterTodos();
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        }

        [Route("Pedidos-Produtos-Incluir")]
        public IActionResult Incluir()
        {
            ViewBag.ListaFornecedores = new SelectList(appfornecedores.ObterTodos(), "Id", "Apelido", "-- Selecione --");
            return View();
        }

        [HttpPost]
        [Route("Pedidos-Produtos-Incluir")]
        public IActionResult Incluir(ProdutosViewModel model, IFormFile fileSelect)
        {
            ViewBag.ListaFornecedores = new SelectList(appfornecedores.ObterTodos(), "Id", "Apelido", "-- Selecione --");
            if (!ModelState.IsValid) return View();

            if (fileSelect != null && !string.IsNullOrEmpty(fileSelect.FileName))
            {
                string extension = Path.GetExtension(fileSelect.FileName).ToUpper();
                if (extension == ".JPG" || extension == ".PNG" || extension == ".BMP")
                {
                    MemoryStream ms = new MemoryStream();
                    fileSelect.OpenReadStream().CopyTo(ms);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                    model.Foto = ms.ToArray();
                }
            }

            var cliente = appprodutos.Adicionar(model);
            ViewBag.RetornoPost = "success,Produto incluído com sucesso!";
            if (VerificaErros(cliente.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível incluir o produto!";
            }
            return View(model);
        }

        [Route("Pedidos-Produtos-Alterar")]
        public IActionResult Alterar(int id)
        {
            ViewBag.ListaFornecedores = new SelectList(appfornecedores.ObterTodos(), "Id", "Apelido", "-- Selecione --");
            var model = appprodutos.ObterPorId(id);
            return View(model);
        }

        [HttpPost]
        [Route("Pedidos-Produtos-Alterar")]
        public IActionResult Alterar(ProdutosViewModel model, IFormFile fileSelect)
        {
            ViewBag.ListaFornecedores = new SelectList(appfornecedores.ObterTodos(), "Id", "Apelido", "-- Selecione --");
            if (!ModelState.IsValid) return View();

            if (fileSelect != null && !string.IsNullOrEmpty(fileSelect.FileName))
            {
                string extension = Path.GetExtension(fileSelect.FileName).ToUpper();
                if (extension == ".JPG" || extension == ".PNG" || extension == ".BMP")
                {
                    MemoryStream ms = new MemoryStream();
                    fileSelect.OpenReadStream().CopyTo(ms);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                    model.Foto = ms.ToArray();
                }
            }

            var cliente = appprodutos.Atualizar(model);
            ViewBag.RetornoPost = "success,Produto alterado com sucesso!";
            if (VerificaErros(cliente.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível alterar o produto!";
            }
            return View(model);
        }


        [Route("Pedidos-Produtos-Detalhar")]
        public IActionResult Detalhar(int id)
        {
            ViewBag.ListaFornecedores = new SelectList(appfornecedores.ObterTodos(), "Id", "Apelido", "-- Selecione --");
            var model = appprodutos.ObterPorId(id);
            return View(model);
        }

        [Route("Pedidos-Produtos-Excluir")]
        public IActionResult Excluir(int id)
        {
            ViewBag.ListaFornecedores = new SelectList(appfornecedores.ObterTodos(), "Id", "Apelido", "-- Selecione --");
            var model = appprodutos.ObterPorId(id);
            return View(model);
        }

        [HttpPost]
        [Route("Pedidos-Produtos-Excluir")]
        public IActionResult Excluir(ProdutosViewModel model)
        {
            var produtos = appprodutos.Remover(model);
            TempData["RetornoPost"] = "success,Produto excluído com sucesso!";
            if (VerificaErros(produtos.ListaErros))
            {
                ViewBag.RetornoPost = "error,Não foi possível excluir o produto!";
                return View(model);
            }
            return RedirectToAction("Index");
        }


        public IActionResult GetFoto(int id)
        {
            var model = appprodutos.ObterPorId(id);
            Stream stream = new MemoryStream(model.Foto);
            return new FileStreamResult(stream, MediaTypeNames.Image.Jpeg);
        }


    }
}