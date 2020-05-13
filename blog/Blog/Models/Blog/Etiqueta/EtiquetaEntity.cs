using Blog.Models.Blog.Postagem.Revisao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Etiqueta
{
    public class EtiquetaEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        [Required]
        public string Nome { get; set; }
        
        [MaxLength(128)]
        [Required]
        public string Cor { get; set; }


        public EtiquetaEntity(string nome, string cor = "light-grey") {
            Nome = nome;
            Cor = cor;
        }
    }
}
