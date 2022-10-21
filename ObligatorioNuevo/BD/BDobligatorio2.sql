use master
go

create database Mensajes
on (
name= Mensajes,
filename ='D:\Bios\Segundo Año\BD\BiosMensajes.mdp'
)
go
--------------
use Mensajes
go
-----------------------------------------------------------
-----------------------------------------------------------
----------       TABLAS     -------------------------------
-----------------------------------------------------------
-----------------------------------------------------------

create table Usuario (
NombreUsuario varchar (8) primary key check(LEN (NombreUsuario)=8),
Pass varchar(6) not null check(Pass like '[A-Z][A-Z][A-Z][A-Z][A-Z][0-9]'),
NombreCompleto varchar(30) not null,
Mail varchar(20) not null check (Mail like'%__@__%.__%')
)
go

create table Tipo (
CodigoTipo varchar(3) primary key check(CodigoTipo like '[A-Z][A-Z][A-Z]') ,
NombreTipo varchar(15) not null
)
go

Create table Mensaje(
Codigo int  primary key identity,
FechaHora datetime default GetDate(),
Asunto varchar(30) not null,
Texto varchar(max)not null,
NombreUsuario varchar (8) not null,
CodigoTipo varchar(3)not null,
FechaCaduca datetime not null check (Fechacaduca > dateadd(hour,+24,Getdate())),
foreign key (NombreUsuario) references Usuario (NombreUsuario),
foreign key (CodigoTipo)references Tipo (CodigoTipo)
)
go


create table Recibe(
NombreUsuario varchar(8)not null ,
Codigo int not null,
primary key (NombreUsuario,Codigo),
Foreign key (NombreUsuario) references usuario(NombreUsuario),
foreign key (Codigo)references Mensaje (Codigo)
)
go

USE master
GO

CREATE LOGIN [IIS APPPOOL\DefaultAppPool] FROM WINDOWS 
GO

USE Mensajes
GO

CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
GO

exec sys.sp_addrolemember 'db_owner', [IIS APPPOOL\DefaultAppPool]
go

-----------------------------------------------------------
-----------------------------------------------------------
-----------------   DATOS DE PRUEBA   ---------------------
-----------------------------------------------------------


-----USUARIO----
insert into Usuario (NombreUsuario,Pass,NombreCompleto,Mail)values ('chris123','chris1','Chrisian Presa','Ch.gp@gamil.com')
insert into Usuario (NombreUsuario,Pass,NombreCompleto,Mail)values ('mathias1','mathi1','Mathias Rodriguez','mat@gamil.com')
insert into Usuario (NombreUsuario,Pass,NombreCompleto,Mail)values ('Maru1234','maruu1','Mariana','maru@gamil.com')
insert into Usuario (NombreUsuario,Pass,NombreCompleto,Mail)values ('invitado','invit1','invitado prueba','invitado@hotmail.com')
insert into Usuario (NombreUsuario,Pass,NombreCompleto,Mail)values ('profesor','profe2','profesor primero','bios1ro@gamil.com')
insert into Usuario (NombreUsuario,Pass,NombreCompleto,Mail)values ('profeso2','profe3','Profesor Segundo','bios2do@gamil.com')
insert into Usuario (NombreUsuario,Pass,NombreCompleto,Mail)values ('bedelia2','bedel2','Bedelia Bios','bedelia@gamil.com')
insert into Usuario (NombreUsuario,Pass,NombreCompleto,Mail)values ('antel123','antel2','Antel Promocion','ventas@hotmail.com')
insert into Usuario (NombreUsuario,Pass,NombreCompleto,Mail)values ('ricardo1','ricky1','Ricardo Perez','Ricky@gamil.com')
insert into Usuario (NombreUsuario,Pass,NombreCompleto,Mail)values ('alonso12','alons1','Alonso Afuera','alonso@hotmail.com')
GO

-----TIPO
insert into Tipo (CodigoTipo,NombreTipo)values('URG','URGENTE')
insert into Tipo (CodigoTipo,NombreTipo)values('IVT','INVITACION')
insert into Tipo (CodigoTipo,NombreTipo)values('EVT','EVENTOS')
insert into Tipo (CodigoTipo,NombreTipo)values('VEN','VENTA')
insert into Tipo (CodigoTipo,NombreTipo)values('PRO','PROMOCION')
insert into Tipo (CodigoTipo,NombreTipo)values('INT','INTERNO')
insert into Tipo (CodigoTipo,NombreTipo)values('INF','INFORMATIVO')
insert into Tipo (CodigoTipo,NombreTipo)values('REC','RECORDATORIO')
insert into Tipo (CodigoTipo,NombreTipo)values('CIT','CITACION')
insert into Tipo (CodigoTipo,NombreTipo)values('DEV','DEVOLUCION')
GO

----MENSAJE
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Consulta','Queria consultar sobre los nuevos equipos','chris123','URG','20221116 22:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Consulta','Queria consultar sobre los cursos 2023','chris123','PRO','20221219 20:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Consulta','Queria consultar sobre las becas ','chris123','PRO','20221217 22:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Comprbante','justificacion de faltas','mathias1','PRO','20221118 23:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Comprobante','justificacion de faltas','chris123','VEN','20221219 21:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Compra','Compra de servicio','maru1234','CIT','20221216 20:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Consulta','Queria consultar sobre cuota','maru1234','VEN','20221216 18:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Venta','Enviamos informacion','antel123','URG','20221218 19:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Respuesta','Enviamos info','antel123','INF','20221216 21:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Respuesta','Enviamos informacion solicitada en link','bedelia2','INF','20221217 19:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Respuesta','Queria consultar sobre los nuevos equipos','bedelia2','INF','20221216 20:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Recuerdo','La cuota esta por vencer','bedelia2','INF','20221217 21:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Recuerdo','La cuota esta por vencer','bedelia2','EVT','20221219 21:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Recuerdo','La cuota esta por vencer','bedelia2','EVT','20221216 19:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Recuerdo','La cuota esta por vencer','bedelia2','INT','20221218 20:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Respuesta','Respuesta de consulta en adj.','bedelia2','INT','20221218 19:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Consulta','Queria saber...','chris123','INF','20221217 20:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Consulta','Queria informacion sobre...','Maru1234','INF','20221116 20:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Comprbantetetetetetetetete','justificacion ','mathias1','REC','20221217 20:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Comprobant de teeeee','justificacion de faltas asdasdasdasd','chris123','REC','20221216 23:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Comprbante de teeeeee','justificacion de faltas asdasdasd','mathias1','DEV','20221816 22:00')
insert into Mensaje(Asunto,Texto,NombreUsuario,CodigoTipo,FechaCaduca)values('Comprobantetetetetetetete','justificacion','chris123','DEV','20221116 23:00')
GO

select * from Mensaje
--RECIBE
insert into Recibe (NombreUsuario,Codigo)values('bedelia2','1')
insert into Recibe (NombreUsuario,Codigo)values('antel123','2')
insert into Recibe (NombreUsuario,Codigo)values('bedelia2','3')
insert into Recibe (NombreUsuario,Codigo)values('bedelia2','4')
insert into Recibe (NombreUsuario,Codigo)values('bedelia2','5')
insert into Recibe (NombreUsuario,Codigo)values('antel123','6')
insert into Recibe (NombreUsuario,Codigo)values('chris123','7')
insert into Recibe (NombreUsuario,Codigo)values('mathias1','8')
insert into Recibe (NombreUsuario,Codigo)values('antel123','9')
insert into Recibe (NombreUsuario,Codigo)values('bedelia2','17') 
insert into Recibe (NombreUsuario,Codigo)values('maru1234','10')
insert into Recibe (NombreUsuario,Codigo)values('chris123','11')
insert into Recibe (NombreUsuario,Codigo)values('bedelia2','18')
insert into Recibe (NombreUsuario,Codigo)values('mathias1','12')
insert into Recibe (NombreUsuario,Codigo)values('profesor','13')
insert into Recibe (NombreUsuario,Codigo)values('profesor','14')
insert into Recibe (NombreUsuario,Codigo)values('chris123','15')
insert into Recibe (NombreUsuario,Codigo)values('mathias1','16')
insert into Recibe (NombreUsuario,Codigo)values('profesor','20')
insert into Recibe (NombreUsuario,Codigo)values('maru1234','20')
insert into Recibe (NombreUsuario,Codigo)values('antel123','22')
insert into Recibe (NombreUsuario,Codigo)values('maru1234','8')
insert into Recibe (NombreUsuario,Codigo)values('mathias1','18')
insert into Recibe (NombreUsuario,Codigo)values('chris123','17')
insert into Recibe (NombreUsuario,Codigo)values('chris123','16')
insert into Recibe (NombreUsuario,Codigo)values('mathias1','17')
insert into Recibe (NombreUsuario,Codigo)values('maru1234','17')
insert into Recibe (NombreUsuario,Codigo)values('ricardo1','18')
insert into Recibe (NombreUsuario,Codigo)values('alonso12','18')
insert into Recibe (NombreUsuario,Codigo)values('profeso2','18')
insert into Recibe (NombreUsuario,Codigo)values('ricardo1','19')
insert into Recibe (NombreUsuario,Codigo)values('ricardo1','20')
insert into Recibe (NombreUsuario,Codigo)values('profeso2','20')
insert into Recibe (NombreUsuario,Codigo)values('profesor','20')
insert into Recibe (NombreUsuario,Codigo)values('mathias1','22')
insert into Recibe (NombreUsuario,Codigo)values('profesor','22')
insert into Recibe (NombreUsuario,Codigo)values('profesor','1')
insert into Recibe (NombreUsuario,Codigo)values('profeso2','1')
insert into Recibe (NombreUsuario,Codigo)values('ricardo1','2')
insert into Recibe (NombreUsuario,Codigo)values('alonso12','22')
insert into Recibe (NombreUsuario,Codigo)values('profesor','4')
insert into Recibe (NombreUsuario,Codigo)values('profeso2','4')
GO

-----------------------------------------------------------
-----------------------------------------------------------
----------         SP       -------------------------------
-----------------------------------------------------------
-----------------------------------------------------------

-- ELIMINAR MENSAJE
create proc BajaUsuario
@NombreLogueo varchar(8)
as
begin
if not exists(Select * from Usuario where NombreUsuario = @NombreLogueo )
begin
return -1
end
if exists (select * from Mensaje  where NombreUsuario = @NombreLogueo)
begin
return -2
end
if exists (select * from Recibe  where NombreUsuario = @NombreLogueo)
begin
return -2
end

delete from Usuario  where NombreUsuario = @Nombrelogueo
if(@@ERROR=0)
return 1
else
return -3
end 
go