-----------------------------------------------------
-- DROP TABLE ORDER
-----------------------------------------------------

--DROP TABLE line_follow_up;
--DROP TABLE line;
--DROP TABLE ticket_follow_up;
--DROP TABLE ticket;
--DROP TABLE notification;
--DROP TABLE address;
--DROP TABLE company;


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
	name,
	trading_name
)
values
(
	NOW(),
	null,
	false,
	'451ed7f8-d284-4120-b284-7c98f999ebc2',
	'67194226000141',
	'Restaurante 01',
	'Jaqueline e Danilo Doces & Salgados Ltda'
),
(
	NOW(),
	null,
	false,
	'b59d69b9-bf8f-4009-b551-f5b96eea4025',
	'52400193000171',
	'Restaurante 02',
	'Andreia e Rosângela Alimentos Ltda'
),
(
	NOW(),
	null,
	false,
	'a21a6845-94de-4c5f-a8a0-c1d575e65aac',
	'17915190000170',
	'Restaurante 03',
	'Rafael e Ricardo Pizzaria Delivery Ltda'
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
	'2999',
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
	'2999',
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
	'3000',
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
	quantity_of_ticket,
	waiting_time
)
values
(
	1,
	NOW(),
	null,
	false,
	5,
	20
),
(
	2,
	NOW(),
	null,
	false,
	6,
	15
),
(
	3,
	NOW(),
	null,
	false,
	3,
	10
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