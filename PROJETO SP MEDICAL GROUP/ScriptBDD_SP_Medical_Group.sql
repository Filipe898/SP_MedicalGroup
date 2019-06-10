create database SP_Medical_Group_TESTE1

use SP_Medical_Group_TESTE1 

CREATE TABLE T_SMG_ESPECIALIDADES(
	id_especialidade int identity primary key
	,nm_especialidade varchar(255) not null
);

CREATE TABLE T_SMG_CLINICA(
	id_clinica int identity primary key
	,nm_clinica varchar(255) not null
	,ds_razao_social varchar(255) 
	,num_cnpj varchar (30) not null
	,ds_endereco varchar(255)
	,ds_horario_atendimento varchar(255)
);
 
CREATE TABLE T_SMG_STATUS(
	id_status int identity primary key
	,ds_status  varchar(255) 
);

CREATE TABLE T_SMG_TIPO_USUARIO(
id_tipo_usuario int identity primary key
,nm_usuario varchar(255) not null
);

CREATE TABLE T_SMG_USUARIOS(
	id_usuarios int identity primary key
	,nm_usuario varchar(255) not null
	,ds_senha varchar(255) not null
	,ds_email varchar (255) not null
	,num_telefone varchar (30) not null
	,id_clinica int foreign key references t_smg_clinica (id_clinica)
	,id_tipo_usuario int foreign key references t_smg_tipo_usuario (id_tipo_usuario)
);

CREATE TABLE T_SMG_PACIENTES(
	id_paciente int identity primary key
	,num_rg varchar (30) not null
	,num_cpf varchar (30) not null
	,ds_endereco varchar (255) not null
	,ds_data_nascimento datetime not null
	,id_usuario int foreign key references t_smg_usuarios(id_usuarios)
);

CREATE TABLE T_SMG_MEDICOS(
	id_medico int identity primary key
	,num_crm varchar (30) not null
	,id_usuarios int foreign key references t_smg_usuarios (id_usuarios)
	,id_especialidade int foreign key references t_smg_especialidades (id_especialidade)
);

CREATE TABLE T_SMG_CONSULTAS(
	id_consulta int identity primary key
	,ds_descricao varchar (255) not null
	,dat_data_consulta datetime not null 
	,id_paciente int foreign key references t_smg_pacientes (id_paciente)
	,id_medico int foreign key references t_smg_medicos (id_medico)
	,id_status int foreign key references t_smg_status (id_status)
);

insert into T_SMG_CLINICA(nm_clinica,ds_razao_social,num_cnpj,ds_endereco,ds_horario_atendimento)
values ('SP_MEDICAL_GROUP','SP_MEDICAL_GROUP','132465','RUA MARECHAL DEODORO 157','DAS 13H AS 19H')

insert into T_SMG_TIPO_USUARIO(nm_usuario)
values ('ADM'),('MEDICO'),('PACIENTE')

insert into T_SMG_USUARIOS(nm_usuario,ds_senha,ds_email,num_telefone,id_clinica,id_tipo_usuario)
values ('filipe',123,'filipe@hotmail.com',11982328210,1,1)


select * from T_SMG_CLINICA 
select * from T_SMG_TIPO_USUARIO
select * from T_SMG_USUARIOS