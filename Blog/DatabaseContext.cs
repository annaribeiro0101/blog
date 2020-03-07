using Blog.Models.Blog.Categoria;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog
{
    public class DatabaseContext : DbContext
    {
        public DbSet<CategoriaEntity> categoriaEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql("server=localhost;User=root;password=123456;Database=Blog");
        }
    }
}
