using System;
using System.Net;
using System.Linq;
using System.Net.Sockets;

Random rand = new Random();

// nome com contador
Enumerable.Range(1, 10).Select(n => $"Aluno {n}");

// 3 letras aleatórias
var r1 = string.Concat(
    Enumerable.Range(0, 3)
        .Select(n => (char)('a' + rand.Next('z' - 'a')))
);

// 4 numeros aleatorios
var r2 = string.Concat(
    Enumerable.Range(0, 4)
        .Select(n => rand.Next(10).ToString())
);

// DataNascimento
var start = new DateTime(1980, 1, 1);
var end = new DateTime(2000, 12, 31);

var r3 = new DateTime(rand.NextInt64(start.Ticks, end.Ticks));

// Pegar IP
var ip = Dns.GetHostEntry(Dns.GetHostName())
    .AddressList
    .FirstOrDefault(x => (int)x.AddressFamily == 2)
    .ToString();