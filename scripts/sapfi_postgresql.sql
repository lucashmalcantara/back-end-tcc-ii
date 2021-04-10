CREATE DATABASE sapfi
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1;

CREATE TABLE public.company
(
    id bigint NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone,
    is_deleted boolean NOT NULL,
    api_token character(36) NOT NULL,
    document character(14),
    name character varying(150) NOT NULL,
    trading_name character varying(75) NOT NULL,
    CONSTRAINT pk_company PRIMARY KEY (id),
    CONSTRAINT uq_apitoken UNIQUE (api_token)
);

CREATE TABLE public.address
(
    id bigint NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone,
    is_deleted boolean NOT NULL,
    country character varying(75) NOT NULL,
    state character varying(75) NOT NULL,
    city character varying(150) NOT NULL,
    zip_code character(8) NOT NULL,
    neighborhood character varying(75) NOT NULL,
    street character varying(75) NOT NULL,
    number character varying(35) NOT NULL,
    complement character varying(75),
    CONSTRAINT pk_address PRIMARY KEY (id),
    CONSTRAINT fk_address_company FOREIGN KEY (id)
        REFERENCES public.company (id) MATCH SIMPLE
        ON UPDATE RESTRICT
        ON DELETE RESTRICT
        NOT VALID
);

CREATE TABLE public.notification
(
    id bigint NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone,
    is_deleted boolean NOT NULL,
    title character varying(75) NOT NULL,
    body character varying(255) NOT NULL,
    device_token character varying(255) NOT NULL,
    CONSTRAINT pk_notification PRIMARY KEY (id)
);

CREATE TABLE public.ticket
(
    id bigint NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone,
    is_deleted boolean NOT NULL,
    number character varying(25) NOT NULL,
    issue_date timestamp with time zone NOT NULL,
    line_position integer NOT NULL,
    waiting_time integer NOT NULL,
    company_id bigint NOT NULL,
    CONSTRAINT pk_ticket PRIMARY KEY (id),
    CONSTRAINT fk_ticket_company FOREIGN KEY (company_id)
    REFERENCES public.company (id) MATCH SIMPLE
    ON UPDATE RESTRICT
    ON DELETE RESTRICT
    NOT VALID
);

CREATE TABLE public.ticket_follow_up
(
    id bigint NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone,
    is_deleted boolean NOT NULL,
    number character varying(25) NOT NULL,
    device_token character varying(255) NOT NULL,
    ticket_id bigint NOT NULL,
    CONSTRAINT pk_ticketfollowup PRIMARY KEY (id),
    CONSTRAINT fk_ticketfollowup_ticket FOREIGN KEY (ticket_id)
    REFERENCES public.ticket (id) MATCH SIMPLE
    ON UPDATE RESTRICT
    ON DELETE RESTRICT
    NOT VALID
);

CREATE TABLE public.called_ticket
(
    id bigint NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone,
    is_deleted boolean NOT NULL,
    number character varying(25) NOT NULL,
    company_id bigint NOT NULL,
    CONSTRAINT pk_calledticket PRIMARY KEY (id),
    CONSTRAINT fk_calledticket_company FOREIGN KEY (company_id)
    REFERENCES public.company (id) MATCH SIMPLE
    ON UPDATE RESTRICT
    ON DELETE RESTRICT
    NOT VALID
);

CREATE TABLE public.line
(
    id bigint NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone,
    is_deleted boolean NOT NULL,
    quantity_of_ticket integer NOT NULL,
    waiting_time integer NOT NULL,
    CONSTRAINT pk_line PRIMARY KEY (id),
    CONSTRAINT fk_line_company FOREIGN KEY (id)
    REFERENCES public.company (id) MATCH SIMPLE
    ON UPDATE RESTRICT
    ON DELETE RESTRICT
    NOT VALID
);

CREATE TABLE public.line_follow_up
(
    id bigint NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone,
    is_deleted boolean NOT NULL,
    device_token character varying(255) NOT NULL,
    notify_when integer NOT NULL,
    line_id bigint NOT NULL,
    CONSTRAINT pk_linefollowup PRIMARY KEY (id),
    CONSTRAINT fk_linefollowup_company FOREIGN KEY (line_id)
    REFERENCES public.line (id) MATCH SIMPLE
    ON UPDATE RESTRICT
    ON DELETE RESTRICT
    NOT VALID
);