Create table Pin (
idPin int primary key identity,
nomeLocal varchar(100) not null,
pais varchar(50) not null,
coordenadas varchar(50) not null,
descricao varchar(1000) not null
)

Create table ImagemPin (
idImagem int primary key identity,
idPin int not null,
url varchar(1000) not null

constraint FK_IdPin foreign key (IdPin)
references Pin(IdPin) 
)

select * from Pin
select * from ImagemPin

select p.idPin, p.nomeLocal, p.pais, p.coordenadas, p.descricao, i.url from
Pin p,
ImagemPin i
where
p.idPin = i.idPin

drop table ImagemPin

insert into Pin values('Pirâmides do Egito', 'Egito', '29° 58′ 44" N, 31° 8′ 2" L', 'Uma das 7 maravilhas do mundo antigo')

insert into ImagemPin values(1, 'c')

update Pin set coordenadas = '20°40´58.3" N 88°34´06.9" O' where idPin = 2

delete from Pin where idPin > 3

