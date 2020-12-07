using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluraTunes
{
    class Select_where_join
    {
        public void Consultas()
        {
            var generos = new List<Genero>
            {
                new Genero{Id = 1 , Nome = "Rock"},
                new Genero{Id = 2 , Nome = "Breno"},
                new Genero{Id = 3 , Nome = "Roberto Rock"},
                new Genero{Id = 4 , Nome = "Aline"},
                new Genero{Id = 5 , Nome = "Gabriela Rock"},
                new Genero{Id = 6 , Nome = "Gaby"},
                new Genero{Id = 7 , Nome = "Alesandra"},
                new Genero{Id = 8 , Nome = "Mario"},
                new Genero{Id = 9 , Nome = "Sonic Rock"},
                new Genero{Id = 10 , Nome = "Tony"},
                new Genero{Id = 11, Nome = "Paulo"}
            };

            var musicas = new List<Musica>
            {
                new Musica{Id = 1 , Nome = "Rock", GeneroId = 1},
                new Musica{Id = 2 , Nome = "Breno", GeneroId = 1},
                new Musica{Id = 3 , Nome = "Roberto Rock", GeneroId = 2},
                new Musica{Id = 4 , Nome = "Aline", GeneroId = 2},
                new Musica{Id = 5 , Nome = "Gabriela Rock", GeneroId = 3},
                new Musica{Id = 6 , Nome = "Gaby", GeneroId = 3},
                new Musica{Id = 7 , Nome = "Alesandra", GeneroId = 3},
                new Musica{Id = 8 , Nome = "Mario", GeneroId = 1},
                new Musica{Id = 9 , Nome = "Sonic Rock", GeneroId = 1},
                new Musica{Id = 10 , Nome = "Tony", GeneroId = 5},
                new Musica{Id = 11, Nome = "Paulo", GeneroId = 1}
            };

            //foreach (var genero in generos)
            //{
            //    if (genero.Nome.Contains("Rock"))
            //    {
            //        Console.WriteLine(genero.Id.ToString() + " " + genero.Nome);
            //    }

            //}
            Console.WriteLine();
            //Utilizando o LinQ primeiro chama a "tabela" com apelido depois a condição e por ultimo select

            //SELECT * FROM GENEROS
            //  var query  =     from g in generos where g.Nome.Contains("Rock") select g;

            //SELECT * FROM GENEROS WHERE G == "Rock"
            var query = from g in generos where g.Nome.Contains("Rock") select g;
            foreach (var genero in query)
            {
                Console.WriteLine(genero.Id.ToString() + " " + genero.Nome);
            }

            Console.WriteLine();

            //fazendo um join em Linq
            var musicaQuery = from m in musicas
                              join g in generos on m.GeneroId equals g.Id
                              select new { m, g };
            foreach (var item in musicaQuery)
            {
                Console.WriteLine($"{item.m.Id} {item.m.Nome} {item.m.Nome} ");
            }


            Console.Read();
        }
    }

    class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int GeneroId { get; set; }
    }
}
