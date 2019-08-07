select * from mov.Movies
where title like '%a%'
order by title

-- create an user names Renato with encrypted P@ssw0rd
insert into usr.Users
(Name, Login, Saltkey, Password, Active, DtCreated)
values
('Renato Matos', 'renato.matos79@gmail.com', '12345678', '8JHCg+SpXADEB+rzjNKQPQ==', 1, getdate())

-- create movie types
insert into mov.MovieTypes
(Name, Active, CreatedBy, DtCreated) 
values
('Romane', 1, 1, getdate())

insert into mov.MovieTypes
(Name, Active, CreatedBy, DtCreated) 
values
('Action', 1, 1, getdate())

insert into mov.MovieTypes
(Name, Active, CreatedBy, DtCreated) 
values
('Adventure', 1, 1, getdate())

insert into mov.MovieTypes
(Name, Active, CreatedBy, DtCreated) 
values
('Not Classified', 1, 1, getdate())