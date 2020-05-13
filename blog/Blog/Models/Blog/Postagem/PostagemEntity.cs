using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem.Revisao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]

        public string  Titulo { get; set; }
        public AutorEntity Autor { get; set; }
        public CategoriaEntity Categoria { get; set; }
        // public List<EtiquetaEntity> Etiquetas;
        // public List<RevisaoEntity> Revisoes { get; set; }

    }
}
