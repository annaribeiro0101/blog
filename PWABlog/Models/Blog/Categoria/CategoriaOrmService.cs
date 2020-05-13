using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PWABlog.Models.Blog.Categoria
{
    public class CategoriaOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public CategoriaOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<CategoriaEntity> ObterCategorias()
        {
            // INÍCIO DOS EXEMPLOS
            
            /**********************************************************************************************************/
            /*** OBTER UM ÚNICO OBJETO                                                                                */
            /**********************************************************************************************************/
            
            var primeiraCategoria = _databaseContext.Categorias.First();
            
            var primeiraCategoriaOuNulo = _databaseContext.Categorias.FirstOrDefault();

            var algumaCategoriaEspecifica = _databaseContext.Categorias.Single(c => c.Id == 3);
            
            var algumaCategoriaOuNulo = _databaseContext.Categorias.SingleOrDefault(c => c.Id == 3);
            
            var encontrarCategoria = _databaseContext.Categorias.Find(3);
            
        
            var todasCategorias = _databaseContext.Categorias.ToList();
            
         

            var categoriasComALetraG = _databaseContext.Categorias.Where(c => c.Nome.StartsWith("G")).ToList();
            var categoriasComALetraMouL = _databaseContext.Categorias
                .Where(c => c.Nome.StartsWith("M") || c.Nome.StartsWith("L"))
                .ToList();
            
            
         

            var categoriasEmOrdemAlfabetica = _databaseContext.Categorias.OrderBy(c => c.Nome).ToList();
            var categoriasEmOrdemAlfabeticaInversa = _databaseContext.Categorias.OrderByDescending(c => c.Nome).ToList();
            
          
            var categoriasESuasEtiquetas = _databaseContext.Categorias
                .Include(c => c.Etiquetas)
                .ToList();
                
            var categoriasSemEtiquetas = _databaseContext.Categorias
                .Where(c=> c.Etiquetas.Count == 0)
                .ToList();
            
            var categoriasComEtiquetas = _databaseContext.Categorias
                .Where(c=> c.Etiquetas.Count > 0)
                .ToList();
            
            
            
            
            // Código de fato necessário para o método
            return _databaseContext.Categorias
                .Include(c => c.Etiquetas)
                .ToList();
        }

        public CategoriaEntity ObterCategoriaPorId(int idCategoria)
        {
            var categoria = _databaseContext.Categorias.Find(idCategoria);

            return categoria;
        }

        public List<CategoriaEntity> PesquisarCategoriasPorNome(string nomeCategoria)
        {
            return _databaseContext.Categorias.Where(c => c.Nome.Contains(nomeCategoria)).ToList();
            
        }

        public CategoriaEntity CriarCategoria(string nome)
        {
            var novaCategoria = new CategoriaEntity { Nome = nome };
            _databaseContext.Categorias.Add(novaCategoria);
            _databaseContext.SaveChanges();

            return novaCategoria;
        }

        public CategoriaEntity EditarCategoria(int id, string nome)
        {
            var categoria = _databaseContext.Categorias.Find(id);

            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada!");
            }

            categoria.Nome = nome;
            _databaseContext.SaveChanges();

            return categoria;
        }

        public bool RemoverCategoria(int id)
        {
            var categoria = _databaseContext.Categorias.Find(id);

            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada!");
            }

            _databaseContext.Categorias.Remove(categoria);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}