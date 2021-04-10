-----------------------------------------------------
-- DROP TABLE ORDER
-----------------------------------------------------

--DROP TABLE line_follow_up;
--DROP TABLE line;
--DROP TABLE called_ticket;
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
-- LOAD CALLED TICKETS
-----------------------------------------------------

insert into called_ticket 
(
	created_at,
	updated_at,
	is_deleted,
	company_id,
	called_at,
	number,
	external_id
)
values
(
	NOW(),
	null,
	false,
	1,
	NOW(),
	'101',
	'101'
),
(
	NOW(),
	null,
	false,
	1,
	NOW(),
	'102',
	'102'
),
(
	NOW(),
	null,
	false,
	1,
	NOW(),
	'103',
	'103'
),
(
	NOW(),
	null,
	false,
	1,
	NOW(),
	'104',
	'104'
),
(
	NOW(),
	null,
	false,
	1,
	NOW(),
	'105',
	'105'
),
(
	NOW(),
	null,
	false,
	1,
	NOW(),
	'106',
	'106'
),
(
	NOW(),
	null,
	false,
	1,
	NOW(),
	'107',
	'107'
),
(
	NOW(),
	null,
	false,
	1,
	NOW(),
	'108',
	'108'
),
(
	NOW(),
	null,
	false,
	1,
	NOW(),
	'109',
	'109'
),
(
	NOW(),
	null,
	false,
	2,
	NOW(),
	'110',
	'110'
),
(
	NOW(),
	null,
	false,
	2,
	NOW(),
	'1',
	'1'
),
(
	NOW(),
	null,
	false,
	2,
	NOW(),
	'2',
	'2'
),

(
	NOW(),
	null,
	false,
	2,
	NOW(),
	'3',
	'3'
),

(
	NOW(),
	null,
	false,
	2,
	NOW(),
	'4',
	'4'
),
(
	NOW(),
	null,
	false,
	2,
	NOW(),
	'5',
	'5'
),
(
	NOW(),
	null,
	false,
	3,
	NOW(),
	'AN-01',
	'AN-01'
),
(
	NOW(),
	null,
	false,
	3,
	NOW(),
	'AN-02',
	'AN-02'
),

(
	NOW(),
	null,
	false,
	3,
	NOW(),
	'AN-03',
	'AN-03'
),
(
	NOW(),
	null,
	false,
	3,
	NOW(),
	'AN-04',
	'AN-04'
),
(
	NOW(),
	null,
	false,
	3,
	NOW(),
	'AP-01',
	'AP-01'
),
(
	NOW(),
	null,
	false,
	3,
	NOW(),
	'AP-02',
	'AP-02'
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