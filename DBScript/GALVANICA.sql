
 CREATE TABLE AP_GALVANICA_MODELLO 
   (	
    IDGALVAMODEL NUMBER NOT NULL,
      IDMAGAZZ VARCHAR2(10 BYTE) NOT NULL, 
      IDMAGAZZ_WIP VARCHAR2(10 BYTE) NOT NULL,
      MODELLO	VARCHAR2(30 BYTE) NOT NULL,
      COMPONENTE	VARCHAR2(30 BYTE) NOT NULL,
      BRAND	VARCHAR2(20 BYTE) NULL,
      FINITURA	VARCHAR2(20 BYTE)  NULL,  
      MATERIALE VARCHAR2(20 BYTE)  NULL, 
      PEZZIBARRA NUMBER NULL,
      SUPERFICIE VARCHAR(10) NULL,
      GALVANICA VARCHAR2(20)  NULL,
      primary key (IDGALVAMODEL)
   );
   
   CREATE INDEX IDX_AP_GALVANICA_MODELLO ON AP_GALVANICA_MODELLO(IDMAGAZZ,IDMAGAZZ_WIP);
   
   
create TABLE AP_GALVANICA_PIANO
   (	
   IDGALVAPIANO NUMBER NOT NULL,
      IDMAGAZZ VARCHAR2(10 BYTE) NOT NULL, 
      IDMAGAZZ_WIP VARCHAR2(10 BYTE) NOT NULL,
      MODELLO	VARCHAR2(30 BYTE) NOT NULL,
      COMPONENTE	VARCHAR2(30 BYTE) NOT NULL,
      BRAND	VARCHAR2(20 BYTE) NULL,
      FINITURA	VARCHAR2(20 BYTE)  NULL,  
      MATERIALE VARCHAR2(20 BYTE)  NULL, 
      PEZZIBARRA NUMBER NULL,
      SUPERFICIE VARCHAR(10) NULL,
      ORDINE NUMBER NULL,
      GALVANICA VARCHAR2(20)  NULL,
      QUANTITA NUMBER NULL,
      PIANIFICATO NUMBER NULL,
      BARRE FLOAT NULL,
      DATAGALVANICA DATE,
      REPARTO	CHAR(254 BYTE),
       PRIMARY KEY (IDGALVAPIANO)
   );
   
      CREATE INDEX IDX_AP_AP_GALVANICA_PIANO ON AP_GALVANICA_PIANO(DATAGALVANICA);


 CREATE TABLE AP_GALVANICA_SPESSORI 
   (	
    IDGALVASPESSORI NUMBER NOT NULL,
      BRAND	VARCHAR2(20 BYTE) NULL,
      FINITURA	VARCHAR2(20 BYTE)  NOT NULL,  
      ETICHETTA VARCHAR(10) NOT NULL,
      SEQUENZA NUMBER(3)  NOT NULL,
      primary key (IDGALVASPESSORI)
   );

  CREATE INDEX IDX_AP_GALVANICA_SPESSORI ON AP_GALVANICA_SPESSORI(BRAND,FINITURA);


 CREATE TABLE AP_CERTIX
   (	
    IDMISURECERTIX NUMBER NOT NULL,
      BARCODE	VARCHAR2(30 BYTE) NULL,
      IDLINE	NUMBER(3)  NOT NULL,  
      DATAMISURA DATE NOT NULL, 
      IDMAGAZZ VARCHAR2(10 BYTE) NOT NULL, 
      IDMAGAZZ_WIP VARCHAR2(10 BYTE) NOT NULL,
      primary key (IDMISURECERTIX)
   );


 CREATE TABLE AP_CERTIX_DETTAGLIO
   (	
      IDMISURECERTIXDET NUMBER NOT NULL,
      IDMISURECERTIX NUMBER NOT NULL,
      ETICHETTA VARCHAR(10) NOT NULL,
      SEQUENZA NUMBER(3)  NOT NULL,
      VALORE FLOAT  NOT NULL,
      DATAINSERIMENTO DATE NOT NULL,
      primary key (IDMISURECERTIXDET)
   );
   
create table GALVANICA_CARICO AS
select sum(mf.qta) QTA,sum(mf.qtadater)QTADATER,
            MODLAN.IDMAGAZZ AS IDMAGAZZ_LANCIO,
            MODLAN.MODELLO AS MODELLO_LANCIO,
            MOD.IDMAGAZZ AS IDMAGAZZ_WIP,
            MOD.MODELLO AS MODELLO_WIP,
            MOD.SUPERFICIE,
            am.pezzibarra,
            fo.ordine,
            'INTERNO' REPARTO,
            AM.MATERIALE,
            am.brand,
            am.finitura,
             sum(mf.qta)/am.pezzibarra barre,
             gp.pianificato,
             gp.datagalvanica,
             gp.idgalvapiano

      from usr_prd_movfasi mf
      inner join gruppo.clifo cli on cli.codice = mf.codiceclifo
      INNER JOIN USR_PRD_FASI FAS  ON  MF.IDPRDFASE = FAS.IDPRDFASE
      INNER JOIN GRUPPO.MAGAZZ MOD ON MF.IDMAGAZZ = MOD.IDMAGAZZ 
      INNER JOIN USR_PRD_LANCIOD LAN ON FAS.IDLANCIOD = LAN.IDLANCIOD 
      INNER JOIN GRUPPO.MAGAZZ MODLAN ON LAN.IDMAGAZZ = MODLAN.IDMAGAZZ
      left join ap_galvanica_modello am on am.idmagazz = lan.idmagazz and am.idmagazz_wip = mod.idmagazz
      left join FINITURA_ORDINE FO on fo.brand=am.brand and fo.finitura = am.finitura
      left join ap_galvanica_piano gp on gp.idmagazz = LAN.IDMAGAZZ and gp.idmagazz_wip = mod.idmagazz and gp.datagalvanica = to_date('14/06/2019','DD/MM/YYYY')
where 
mf.idtabfas in ('0000000046','0000000272','0000000273','0000000606')
and mf.qtadater > 0
and mf.datamovfase < to_date('14/06/2019 23:59:59','DD/MM/YYYY HH24:MI:SS')
and substr(cli.CODICE,1,1)<>'0'

group by  modlan.idmagazz,
             modlan.modello,
             mod.idmagazz,
             mod.modello,
            MOD.SUPERFICIE,
            am.pezzibarra,             
            fo.ordine,             
            AM.MATERIALE,
            am.brand,
            am.finitura,
            gp.pianificato,
            gp.datagalvanica,
            gp.idgalvapiano
            
            union all

select sum(mf.qta) QTA,sum(mf.qtadater)QTADATER,
            MODLAN.IDMAGAZZ AS IDMAGAZZ_LANCIO,
            MODLAN.MODELLO AS MODELLO_LANCIO,
            MOD.IDMAGAZZ AS IDMAGAZZ_WIP,
            MOD.MODELLO AS MODELLO_WIP,
            MOD.SUPERFICIE,
            am.pezzibarra,
            fo.ordine,
            'INTERNO' REPARTO,
            AM.MATERIALE,
            am.brand,
            am.finitura,
             sum(mf.qta)/am.pezzibarra barre,
             gp.pianificato,
             gp.datagalvanica,
             gp.idgalvapiano

      from usr_prd_movfasi mf
      inner join gruppo.clifo cli on cli.codice = mf.codiceclifo
      INNER JOIN USR_PRD_FASI FAS  ON  MF.IDPRDFASE = FAS.IDPRDFASE
      INNER JOIN GRUPPO.MAGAZZ MOD ON MF.IDMAGAZZ = MOD.IDMAGAZZ 
      INNER JOIN USR_PRD_LANCIOD LAN ON FAS.IDLANCIOD = LAN.IDLANCIOD 
      INNER JOIN GRUPPO.MAGAZZ MODLAN ON LAN.IDMAGAZZ = MODLAN.IDMAGAZZ
      left join ap_galvanica_modello am on am.idmagazz = lan.idmagazz and am.idmagazz_wip = mod.idmagazz
      left join FINITURA_ORDINE FO on fo.brand=am.brand and fo.finitura = am.finitura
      left join ap_galvanica_piano gp on gp.idmagazz = LAN.IDMAGAZZ and gp.idmagazz_wip = mod.idmagazz and gp.datagalvanica = to_date('14/06/2019','DD/MM/YYYY')
where 
mf.idtabfas in ('0000000046','0000000272','0000000273','0000000606')
and mf.qtadater > 0
and mf.datamovfase < to_date('14/06/2019 23:59:59','DD/MM/YYYY HH24:MI:SS')
and substr(cli.CODICE,1,1)='0'

group by  modlan.idmagazz,
             modlan.modello,
             mod.idmagazz,
             mod.modello,
            MOD.SUPERFICIE,
            am.pezzibarra,             
            fo.ordine,             
            AM.MATERIALE,
            am.brand,
            am.finitura,
            gp.pianificato,
            gp.datagalvanica,
            gp.idgalvapiano;



select sp.* from ap_galvanica_spessori sp
inner join ap_galvanica_modello mo on mo.brand = sp.brand and mo.finitura = sp.finitura
where mo.idmagazz = jjj and mo.idmagazz_wip = ggg