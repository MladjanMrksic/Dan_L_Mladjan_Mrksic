IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'AudioPlayer')
CREATE DATABASE AudioPlayer
go

use AudioPlayer
go

if exists (SELECT name FROM sys.sysobjects WHERE name = 'AppUser')
drop table AppUser
if exists (SELECT name FROM sys.sysobjects WHERE name = 'Song')
drop table Song

create table AppUser
(
AppUserID int primary key identity(1,1),
Username nvarchar(50),
Password nvarchar(50),
)

create table Song
(
SongID int primary key identity(1,1),
SongName nvarchar(50),
SongAuthor nvarchar(50),
SongDuration Time,
)

INSERT INTO Song(SongName,SongAuthor,SongDuration) VALUES ('SongOne','AuthorOne','00:03:55');
INSERT INTO Song(SongName,SongAuthor,SongDuration) VALUES ('SongTwo','AuthorTwo','00:03:25');
INSERT INTO Song(SongName,SongAuthor,SongDuration) VALUES ('SongThree','AuthorThree','00:03:15');