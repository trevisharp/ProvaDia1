using System;
using System.Linq;
using System.Collections.Generic;

// Usar ToArray depois de pegar do banco e antes do join
// pode evitar alguns errros
List<Aluno> alunos = new List<Aluno>();
List<Curso> cursos = new List<Curso>();
List<Disciplina> disciplinas = new List<Disciplina>();
List<Nota> notas = new List<Nota>();

Aluno alunoLogado = new Aluno();

var query =
    notas
    .Where(n => n.AlunoID == alunoLogado.ID)
    .Join(disciplinas, not => not.DisciplinaID, dis => dis.ID,
        (not, dis) => new {
            Disciplina = dis.Nome,
            Status =  not.Status
    });

Console.WriteLine("Hello, World!");

public class Aluno
{
    public int ID { get; set; }
    public int CursoID { get; set; }
}

public class Curso
{
    public int ID { get; set; }
}

public class Disciplina
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public int CursoID { get; set; }
}

public class Nota
{
    public int ID { get; set; }
    public int AlunoID { get; set; }
    public int DisciplinaID { get; set; }
    public string Status { get; set; }
}