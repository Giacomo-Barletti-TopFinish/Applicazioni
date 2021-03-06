 CREATE TABLE SPUBICAZIONI (  
    IDUBICAZIONE NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    CODICE VARCHAR2(5) NOT NULL ,         
    DESCRIZIONE VARCHAR2(30) NOT NULL , 
    BARCODE VARCHAR2(13) NOT NULL,    
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_UBICAZIONE PRIMARY KEY (IDUBICAZIONE)
   );

CREATE  INDEX IDX_UBICAZIONE_A ON SPUBICAZIONI(CODICE);
CREATE  INDEX IDX_UBICAZIONE_1 ON SPUBICAZIONI(BARCODE);

CREATE TABLE SPUBICAZIONI_LOG (  
    IDUBICAZIONE NUMBER NULL,  
    CODICE VARCHAR2(5)  NULL ,     
    DESCRIZIONE VARCHAR2(30) NULL ,
    BARCODE VARCHAR2(13) NULL,     
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );

  create or replace TRIGGER SPUBICAZIONI_LOG
AFTER INSERT OR UPDATE ON SPUBICAZIONI
FOR EACH ROW
BEGIN
INSERT INTO SPUBICAZIONI_LOG(IDUBICAZIONE,CODICE,DESCRIZIONE,BARCODE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDUBICAZIONE,:NEW.CODICE,:NEW.DESCRIZIONE,:NEW.BARCODE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;

CREATE TABLE SPSALDI (  
    IDSALDO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDUBICAZIONE NUMBER NOT NULL ,     
    IDMAGAZZ VARCHAR2(10) NOT NULL ,     
    QUANTITA VARCHAR2(30) NULL ,     
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_SPSALDI PRIMARY KEY (IDSALDO),
FOREIGN KEY (IDUBICAZIONE) REFERENCES SPUBICAZIONI (IDUBICAZIONE) ENABLE
);



 CREATE TABLE SPSALDI_LOG (  
    IDSALDO NUMBER NULL,  
    IDUBICAZIONE NUMBER  NULL ,     
    IDMAGAZZ VARCHAR2(10) NULL ,     
    QUANTITA VARCHAR2(30) NULL ,     
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );

  create or replace TRIGGER SPSALDI_LOG
AFTER INSERT OR UPDATE ON SPSALDI
FOR EACH ROW
BEGIN
INSERT INTO SPSALDI_LOG(IDSALDO,IDUBICAZIONE,IDMAGAZZ,QUANTITA,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDSALDO,:NEW.IDUBICAZIONE,:NEW.IDMAGAZZ,:NEW.QUANTITA,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;

CREATE TABLE SPMOVIMENTI (  
    IDMOVIMENTO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDSALDO NUMBER NOT NULL ,       
    QUANTITA VARCHAR(30) NOT NULL ,  
    TIPOMOVIMENTO VARCHAR2(50) NOT NULL ,
    CAUSALE VARCHAR2(50) NOT NULL ,    
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_SPMOVIMENTO PRIMARY KEY (IDMOVIMENTO),
FOREIGN KEY (IDSALDO) REFERENCES SPSALDI (IDSALDO) ENABLE
);


 CREATE TABLE SPMOVIMENTI_LOG (  
    IDMOVIMENTO NUMBER NULL,  
    IDSALDO NUMBER  NULL ,
    QUANTITA VARCHAR(30) NULL,     
    TIPOMOVIMENTO VARCHAR2(50) NULL ,      
     CAUSALE VARCHAR2(50) NULL ,     
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );

  create or replace TRIGGER SPMOVIMENTI_LOG
AFTER INSERT OR UPDATE ON SPMOVIMENTI
FOR EACH ROW
BEGIN
INSERT INTO SPSALDI_LOG(IDMOVIMENTO,IDSALDO,QUANTITA,TIPOMOVIMENTO,CAUSALE,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDMOVIMENTO,:NEW.IDSALDO,:NEW.QUANTITA,:NEW.TIPOMOVIMENTO,:NEW.CAUSALE,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;



  CREATE TABLE "ITUSER"."SPOPERA" 
   (	
   "BRAND" VARCHAR2(254 BYTE), 
	"RAGIONE_SOCIALE_RIGA" VARCHAR2(50 BYTE), 
	"STAGIONE_DESCRIZIONE_TESTATA" VARCHAR2(7 BYTE), 
	"RIFERIMENTO_TESTATA" VARCHAR2(50 BYTE), 
	"NUMERO_RIGA" VARCHAR2(3 BYTE), 
	"DATA_RICHIESTA" DATE, 
	"DATA_CREAZIONE" DATE,
	"MODELLO_CODICE" VARCHAR2(30 BYTE), 
	"DESMODELLO" VARCHAR2(100 BYTE), 
	"QTANOSPE" FLOAT,
	"PREZZO_UNITARIO" FLOAT, 
	"QTAACCESI" FLOAT,
	"QTAEST" FLOAT,
	"QTATOT" FLOAT, 
	"QTAACCCON" FLOAT,
	"QTANOACC" FLOAT, 
	"QTASPE" FLOAT,
  IDUBICAZIONE NUMBER,-17
  CODICE VARCHAR2(5),
  QTAUBI FLOAT,
  QTAUBIUTIL FLOAT,
  QTAUBIRES FLOAT
  SEQUENZA NUMBER
   ) ;
   
   