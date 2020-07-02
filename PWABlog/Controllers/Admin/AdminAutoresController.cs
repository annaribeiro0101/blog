using Microsoft.AspNetCore.Mvc;
using PWABlog.Models.Blog.Autor;
using PWABlog.RequestModels.AdminAutores;
using PWABlog.ViewModels.Admin;
using System;

namespace PWABlog.Controllers.Admin
{
    public class AdminAutoresController : Controller
    {
        private readonly AutorOrmService _autoresOrmService;

        public AdminAutoresController(
            AutorOrmService autoresOrmService
        )
        {
            _autoresOrmService = autoresOrmService;
        }

        [HttpGet]
        
        public IActionResult Listar()
        {
            AdminAutoresListarViewModel model = new AdminAutoresListarViewModel();

            var listaAutores = _autoresOrmService.ObterAutores();

            foreach (var autoresEntity in listaAutores)
            {
                var autorAdminAutores = new AutorAdminAutores();
                autorAdminAutores.Id = autoresEntity.Id;
                autorAdminAutores.Nome = autoresEntity.Nome;

                model.autores.Add(autorAdminAutores);
            }

            return View(model);
        }

        [HttpGet]
        
        public IActionResult Detalhar(int id)
        {
            return View();
        }

        [HttpGet]
       
        public IActionResult Criar()
        {
            AdminAutoresCriarViewModel model = new AdminAutoresCriarViewModel();

            model.Erro = (string)TempData["erro-msg"];

            return View(model);
        }

        [HttpPost]
        
        public RedirectToActionResult Criar(AdminAutoresCriarRequestModel request)
        {
            var nome = request.Nome;

            try
            {
                _autoresOrmService.CriarAutor(nome);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Criar");
            }

            return RedirectToAction("Listar");
        }

        [HttpGet]
        
        public IActionResult Editar(int id)
        {
            AdminAutoresEditarViewModel model = new AdminAutoresEditarViewModel();

            
            var autorAEditar = _autoresOrmService.ObterAutorPorId(id);
            if (autorAEditar == null)
            {
                return RedirectToAction("Listar");
            }

           model.Erro = (string)TempData["erro-msg"];

            model.IdAutor = autorAEditar.Id;
            model.NomeAutor = autorAEditar.Nome;
            model.TituloPagina += model.NomeAutor;

            return View(model);
        }

        [HttpPost]
        
        public RedirectToActionResult Editar(AdminAutoresEditarRequestModel request)
        {
            var id = request.Id;
            var nome = request.Nome;

            try
            {
                _autoresOrmService.EditarAutor(id, nome);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Editar", new { id = id });
            }

            return RedirectToAction("Listar");
        }

        [HttpGet]
       
        public IActionResult Remover(int id)
        {
            AdminAutoresRemoverViewModel model = new AdminAutoresRemoverViewModel();

            
            var ARemover = _autoresOrmService.ObterAutorPorId(id);
            if (ARemover == null)
            {
                return RedirectToAction("Listar");
            }

           
            model.Erro = (string)TempData["erro-msg"];

            
            model.IdAutor = ARemover.Id;
            model.NomeAutor = ARemover.Nome;
            model.TituloPagina += model.NomeAutor;

            return View(model);
        }

        [HttpPost]
        
        public RedirectToActionResult Remover(AdminAutoresRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _autoresOrmService.RemoverAutor(id);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Remover", new { id = id });
            }

            return RedirectToAction("Listar");
        }
    }
}

