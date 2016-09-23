CREATE TABLE EndUser
(
user_name		NVARCHAR(25) 	NOT NULL,
user_password 	NVARCHAR		NOT NULL,
user_email		NVARCHAR		NOT NULL,
CONSTRAINT checkName
CHECK (LEN(username) > 4),
PRIMARY KEY	(user_name)
);