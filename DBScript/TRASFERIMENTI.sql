
 CREATE TABLE AP_TTRASFERIMENTI 
   (	
   IDTRASFERIMENTO NUMBER NOT NULL, 
BARCODE_PARTENZA	VARCHAR2(13 BYTE) NOT NULL,
BARCODE_ARRIVO	VARCHAR2(13 BYTE) NULL,
DATA_PARTENZA DATE NOT NULL,
  DATA_ARRIVO DATE NULL,
  ATTIVO NUMBER NOT NULL,
	 PRIMARY KEY (IDTRASFERIMENTO)
   );
   
  CREATE INDEX IDX_AP_TTRASFERIMENTI_1 ON AP_TTRASFERIMENTI(BARCODE_PARTENZA);
  
   CREATE TABLE AP_DTRASFERIMENTI 
   (	
   IDDTRASFERIMENTO NUMBER NOT NULL, 
   IDTRASFERIMENTO NUMBER NOT NULL, 
BARCODE_ODL	VARCHAR2(13 BYTE) NOT NULL,
NUMMOVFASE	VARCHAR2(25 BYTE) NOT NULL,
REPARTO 	VARCHAR2(10 BYTE) NOT NULL,
  MODELLO	VARCHAR2(30 BYTE) NULL,
  QTA	FLOAT NULL,
  PRIMARY KEY (IDDTRASFERIMENTO)
   );
   
   CREATE INDEX IDX_AP_DTRASFERIMENTI_1 ON AP_DTRASFERIMENTI(IDTRASFERIMENTO);
