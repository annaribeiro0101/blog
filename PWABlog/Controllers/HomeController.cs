﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PWABlog.Models;
using PWABlog.Models.Blog.Categoria;
using PWABlog.Models.Blog.Etiqueta;
using PWABlog.Models.Blog.Postagem;
using PWABlog.Models.Blog.Postagem.Revisao;
using PWABlog.ViewModels.Home;

namespace PWABlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CategoriaOrmService _categoriaOrmService;
        private readonly PostagemOrmService _postagemOrmService;

        public HomeController(
            ILogger<HomeController> logger,
            CategoriaOrmService categoriaOrmService,
            PostagemOrmService postagemOrmService
        ){
            _logger = logger;
            _categoriaOrmService = categoriaOrmService;
            _postagemOrmService = postagemOrmService;
        }

        public IActionResult Index()
        {   
             HomeIndexViewModel model = new HomeIndexViewModel();
            model.TituloPagina = "Página Home";
            
             List<PostagemEntity> listaPostagens = _postagemOrmService.ObterPostagens();
            
            foreach (PostagemEntity postagem in listaPostagens)
            {
                PostagemHomeIndex postagemHomeIndex = new PostagemHomeIndex();
                postagemHomeIndex.Titulo = postagem.Titulo;
                postagemHomeIndex.Descricao = postagem.Descricao;
                postagemHomeIndex.Categoria = postagem.Categoria.Nome;
                postagemHomeIndex.NumeroComentarios = postagem.Comentarios.Count.ToString();
                postagemHomeIndex.PostagemId = postagem.Id.ToString();
                
                 RevisaoEntity ultimaRevisao = postagem.Revisoes.OrderByDescending(o => o.DataCriacao).FirstOrDefault();
                if (ultimaRevisao != null)
                {
                    postagemHomeIndex.Data = ultimaRevisao.DataCriacao.ToLongDateString();
                }
                
                model.Postagens.Add(postagemHomeIndex);
            }

             List<CategoriaEntity> listaCategorias = _categoriaOrmService.ObterCategorias();

            foreach (CategoriaEntity categoria in listaCategorias)
            {
                CategoriaHomeIndex categoriaHomeIndex = new CategoriaHomeIndex();
                categoriaHomeIndex.Nome = categoria.Nome;
                categoriaHomeIndex.CategoriaId = categoria.Id.ToString();
                
                model.Categorias.Add(categoriaHomeIndex);
            
                 foreach (EtiquetaEntity etiqueta in categoria.Etiquetas)
                {
                    EtiquetaHomeIndex etiquetaHomeIndex = new EtiquetaHomeIndex();
                    etiquetaHomeIndex.Nome = etiqueta.Nome;
                    etiquetaHomeIndex.EtiquetaId = etiqueta.Id.ToString();
                
                    model.Etiquetas.Add(etiquetaHomeIndex);
                }
            }

             List<PostagemEntity> listaPostagensPopulares = _postagemOrmService.ObterPostagensPopulares();
            int count = 0;
            foreach (PostagemEntity postagem in listaPostagensPopulares)
            {
                PostagemPopularHomeIndex postagemPopularHomeIndex = new PostagemPopularHomeIndex();
                postagemPopularHomeIndex.Titulo = postagem.Titulo;
                postagemPopularHomeIndex.Categoria = postagem.Categoria.Nome;
                postagemPopularHomeIndex.PostagemId = postagem.Id.ToString();

                count++;

                if (count <= 4)
                {
                    model.PostagensPopulares.Add(postagemPopularHomeIndex);
                }
            }
            
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}