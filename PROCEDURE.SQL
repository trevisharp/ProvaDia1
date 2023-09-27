create procedure getAlunos
	@id int = -1
	as
begin
	select 
		c.Nome as Curso,
		FORMAT(t.DataInicio, 'dd/mm/yy') as 'Data Inicio',
		FORMAT(t.DataTermino, 'dd/mm/yy') as 'Data Termino',
		c.CargaHoraria as CargaHoraria,
		p.Nome,
		p.CPF,
		p.Sexo,
		DATEDIFF(YEAR, p.DataNascimento, GETDATE()) as Idade,
		case
			when GETDATE() < t.DataInicio then 'Aguardando Inicio'
			when GETDATE() > t.DataTermino then 'Turma Finalizada'
			else 'Em Andamento'
		end as 'Status'
	from Alunos a
	inner join Pessoas p on a.Id = p.Id
	inner join TurmaAluno ta on ta.IdAluno = a.Id
	inner join Turmas t on ta.IdTurma = t.Id
	inner join Cursos c on t.IdCurso = c.Id
	where c.id = @id or @id = -1
end
