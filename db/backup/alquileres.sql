--
-- PostgreSQL database dump complete
--

--
-- Name: alquiler_bicicletas; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE alquiler_bicicletas;


ALTER DATABASE alquiler_bicicletas OWNER TO postgres;

\connect alquiler_bicicletas

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: alquileres; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.alquileres (
    id bigint NOT NULL,
    id_cliente character varying(50),
    estado bigint DEFAULT 1,
    estacion_retiro bigint,
    estacion_devolucion bigint,
    fecha_hora_retiro timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    fecha_hora_devolucion timestamp without time zone NOT NULL,
    monto double precision,
    id_tarifa bigint
);


ALTER TABLE public.alquileres OWNER TO postgres;

--
-- Name: alquileres_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.alquileres ALTER COLUMN id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public.alquileres_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);

--
-- Name: tarifas; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tarifas (
    id bigint NOT NULL,
    tipo_tarifa bigint DEFAULT 1,
    definicion character varying(1) DEFAULT 'S'::character varying,
    dia_semana bigint,
    dia_mes bigint,
    mes bigint,
    anio bigint,
    monto_fijo_alquiler double precision,
    monto_minuto_fraccion double precision,
    monto_km double precision,
    monto_hora double precision
);


ALTER TABLE public.tarifas OWNER TO postgres;

--
-- Name: tarifas_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.tarifas ALTER COLUMN id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public.tarifas_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);



--
-- Data for Name: alquileres; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.alquileres (id, id_cliente, estado, estacion_retiro, estacion_devolucion, fecha_hora_retiro, fecha_hora_devolucion, monto, id_tarifa) FROM stdin;
\.

--
-- Data for Name: tarifas; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tarifas (id, tipo_tarifa, definicion, dia_semana, dia_mes, mes, anio, monto_fijo_alquiler, monto_minuto_fraccion, monto_km, monto_hora) FROM stdin;
1	1	S	1	\N	\N	\N	300	6	80	240
2	1	S	2	\N	\N	\N	300	6	80	240
3	1	S	3	\N	\N	\N	300	6	80	240
4	1	S	4	\N	\N	\N	300	6	80	240
5	1	S	5	\N	\N	\N	320	6.75	90	270
6	1	S	6	\N	\N	\N	450	9	120	350
7	1	S	7	\N	\N	\N	450	9	120	350
8	2	C	\N	13	10	2023	200	4	75	175
9	2	C	\N	14	10	2023	200	4	75	175
10	2	C	\N	15	10	2023	200	4	75	175
11	2	C	\N	16	10	2023	200	4	75	175
12	2	C	\N	23	10	2023	200	4	75	175
13	2	C	\N	24	10	2023	200	4	75	175
14	2	C	\N	25	10	2023	200	4	75	175
15	2	C	\N	26	10	2023	200	4	75	175
16	2	C	\N	27	10	2023	200	4	75	175
17	2	C	\N	2	11	2023	220	4.4	82.5	192.5
\.


--
-- Name: alquileres_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.alquileres_id_seq', 1, false);

--
-- Name: tarifas_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tarifas_id_seq', 18, true);



--
-- Name: alquileres alquileres_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alquileres
    ADD CONSTRAINT alquileres_pkey PRIMARY KEY (id);

--
-- Name: tarifas tarifas_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tarifas
    ADD CONSTRAINT tarifas_pkey PRIMARY KEY (id);


--
-- Name: IX_alquileres_ESTACION_DEVOLUCION; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX ix_alquileres_estacion_devolucion ON public.alquileres USING btree (estacion_devolucion);

--
-- Name: IX_alquileres_ID_TARIFA; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX ix_alquileres_id_tarifa ON public.alquileres USING btree (id_tarifa);

--
-- Name: alquileres fk_alquileres_tarifas; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alquileres
    ADD CONSTRAINT fk_alquileres_tarifas FOREIGN KEY (id_tarifa) REFERENCES public.tarifas(id);


--
-- PostgreSQL database dump complete
--
