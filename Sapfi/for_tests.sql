-----------------------------------------------------
-- DROP TABLE
-----------------------------------------------------

--DROP TABLE line_follow_up;
--DROP TABLE line;
--DROP TABLE ticket_follow_up;
--DROP TABLE ticket;
--DROP TABLE notification;
--DROP TABLE address;
--DROP TABLE company;

-----------------------------------------------------
-- CLEAN
-----------------------------------------------------

--delete from line_follow_up;
--delete from line;
--delete from ticket_follow_up;
--delete from ticket;
--delete from notification;
--delete from address;
--delete from company;

-----------------------------------------------------
-- LOAD COMPANY
-----------------------------------------------------

insert into company 
(
	created_at,
	updated_at,
	is_deleted,
	api_token,
	document,
	trading_name,
	name,
	friendly_human_code
)
values
(
	NOW(),
	null,
	false,
	'f6e38f27-b193-45ae-8d72-594721a4d237',
	'60630017000154',
	'Araguaia Porções',
	'Theodoro Afonso Lanches Ltda',
	'ABCD'
),
(
	NOW(),
	null,
	false,
	'b59d69b9-bf8f-4009-b551-f5b96eea4025',
	'52400193000171',
	'AR Alimentos',
	'Andreia e Rosângela Alimentos Ltda',
	'EFGH'
),
(
	NOW(),
	null,
	false,
	'a21a6845-94de-4c5f-a8a0-c1d575e65aac',
	'17915190000170',
	'RR Pizzaria',
	'Rafael e Ricardo Pizzaria Delivery Ltda',
	'IJKL'
),
(
	NOW(),
	null,
	false,
	'451ed7f8-d284-4120-b284-7c98f999ebc2',
	'67194226000141',
	'JD Doces',
	'Jaqueline e Danilo Doces & Salgados Ltda',
	'MNOP'
);


----------------------------------------------------
-- LOAD COMPANY ADDRESSES
-----------------------------------------------------

insert into address 
(
	id,
	created_at,
	updated_at,
	is_deleted,
	country,
	state,
	city,
	zip_code,
	neighborhood,
	street,
	number,
	complement
)
values
(
	1,
	NOW(),
	null,
	false,
	'BRA',
	'MG',
	'Contagem',
	'32340001',
	'Eldorado',
	'Av. João César de Oliveira',
	'99.990',
	'Loja 01'
),
(
	2,
	NOW(),
	null,
	false,
	'BRA',
	'MG',
	'Contagem',
	'32340001',
	'Eldorado',
	'Av. João César de Oliveira',
	'99.991',
	'Loja 02'
),
(
	3,
	NOW(),
	null,
	false,
	'BRA',
	'MG',
	'Contagem',
	'32340001',
	'Eldorado',
	'Av. João César de Oliveira',
	'99.992',
	null
),
(
	4,
	NOW(),
	null,
	false,
	'BRA',
	'MG',
	'Contagem',
	'32340001',
	'Eldorado',
	'Av. João César de Oliveira',
	'99.993',
	null
);

----------------------------------------------------
-- LOAD LINE
-----------------------------------------------------

insert into line
(
	id,
	created_at,
	updated_at,
	is_deleted,
	number_of_tickets,
	waiting_time
)
values
(
	1,
	NOW(),
	null,
	false,
	15,
	45
),
(
	2,
	NOW(),
	null,
	false,
	5,
	15
),
(
	3,
	NOW(),
	null,
	false,
	10,
	30
),
(
	4,
	NOW(),
	null,
	false,
	7,
	37
);

----------------------------------------------------
-- LOAD TICKET
-----------------------------------------------------

insert into ticket 
(
	id,
	created_at,
	updated_at,
	is_deleted,
	company_id,
	external_id,
	issue_date,
	line_position,
	"number",
	waiting_time
)
values
(
	1,
	NOW(),
	null,
	false,
	1,
	'1',
	NOW(),
	1,
	'001',
	5
),
(
	2,
	NOW(),
	null,
	false,
	1,
	'2',
	NOW(),
	1,
	'002',
	12
);