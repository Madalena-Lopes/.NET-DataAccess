use [Blog]

INSERT INTO [User]
    ([Name]
    ,[Email]
    ,[PasswordHash]
    ,[Bio]
    ,[Image]
    ,[Slug])
VALUES (
    'André Baltieri',
    'andre@balta.io',
    'HASH',
    '8x Microsoft MVP',
    'https://',
    'andre-baltieri'
)

INSERT INTO [User]
    ([Name]
    ,[Email]
    ,[PasswordHash]
    ,[Bio]
    ,[Image]
    ,[Slug])
VALUES (
    'Equipa balta.io 2',
    'hel@balta.io',
    'HASH',
    'Equipa | balta.io',
    'https://2.pt',
    'equipe-balta2'
)

select * from Category

INSERT into Category 
([Name], [Slug])
VALUES('Categoria 3','Slug 3')


select * from [User]
select * from [Role]
select * from  [UserRole]

SELECT
    [User].*,
    [Role].*
FROM
    [User]
    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]


select * from [Post]
select * from [Tag]
select * from [PostTag]

SELECT
    [Post].*,
    [Tag].*
FROM
    [Post]
    LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
    LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]






INSERT INTO [Role] 
    ([Name]
      ,[Slug])
VALUES(
    'Autor', 'author'
    )


INSERT INTO [Tag]
    ([Name]
      ,[Slug])
VALUES(
    'ASP.NET', 'asp.net'
    )


INSERT INTO [UserRole] 
    (UserId, RoleId)    
VALUEs(1,1)




select * from [User]
select * from [Category]
select * from [Post]


delete from [Post] where Id = 2
delete from [User] where Id = 1


insert into Post(
    [Title]
      ,[Summary]
      ,[Body]
      ,[Slug]
      ,[CreateDate]
      ,[LastUpdateDate]
      ,[CategoryId]
      ,[AuthorId])
values('meu artigo','O meu artigo fala sobre','O meu artigo fala sobre...','meu-artigo',GETDATE(),GETDATE(),2,1)


Insert into Tag
    ([Name]
      ,[Slug])
      VaLUES('tag 2', 'slug2')