use Senai_Pizzarias_Extra

create table usuarios (
	id_usuario int identity primary key,
	email varchar (205) not null,
	senha varchar (205) not null,
);

create table pizzarias (
	Id_Pizzarias int identity primary key,
	Nome varchar (205),
	Endereco varchar (205),
	Telefone varchar (205),
	Opcao_Vegana varchar(3),
	Categoria_Preco varchar(3)
);
select id_usuario, email, senha from usuarios

alter table usuarios add Permissao varchar(205);

drop table pizzarias

insert into usuarios (email, senha)
values  ('gandolf@gmail.com', '132'),
		('ba@gmail.com', '123');

update usuarios set Permissao = 'cliente' where id_usuario = 2
update pizzarias set telefone = '(11) 3120-5050'where id_pizzarias = 2
delete from pizzarias where id_pizzarias = 12

insert into pizzarias (nome, endereco, telefone, opcao_vegana, categoria_preco) 
values ('Di Fondi Pizza', 'Av. Ipiranga, 200 - SP', '(11)2783-9947', 'Nao', '$$'),
	   ('Pizzaria Copan', 'Rua Dn. Veridiana, 661 - SP', '(11)3120-5050', 'Sim', '$$$'),
	   ('Vip Pizza Bar', 'Rua Cantareira, 306  - SP', '(11) 3313-7518', 'Nao', '$'),
	   ('Primo Basílico', 'Rua Brg. Galvão, 363 - SP', '(11) 3662-0752', 'Sim', '$$'),
	   ('Tutti Pizzaria', 'Rua Gandavo, 447 - SP', '(11) 5082-3800', 'Nao', '$');

select * from usuarios	
select * from pizzarias