
DROP TABLE BC_MIGRAZIONE 

  CREATE TABLE BC_MIGRAZIONE 
   (	"IDMIGRAZIONE" NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE  NOT NULL ENABLE, 
	 "IDMAGAZZ" VARCHAR2(10 BYTE), 
	 "BC" VARCHAR2(20 BYTE), 
   "IDNODO" INTEGER ,
   PROFONDITA INTEGER,
   MODELLO VARCHAR2(100),
   QUANTITA FLOAT,
   IDPADRE INTEGER,
   REPARTO VARCHAR2(20),
   FASE VARCHAR2(20),
   PRODOTTOFINALE VARCHAR2(100),
   DIBA INTEGER ,
   
	 PRIMARY KEY ("IDMIGRAZIONE")
   );

  CREATE INDEX "IDX_MIGRAZIONE" ON BC_MIGRAZIONE ("IDMAGAZZ") ;
  CREATE INDEX "IDX_MIGRAZIONE_1" ON BC_MIGRAZIONE ("IDNODO") ;

select * from BC_MIGRAZIONE


select count(*) from BC_MIGRAZIONE



