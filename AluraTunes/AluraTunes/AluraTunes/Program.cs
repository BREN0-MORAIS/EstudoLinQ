using Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace AluraTunes
{
  
    static class  Program
    {
        public static  AppDbContext _context = new AppDbContext();
        static void Main(string[] args)
        {
           

             

        }

        public static void ConsultasComJoin()
        {
            //_context.Database.Log = Console.WriteLine();

            var query = from c in _context.Categorias select c;

            foreach (var categoria in query)
            {
                Console.WriteLine("{0}\t{1}", categoria.CategoriaId, categoria.Descricao);
            }

            var LanchesCategoria = from l in _context.Lanches
                                   join c in _context.Categorias
                                   on l.LancheId equals c.CategoriaId
                                   select new { l, c };

            Console.WriteLine();
            foreach (var item in LanchesCategoria)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", item.l.Nome, item.l.Preco,
                                 item.c.CategoriaNome, item.c.Descricao);
            }

            Console.WriteLine();
            var NLanchesCategoria = from l in _context.Lanches
                                    join c in _context.Categorias
                                    on l.CategoriaId equals c.CategoriaId
                                    select new
                                    {
                                        CategoriaId = c.CategoriaId,
                                        CategoriaNome = c.CategoriaNome,
                                        LancheId = l.LancheId,
                                        LancheNome = l.Nome
                                    };

            foreach (var item in NLanchesCategoria)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", item.CategoriaId, item.CategoriaNome, item.LancheId, item.LancheNome);
            }

        }
    }
}
