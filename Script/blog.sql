CREATE DATABASE [Blog]
GO

USE [Blog]
GO

-- DROP TABLE [User]
-- DROP TABLE [Role]
-- DROP TABLE [UserRole]
-- DROP TABLE [Post]
-- DROP TABLE [Category]
-- DROP TABLE [Tag]
-- DROP TABLE [PostTag]

CREATE TABLE [User] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(80) NOT NULL,
    [Email] VARCHAR(200) NOT NULL,              --pq não vai ter caracteres especiais
    [PasswordHash] VARCHAR(255) NOT NULL,
    [Bio] TEXT NOT NULL,                        --biografia - text - não tem limite
    [Image] VARCHAR(2000) NOT NULL,             --não tem carateres especiais pq vamos armazenar a url da imagem (não a imagem)
    [Slug] VARCHAR(80) NOT NULL,                --balta.io/users/andre-baltieri   balta.io/blog/fundamentos-csharp

    CONSTRAINT [PK_User] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_User_Email] UNIQUE([Email]),
    CONSTRAINT [UQ_User_Slug] UNIQUE([Slug])
)
CREATE NONCLUSTERED INDEX [IX_User_Email] ON [User]([Email]) 
CREATE NONCLUSTERED INDEX [IX_User_Slug] ON [User]([Slug])

--CLUSTERED são normalmente os das chaves primárias. O sql  sabe +/- em que pagina ir buscar determinada chave.
--NONCLUSTERED já é por defeito. 
--Email:             Id:
-- andre@balta.io -> 473
-- hello@balta.io -> 298
--Slug:
--andre-baltieri - 473
-- Equipe balta.io -298
--No NONCLUSTERED, tendo o indice vai pegar no Id e depois é mais facil encontrar
--Num select pelo Name = 'André' -> Table scan -> vai passar registo a registo para o encontrar pq não tem indice

--Perfil (do usuário) = função/cargo
CREATE TABLE [Role] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] VARCHAR(80) NOT NULL,  --estes nomes vão ser + simples por isso não está NVARCHAR(80) 
    [Slug] VARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Role] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Role_Slug] UNIQUE([Slug])
)
CREATE NONCLUSTERED INDEX [IX_Role_Slug] ON [Role]([Slug])


--perfil de cada usuário
--1 user pode ter mts roles = perfis
--relação de muitos para muitos!!!!
CREATE TABLE [UserRole] (
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,

    CONSTRAINT [PK_UserRole] PRIMARY KEY([UserId], [RoleId])
)

CREATE TABLE [Category] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] VARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Category] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Category_Slug] UNIQUE([Slug])
)
CREATE NONCLUSTERED INDEX [IX_Category_Slug] ON [Category]([Slug])

--publicação
CREATE TABLE [Post] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [CategoryId] INT NOT NULL,  
    [AuthorId] INT NOT NULL, --um post só tem 1 autor (User.Id) FK
    [Title] VARCHAR(160) NOT NULL,
    [Summary] VARCHAR(255) NOT NULL,
    [Body] TEXT NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    [CreateDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    [LastUpdateDate] DATETIME NOT NULL DEFAULT(GETDATE()),

    CONSTRAINT [PK_Post] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Post_Category] FOREIGN KEY([CategoryId]) REFERENCES [Category]([Id]),
    CONSTRAINT [FK_Post_Author] FOREIGN KEY([AuthorId]) REFERENCES [User]([Id]),
    CONSTRAINT [UQ_Post_Slug] UNIQUE([Slug])
)
CREATE NONCLUSTERED INDEX [IX_Post_Slug] ON [Post]([Slug])

--marcação
CREATE TABLE [Tag] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] VARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Tag] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Tag_Slug] UNIQUE([Slug])
)
CREATE NONCLUSTERED INDEX [IX_Tag_Slug] ON [Tag]([Slug])

--relação post tag: relação de 1 para 1
--1 post pode ter mts tags
--1 tag pode estar em mts pots (postagens)
CREATE TABLE [PostTag] (
    [PostId] INT NOT NULL,
    [TagId] INT NOT NULL,

    CONSTRAINT PK_PostTag PRIMARY KEY([PostId], [TagId])
)