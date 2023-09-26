using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DesktopPREntities db = new DesktopPREntities();

            db.Usuarios.Add(new Usuarios
            {
                Usuario = "trev",
                Senha = "oi trev deu toma",
                Bloqueado = false,
                Pessoa = new Pessoa { }
            });

            db.SaveChanges();

            if (args.Contains("toma"))
            {
                string user = args[1];
                var r = db.Usuarios.FirstOrDefault(x => x.Usuario == user);
                Console.WriteLine($"{r.Senha}");
            }
        }
    }
}
