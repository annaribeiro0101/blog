using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PWABlog.Models.Blog.Etiqueta
{
    public class EtiquetaOrmService
    {
        private readonly DatabaseContext _databaseContext;

        

        public List<EtiquetaEntity> ObterEtiquetas()
        {
            return _databaseContext.Etiquetas
                .Include(e => e.Categoria)
                .ToList();
        }

        public EtiquetaEntity ObterEtiquetaPorId(int idEtiqueta)
        {
            var etiqueta = _databaseContext.Etiquetas.Find(idEtiqueta);

            return etiqueta;
        }

        public List<EtiquetaEntity> PesquisarEtiquetasPorNome(string nomeEtiqueta)
        {
            return _databaseContext.Etiquetas.Where(c => c.Nome.Contains(nomeEtiqueta)).ToList();
        }

        public EtiquetaEntity CriarEtiqueta(string nome, int idCategoria)
        {
             
            if (nome == null)
            {
                throw new Exception("A Etiqueta precisa de um nome!");
            }

            
            var categoria = _databaseContext.Categorias.Find(idCategoria);
            if (categoria == null)
            {
                throw new Exception("A Categoria informada para a Etiqueta não foi encontrada!");
            }

             
            var novaEtiqueta = new EtiquetaEntity
            {
                Nome = nome,
                Categoria = categoria
            };
            _databaseContext.Etiquetas.Add(novaEtiqueta);
            _databaseContext.SaveChanges();

            return novaEtiqueta;
        }

        public EtiquetaEntity EditarEtiqueta(int id, string nome, int idCategoria)
        {
            
            var etiqueta = _databaseContext.Etiquetas.Find(id);
            if (etiqueta == null)
            {
                throw new Exception("Etiqueta não encontrada!");
            }

             
            var categoria = _databaseContext.Categorias.Find(idCategoria);
            if (categoria == null)
            {
                throw new Exception(" Não foi encontrada!");
            }

            
            etiqueta.Nome = nome;
            etiqueta.Categoria = categoria;
            _databaseContext.SaveChanges();

            return etiqueta;
        }

       
    }
}
