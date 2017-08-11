/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     29/07/2017 16:23:25                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PERSONNE') and o.name = 'FK_PERSONNE_REFERENCE_DEPARTEM')
alter table PERSONNE
   drop constraint FK_PERSONNE_REFERENCE_DEPARTEM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PERSONNE') and o.name = 'FK_PERSONNE_REFERENCE_SERVICE')
alter table PERSONNE
   drop constraint FK_PERSONNE_REFERENCE_SERVICE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TACHE') and o.name = 'FK_TACHE_REFERENCE_PERSONNE')
alter table TACHE
   drop constraint FK_TACHE_REFERENCE_PERSONNE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DEPARTEMENT')
            and   type = 'U')
   drop table DEPARTEMENT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PERSONNE')
            and   type = 'U')
   drop table PERSONNE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SERVICE')
            and   type = 'U')
   drop table SERVICE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TACHE')
            and   type = 'U')
   drop table TACHE
go

/*==============================================================*/
/* Table: DEPARTEMENT                                           */
/*==============================================================*/
create table DEPARTEMENT (
   ID_DEPARTEMENT       numeric              identity,
   NOM_DEPARTEMENT      varchar(30)              not null,
   constraint PK_DEPARTEMENT primary key (ID_DEPARTEMENT)
)
go

/*==============================================================*/
/* Table: PERSONNE                                              */
/*==============================================================*/
create table PERSONNE (
   CIN                  int                  not null,
   ID_DEPARTEMENT       numeric              null,
   ID_SERV              numeric              null,
   NOM                  varchar(30)           null,
   PRENOM               varchar(30)           null,
   AGE                  int                  null,
   ADRESSE              varchar(200)           null,
   TEL                  int                  null,
   MAIL                 varchar(50)           null,
   DATE_NAIS            date                 null,
   constraint PK_PERSONNE primary key (CIN)
)
go

/*==============================================================*/
/* Table: SERVICE                                               */
/*==============================================================*/
create table SERVICE (
   ID_SERV              numeric              identity,
   NOM_SERVICE          varchar(30)          not null    ,
   constraint PK_SERVICE primary key (ID_SERV)
)
go

/*==============================================================*/
/* Table: TACHE                                                 */
/*==============================================================*/
create table TACHE (
   ID_TACHE             numeric              identity,
   CIN                  int                  null,
   DATE_DEBUT           date                 null,
   DATE_FIN             date                 null,
   DESCIPTION           varchar(500)           null,
   constraint PK_TACHE primary key (ID_TACHE)
)
go

alter table PERSONNE
   add constraint FK_PERSONNE_REFERENCE_DEPARTEM foreign key (ID_DEPARTEMENT)
      references DEPARTEMENT (ID_DEPARTEMENT)
go

alter table PERSONNE
   add constraint FK_PERSONNE_REFERENCE_SERVICE foreign key (ID_SERV)
      references SERVICE (ID_SERV)
go

alter table TACHE
   add constraint FK_TACHE_REFERENCE_PERSONNE foreign key (CIN)
      references PERSONNE (CIN)
go
