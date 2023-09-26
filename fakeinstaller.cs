using System.IO;
using System.Reflection;
using System.Diagnostics;

// Pega a pasta atual
var assembly = Assembly.GetEntryAssembly();
string crrPath = Path.GetDirectoryName(assembly.Location);

if (crrPath == "C:\\Users\\Public\\AppData")
{
    // Roda aplicação normalmente
    Console.WriteLine("Minha aplicação incrível");
    Console.ReadKey(true);
    return;
}

// Faz uma operação qualquer criando o banco de dados

var dir = new DirectoryInfo(crrPath);
foreach (FileInfo file in dir.GetFiles())
{
    file.CopyTo(Path.Combine("C:\\Users\\Public\\AppData", file.Name), true);
}

Console.WriteLine("Aplicação instalada");
Process.Start("C:\\Users\\Public\\AppData\\fakeinstaller.exe");
