CREATE DATABASE Trello;

GO

USE Trello;

CREATE TABLE list
(
	id		int				identity(1,1),
	name	varchar(100)	not null,

	constraint pk_list primary key (id)
);


CREATE TABLE card
(
	id			int				identity(1,1),
	list_id		int				not null,
	title		varchar(100)	not null,
	createdate	datetime		default(getdate())

	constraint fk_card_list foreign key (list_id) references list (id),
	constraint pk_card primary key (id)
);

CREATE TABLE card_categories
(
	id			int				not null,
	category	varchar(100)	not null,

	constraint pk_card_categories primary key (id, category),
	constraint fk_card_categories_card foreign key (id) references card(id)
);

set identity_insert list ON;

insert into list (id, name) VALUES (1, 'To Do');
insert into list (id, name) VALUES (2, 'Completed');
insert into list (id, name) VALUES (3, 'Pushed Off');

set identity_insert list OFF;

set identity_insert card ON;

insert into card (id, list_id, title, createdate) values (1, 1, 'Upload Assignment', getdate());
insert into card (id, list_id, title, createdate) values (2, 1, 'GitHub Portfolio Page', getdate());
insert into card (id, list_id, title, createdate) values (3, 1, 'C# LINQ', getdate());
insert into card (id, list_id, title, createdate) values (4, 1, 'SQL', getdate());
insert into card (id, list_id, title, createdate) values (5, 1, 'OOP Review', getdate());

insert into card (id, list_id, title, createdate) values (6, 2, 'Learn Module 1', getdate());
insert into card (id, list_id, title, createdate) values (7, 2, 'Learn Module 2', getdate());
insert into card (id, list_id, title, createdate) values (8, 2, 'Module 1 Code Review', getdate());
insert into card (id, list_id, title, createdate) values (9, 2, 'Complete Resume', getdate());
insert into card (id, list_id, title, createdate) values (10, 2, 'Mock Interview', getdate());

insert into card (id, list_id, title, createdate) values (11, 3, 'Learn Java', getdate());
insert into card (id, list_id, title, createdate) values (12, 3, 'Learn Python', getdate());
insert into card (id, list_id, title, createdate) values (13, 3, 'Research Target Companies', getdate());

set identity_insert card OFF;


insert into card_categories VALUES (1, 'Exercises');
insert into card_categories VALUES (1, 'Technical');
insert into card_categories VALUES (2, 'Pathway');



