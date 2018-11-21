
--TABLE DELETION
/*
DROP TABLE challenges
DROP TABLE challenge_categories
DROP TABLE challenge_subcategories
DROP TABLE users
DROP TABLE users_challenges
*/

--TABLE CREATION
/*
CREATE TABLE challenge_categories (
id int NOT NULL PRIMARY KEY IDENTITY, 
title varchar(255) NOT NULL
);

CREATE TABLE challenge_subcategories (
id int NOT NULL PRIMARY KEY IDENTITY, 
title varchar(255) NOT NULL
);

CREATE TABLE challenges (
id int NOT NULL PRIMARY KEY IDENTITY,
title varchar(255) NOT null,
createdAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
daysNeeded int NOT NULL, 
reward int NOT NULL, 
difficulty tinyint NOT NULL, 
completedBy int NOT NULL DEFAULT 0,

imgUrl varchar(255),
category int NOT NULL, 
subcategory int NOT NULL,
instructions text NOT NULL,
FOREIGN KEY (category) REFERENCES challenge_categories(id),
FOREIGN KEY (subcategory) REFERENCES challenge_subcategories(id)
);

CREATE TABLE users (
id int NOT NULL PRIMARY KEY IDENTITY, 
fullName varchar(255) NOT NULL,
username VARCHAR(255) NOT NULL UNIQUE,
email VARCHAR(255) NOT NULL UNIQUE,
password VARCHAR(255) NOT NULL,
imgUrl VARCHAR(255) NOT NULL, 
points INT NOT NULL DEFAULT 0,
level INT NOT NULL DEFAULT 1
);

CREATE TABLE users_challenges (
user_id int NOT NULL, 
challenge_id INT NOT NULL,
state INT NOT NULL DEFAULT 0,
startDate date NOT NULL,
endDate date NOT NULL, 
PRIMARY KEY(user_id, challenge_id)
);
*/

--HARCODED INFO
/*
INSERT INTO dbo.challenge_categories (title) VALUES('Official')
INSERT INTO dbo.challenge_categories (title) VALUES('User created')

INSERT INTO dbo.challenge_subcategories (title) VALUES('Running')
INSERT INTO dbo.challenge_subcategories (title) VALUES('Programming')
INSERT INTO dbo.challenge_subcategories (title) VALUES('Reading')
INSERT INTO dbo.challenge_subcategories (title) VALUES('Social')
INSERT INTO dbo.challenge_subcategories (title) VALUES('Good deeds')
INSERT INTO dbo.challenge_subcategories (title) VALUES('Others')

INSERT INTO dbo.users(fullName,username,email,password,imgUrl,points,level)
VALUES ('Monika Kaltenyte','monika','kaltenytmonika3@gmail.com','abc123','https://s.gravatar.com/avatar/9f207f9e4b641de3fc8674f217966711?s=80',0,1)
INSERT INTO dbo.users(fullName,username,email,password,imgUrl,points,level)
VALUES ('Kristina Rudokaite','kristina','kristina@gmail.com','abc123','',0,1)
INSERT INTO dbo.users(fullName,username,email,password,imgUrl,points,level)
VALUES ('Ignas Jasonas','ignas','ignas.jasonas@gmail.com','abc123','',0,1)

INSERT INTO dbo.challenges
(title,createdAt,daysNeeded,reward,difficulty,completedBy,imgUrl,category,subcategory,instructions)
VALUES('Run till you`re dead','2017-05-21',15,230,2,1682,'http://www.myfacemybody.com/wp-content/uploads/2009/08/runing-282x300.jpg',1,1,'Instructions') 
INSERT INTO dbo.challenges
(title,createdAt,daysNeeded,reward,difficulty,completedBy,imgUrl,category,subcategory,instructions)
VALUES('Party Monster','2018-04-28',10,100,1,965,'http://www.djsonnyproductions.com/wp-content/uploads/2015/06/house-party-300x300.jpg',2,4,'Instructions')
INSERT INTO dbo.challenges
(title,createdAt,daysNeeded,reward,difficulty,completedBy,imgUrl,category,subcategory,instructions)
VALUES('Do You Even Javascript?','2016-02-01',20,400,4,8551,'https://cdn-images-1.medium.com/max/300/1*yYcXoIyTb8JlZUsmRXNm3g.png',1,2,'Instructions')
INSERT INTO dbo.challenges
(title,createdAt,daysNeeded,reward,difficulty,completedBy,imgUrl,category,subcategory,instructions)
VALUES('Code Master','2018-02-12',30,550,4,12,'https://techcrunch.com/wp-content/uploads/2015/04/codecode.jpg?w=730&crop=1',1,2,'Instructions')
INSERT INTO dbo.challenges
(title,createdAt,daysNeeded,reward,difficulty,completedBy,imgUrl,category,subcategory,instructions)
VALUES('Programming Challenge','2018-01-06',5,80,2,105521,'https://cdn-images-1.medium.com/max/2000/1*cCdSJ0mOqjQkm-soL5hlIw.jpeg',2,2,'Instructions')
INSERT INTO dbo.challenges
(title,createdAt,daysNeeded,reward,difficulty,completedBy,imgUrl,category,subcategory,instructions)
VALUES('Python Debbuger','2017-12-10',14,140,5,3,'https://cdn-images-1.medium.com/max/1217/1*ueWmI48uuShON-hX7LwI0w.png',1,2,'Instructions')
INSERT INTO dbo.challenges
(title,createdAt,daysNeeded,reward,difficulty,completedBy,imgUrl,category,subcategory,instructions)
VALUES('Horror of Code','2012-12-12',40,800,5,1,'https://blog.codinghorror.com/content/images/uploads/2006/08/6a0120a85dcdae970b0120a86d6c5b970b-pi.gif',1,2,'Instructions')


INSERT INTO dbo.users_challenges(user_id,challenge_id,state,startDate, endDate)
VALUES(1,1,1,'2018-04-28','2018-05-12')
INSERT INTO dbo.users_challenges(user_id,challenge_id,state,startDate, endDate)
VALUES(2,3,2,'2018-01-01','2018-01-21')
INSERT INTO dbo.users_challenges(user_id,challenge_id,state,startDate, endDate)
VALUES(2,2,1,'2018-04-20','2018-04-30')

ALTER TABLE [dbo].[users]
    ADD [passwordHash] varbinary(1024) DEFAULT(0) NOT NULL,
        [passwordSalt] varbinary(1024) DEFAULT(0) NOT NULL;

*/

