using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AluraTunes
{
    public class contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=alura;Data Source=DESKTOP-777HC75\SQLSERVER2019");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
