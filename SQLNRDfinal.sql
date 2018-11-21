
/*
CREATE TABLE [dbo].[challenge_categories] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [title] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[challenge_subcategories] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [title] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[challenges] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [title]        VARCHAR (255) NOT NULL,
    [createdAt]    DATE          NOT NULL,
    [daysNeeded]   INT           NOT NULL,
    [reward]       INT           NOT NULL,
    [difficulty]   TINYINT       NOT NULL,
    [completedBy]  INT           DEFAULT ((0)) NOT NULL,
    [imgUrl]       VARCHAR (255) NULL,
    [category]     INT           NOT NULL,
    [subcategory]  INT           NOT NULL,
    [instructions] TEXT          NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([category]) REFERENCES [dbo].[challenge_categories] ([id]),
    FOREIGN KEY ([subcategory]) REFERENCES [dbo].[challenge_subcategories] ([id])
);

CREATE TABLE [dbo].[users] (
    [id]           INT              IDENTITY (1, 1) NOT NULL,
    [fullName]     VARCHAR (255)    NOT NULL,
    [username]     VARCHAR (255)    NOT NULL,
    [email]        VARCHAR (255)    NOT NULL,
    [password]     VARCHAR (255)    NOT NULL,
    [imgUrl]       VARCHAR (255)    NOT NULL,
    [points]       INT              DEFAULT ((0)) NOT NULL,
    [level]        INT              DEFAULT ((1)) NOT NULL,
    [passwordHash] VARBINARY (1024) DEFAULT ((0)) NOT NULL,
    [passwordSalt] VARBINARY (1024) DEFAULT ((0)) NOT NULL,
    [isAdmin]      BIT              DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([email] ASC),
    UNIQUE NONCLUSTERED ([username] ASC)
);

CREATE TABLE [dbo].[users_challenges] (
    [user_id]      INT  NOT NULL,
    [challenge_id] INT  NOT NULL,
    [state]        INT  DEFAULT ((0)) NOT NULL,
    [startDate]    DATE NOT NULL,
    [endDate]      DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC, [challenge_id] ASC)
);
*/
/*
INSERT INTO dbo.challenge_categories(title)VALUES('Official');
INSERT INTO dbo.challenge_categories(title)VALUES('User created');

INSERT INTO dbo.challenge_subcategories(title)VALUES('Sports')
INSERT INTO dbo.challenge_subcategories(title)VALUES('Programming')
INSERT INTO dbo.challenge_subcategories(title)VALUES('Social')
INSERT INTO dbo.challenge_subcategories(title)VALUES('Good deeds')
INSERT INTO dbo.challenge_subcategories(title)VALUES('Reading')
INSERT INTO dbo.challenge_subcategories(title)VALUES('Others')


INSERT INTO dbo.users
(
    fullName,
    username,
    email,
    password,
    imgUrl,
    points,
    level,
    passwordHash,
    passwordSalt,
    isAdmin
)
VALUES
(   'Jonas Jonaitis',   -- fullName - varchar(255)
    'JonkA',   -- username - varchar(255)
    'jonkos@gmail.com',   -- email - varchar(255)
    'abc',   -- password - varchar(255)
    'http://www.uni-regensburg.de/Fakultaeten/phil_Fak_II/Psychologie/Psy_II/beautycheck/english/durchschnittsgesichter/m(01-32)_gr.jpg',   -- imgUrl - varchar(255)
    1,    -- points - int
    1,    -- level - int
    5464, -- passwordHash - varbinary(1024)
    45645, -- passwordSalt - varbinary(1024)
    0  -- isAdmin - bit
    )

	INSERT INTO dbo.users
(
    fullName,
    username,
    email,
    password,
    imgUrl,
    points,
    level,
    passwordHash,
    passwordSalt,
    isAdmin
)
VALUES
(   'Petras Petraitis',   -- fullName - varchar(255)
    'Piotr',   -- username - varchar(255)
    'p@gmail.com',   -- email - varchar(255)
    'abc',   -- password - varchar(255)
    'https://cdna.artstation.com/p/assets/images/images/001/642/888/20151213113619/smaller_square/piotr-jablonski-freaks30lightsss.jpg?1450028180',   -- imgUrl - varchar(255)
    50,    -- points - int
    2,    -- level - int
    1111, -- passwordHash - varbinary(1024)
    1111, -- passwordSalt - varbinary(1024)
    0  -- isAdmin - bit
    )

	INSERT INTO dbo.users
(
    fullName,
    username,
    email,
    password,
    imgUrl,
    points,
    level,
    passwordHash,
    passwordSalt,
    isAdmin
)
VALUES
(   'Tadas Monis',   -- fullName - varchar(255)
    'Tadux',   -- username - varchar(255)
    'a@gmail.com',   -- email - varchar(255)
    'abc',   -- password - varchar(255)
    'http://3.bp.blogspot.com/-YwTWEEhozB0/ULjqjTemzoI/AAAAAAAAFeY/-JHTcEZf6Xk/s1600/Tadas_Vidmantas.jpg',   -- imgUrl - varchar(255)
    66,    -- points - int
    2,    -- level - int
    1111, -- passwordHash - varbinary(1024)
    11111, -- passwordSalt - varbinary(1024)
    0  -- isAdmin - bit
    )

	INSERT INTO dbo.users
(
    fullName,
    username,
    email,
    password,
    imgUrl,
    points,
    level,
    passwordHash,
    passwordSalt,
    isAdmin
)
VALUES
(   'Monika Girdyte',   -- fullName - varchar(255)
    'monkutiee',   -- username - varchar(255)
    'aa@gmail.com',   -- email - varchar(255)
    'abc',   -- password - varchar(255)
    'https://4.bp.blogspot.com/-hsXIqNnL8TI/WtMhIfIPWiI/AAAAAAAACDs/iUY9VbbUDoMKqAKAjbxR4_vjUiIeimbwgCLcBGAs/s1600/Monika%2BMork%25C5%25ABnait%25C4%2597%2B2017.JPG',   -- imgUrl - varchar(255)
    99,    -- points - int
    5,    -- level - int
    1111, -- passwordHash - varbinary(1024)
    11111, -- passwordSalt - varbinary(1024)
    0  -- isAdmin - bit
    )

		INSERT INTO dbo.users
(
    fullName,
    username,
    email,
    password,
    imgUrl,
    points,
    level,
    passwordHash,
    passwordSalt,
    isAdmin
)
VALUES
(   'Marija Darskute',   -- fullName - varchar(255)
    'Ikvepeja',   -- username - varchar(255)
    'aac@gmail.com',   -- email - varchar(255)
    'abc',   -- password - varchar(255)
    'http://www.chinabuddhismencyclopedia.com/en/images/thumb/f/f8/Ayywar.jpeg/250px-Ayywar.jpeg',   -- imgUrl - varchar(255)
    400,    -- points - int
    80,    -- level - int
    1111, -- passwordHash - varbinary(1024)
    11111, -- passwordSalt - varbinary(1024)
    0  -- isAdmin - bit
    )

		INSERT INTO dbo.users
(
    fullName,
    username,
    email,
    password,
    imgUrl,
    points,
    level,
    passwordHash,
    passwordSalt,
    isAdmin
)
VALUES
(   'Gedas Medas',   -- fullName - varchar(255)
    'GME',   -- username - varchar(255)
    'aaaa@gmail.com',   -- email - varchar(255)
    'abc',   -- password - varchar(255)
    'http://www.topbestpics.com/wp-content/uploads/2018/01/funny-people-ugly-faces-1.jpeg',   -- imgUrl - varchar(255)
    0,    -- points - int
    10,    -- level - int
    1111, -- passwordHash - varbinary(1024)
    11111, -- passwordSalt - varbinary(1024)
    0  -- isAdmin - bit
    )

		INSERT INTO dbo.users
(
    fullName,
    username,
    email,
    password,
    imgUrl,
    points,
    level,
    passwordHash,
    passwordSalt,
    isAdmin
)
VALUES
(   'Egle Pance',   -- fullName - varchar(255)
    'egle',   -- username - varchar(255)
    'aayya@gmail.com',   -- email - varchar(255)
    'abc',   -- password - varchar(255)
    'https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/Picea_jezoensis.JPG/260px-Picea_jezoensis.JPG',   -- imgUrl - varchar(255)
    77,    -- points - int
    7,    -- level - int
    1111, -- passwordHash - varbinary(1024)
    11111, -- passwordSalt - varbinary(1024)
    0  -- isAdmin - bit
    )

		INSERT INTO dbo.users
(
    fullName,
    username,
    email,
    password,
    imgUrl,
    points,
    level,
    passwordHash,
    passwordSalt,
    isAdmin
)
VALUES
(   'Mantas Nesvarbu',   -- fullName - varchar(255)
    'luckyboii',   -- username - varchar(255)
    'aalll@gmail.com',   -- email - varchar(255)
    'abc',   -- password - varchar(255)
    'http://lefunny.net/wp-content/uploads/2014/08/8589130426275-funny-people-wallpaper-hd.jpg',   -- imgUrl - varchar(255)
    800,    -- points - int
    7,    -- level - int
    1111, -- passwordHash - varbinary(1024)
    11111, -- passwordSalt - varbinary(1024)
    0  -- isAdmin - bit
    )

		INSERT INTO dbo.users
(
    fullName,
    username,
    email,
    password,
    imgUrl,
    points,
    level,
    passwordHash,
    passwordSalt,
    isAdmin
)
VALUES
(   'Natasha Sasha',   -- fullName - varchar(255)
    'priviet',   -- username - varchar(255)
    'asdaaa@gmail.com',   -- email - varchar(255)
    'abc',   -- password - varchar(255)
    'https://lh3.googleusercontent.com/5ycnmZbE_nl4AypOXIniYvuC3du_oG5B_PjLFbq_xP1YuO114wfcZqrvRzRpzv0xWK4=h310',   -- imgUrl - varchar(255)
    99,    -- points - int
    5,    -- level - int
    1111, -- passwordHash - varbinary(1024)
    11111, -- passwordSalt - varbinary(1024)
    0  -- isAdmin - bit
    )

		INSERT INTO dbo.users
(
    fullName,
    username,
    email,
    password,
    imgUrl,
    points,
    level,
    passwordHash,
    passwordSalt,
    isAdmin
)
VALUES
(   'Edvis Mataras',   -- fullName - varchar(255)
    'Edxins',   -- username - varchar(255)
    'axxa@gmail.com',   -- email - varchar(255)
    'abc',   -- password - varchar(255)
    'http://www4.pictures.zimbio.com/gi/Jonah+Hill+Funny+People+Q+Session+QPtau9yuhfPl.jpg',   -- imgUrl - varchar(255)
    919,    -- points - int
    65,    -- level - int
    1111, -- passwordHash - varbinary(1024)
    11111, -- passwordSalt - varbinary(1024)
    0  -- isAdmin - bit
    )

	INSERT INTO dbo.challenges
(title,createdAt,daysNeeded,reward,difficulty,completedBy,imgUrl,category,subcategory,instructions)
VALUES('Run till you`re dead','2017-05-21',15,230,2,1682,'http://www.myfacemybody.com/wp-content/uploads/2009/08/runing-282x300.jpg',1,1,'Instructions') 
INSERT INTO dbo.challenges
(title,createdAt,daysNeeded,reward,difficulty,completedBy,imgUrl,category,subcategory,instructions)
VALUES('Party Monster','2018-04-28',10,100,1,965,'http://www.djsonnyproductions.com/wp-content/uploads/2015/06/house-party-300x300.jpg',2,3,'Instructions')
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
INSERT INTO dbo.challenges
(title,createdAt,daysNeeded,reward,difficulty,completedBy,imgUrl,category,subcategory,instructions)
VALUES('Good God','2016-12-12',10,100,1,999,'http://media-cdn.timesfreepress.com/img/photos/2016/04/21/1461276050_Good-Deed_t1070_h67e381d858b2014cc4a34fa7b9a5e1eac9a93614.jpg',1,4,'Instructions')
INSERT INTO dbo.challenges
(title,createdAt,daysNeeded,reward,difficulty,completedBy,imgUrl,category,subcategory,instructions)
VALUES('Do You Even Read?','2017-12-12',120,1200,4,0,'https://www.timeshighereducation.com/sites/default/files/styles/the_breaking_news_image_style/public/books-open-on-table.jpg?itok=i4wJDL9A',2,5,'Instructions')
INSERT INTO dbo.challenges
(title,createdAt,daysNeeded,reward,difficulty,completedBy,imgUrl,category,subcategory,instructions)
VALUES('Improvise','2011-05-10',1,1,1,1,'https://www.musical-u.com/wp-content/uploads/2015/05/improvise_with_your_ears-1.jpg',2,6,'Create your own challenge!')

INSERT INTO dbo.users_challenges
(
    user_id,
    challenge_id,
    state,
    startDate,
    endDate
)
VALUES
(   3,         -- user_id - int
    3,         -- challenge_id - int
    1,         -- state - int
    '2018-05-11', -- startDate - date
    '2018-05-20'  -- endDate - date
    )

		INSERT INTO dbo.users_challenges
(
    user_id,
    challenge_id,
    state,
    startDate,
    endDate
)
VALUES
(   2,         -- user_id - int
    2,         -- challenge_id - int
    1,         -- state - int
    '2018-04-11', -- startDate - date
    '2018-05-10'  -- endDate - date
    )

	INSERT INTO dbo.users_challenges
(
    user_id,
    challenge_id,
    state,
    startDate,
    endDate
)
VALUES
(   3,         -- user_id - int
    4,         -- challenge_id - int
    1,         -- state - int
    '2018-05-11', -- startDate - date
    '2018-05-30'  -- endDate - date
    )

	INSERT INTO dbo.users_challenges
(
    user_id,
    challenge_id,
    state,
    startDate,
    endDate
)
VALUES
(   4,         -- user_id - int
    8,         -- challenge_id - int
    1,         -- state - int
    '2018-04-11', -- startDate - date
    '2018-04-20'  -- endDate - date
    )

	INSERT INTO dbo.users_challenges
(
    user_id,
    challenge_id,
    state,
    startDate,
    endDate
)
VALUES
(   5,         -- user_id - int
    6,         -- challenge_id - int
    1,         -- state - int
    '2018-05-11', -- startDate - date
    '2018-06-20'  -- endDate - date
    )
		INSERT INTO dbo.users_challenges
(
    user_id,
    challenge_id,
    state,
    startDate,
    endDate
)
VALUES
(   6,         -- user_id - int
    7,         -- challenge_id - int
    1,         -- state - int
    '2018-05-11', -- startDate - date
    '2018-05-12'  -- endDate - date
    )
		INSERT INTO dbo.users_challenges
(
    user_id,
    challenge_id,
    state,
    startDate,
    endDate
)
VALUES
(   8,         -- user_id - int
    7,         -- challenge_id - int
    1,         -- state - int
    '2018-05-11', -- startDate - date
    '2018-05-20'  -- endDate - date
    )
		INSERT INTO dbo.users_challenges
(
    user_id,
    challenge_id,
    state,
    startDate,
    endDate
)
VALUES
(   9,         -- user_id - int
    9,         -- challenge_id - int
    1,         -- state - int
    '2018-05-11', -- startDate - date
    '2019-06-20'  -- endDate - date
    )
*/



