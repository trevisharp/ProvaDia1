select
  case
  	when lower(C.name) = 'id' then 'PK'
    when lower(C.name) like 'id%' then 'FK'
    else '' 
  end as 'CHAVE',
  C.name as 'NOME COLUNA',
  TY.name as 'TIPO',
  C.max_length as 'Tamanho',
  C.is_nullable as 'ACEITA NULL',
  C.is_identity as 'IS IDENTITY'
from sys.columns C
inner join sys.tables T
	on T.object_id = C.object_id
inner join sys.types TY
	on TY.user_type_id = C.user_type_id
where T.name = 'demo'