using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace AluraTunes
{

    static class Program
    {
        public static AppDbContext _context = new AppDbContext();
        static void Main(string[] args)
        {

            var query = from l in _context.Lanches
                        where l.Nome.Contains("c")
                        group l by l.Nome into agrupado
                        select agrupado.Key;

            //foreach (var item in query)
            //{
            //    if (textoBuscar != null)
            //    {
            //        Console.WriteLine(item.Nome);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Lanche Não encontrado");
            //    }
            //}

            Console.WriteLine(query);
        

        }

        public static void ContarQuantidadeItens()
        {
            var query = from l in _context.Lanches
                        where l.Nome.Contains("C")
                        select l;

            var quantidade = _context.Lanches.Count(a => a.Nome.Contains("a"));

            Console.WriteLine(quantidade);

        }


        public static void Filtro2()
        {
            var query = from l in
                            _context.Lanches select l;

            foreach (var item in query)
            {

                Console.WriteLine(item.LancheId + "" + item.Nome);
            }

            Console.ReadKey();

        }
        public static void Filtrando()
        {
            Console.WriteLine("Digite o Texto:");
            var textoBuscar = Console.ReadLine();

            var query = from l in _context.Lanches
                        where l.Nome.Contains(textoBuscar)
                        select l;

            foreach (var item in query)
            {
                if (textoBuscar != null)
                {
                    Console.WriteLine(item.Nome);
                }
                else
                {
                    Console.WriteLine("Lanche Não encontrado");
                }
            }

            Console.ReadKey();
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
