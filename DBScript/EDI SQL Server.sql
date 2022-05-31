USE MPI


CREATE TABLE ACCESSORISTI
(CODICE	NVARCHAR(6),
CODCF	NVARCHAR(10),
CODIND	NVARCHAR(3),
[Ship-to Code] as trim(Convert(varchar, CODCF)) + '-' + trim(Convert(varchar, CODIND))
)

GO 

Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('204891','01154     ','324');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('495510','01154     ','304');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('495510','01154     ','279');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('463634','01154     ','1  ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('479747','01154     ','2  ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('486430','01154     ','3  ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('503706','01154     ','4  ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('516745','01154     ','5  ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('525040','01154     ','6  ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('536078','01154     ','7  ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('531185','01154     ','9  ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('481816','01154     ','28 ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('571836','01154     ','291');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('609642','01154     ','49 ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('204743','01154     ','53 ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('204407','01154     ','325');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('204407','01154     ','294');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('581297','01154     ','296');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('626866','01154     ','75 ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('202233','01154     ','76 ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('626866','01154     ','77 ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('202233','01154     ','78 ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('202884','01154     ','286');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('583436','01154     ','319');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('004422','01154     ','103');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('003157','01154     ','326');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('003157','01154     ','113');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('003157','01154     ','114');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('200723','01154     ','115');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('201712','01154     ','301');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('598405','01154     ','316');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('560009','01154     ','321');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('583733','01154     ','330');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('002170','01154     ','159');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('202091','01154     ','167');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('213667','01154     ','183');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('533039','01154     ','184');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('533039','01154     ','185');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('003057','01154     ','186');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('003057','01154     ','187');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('492145','01154     ','188');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('492145','01154     ','189');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('003760','01154     ','190');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('532173','01154     ','281');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('002528','01154     ','203');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('582190','01154     ','285');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('003172','01154     ','206');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('201733','01154     ','298');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('201733','01154     ','297');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('583538','01154     ','295');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('581849','01154     ','275');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('465861','01154     ','258');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('465861','01154     ','259');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('598405','01154     ','46 ');
Insert into ACCESSORISTI (CODICE,CODCF,CODIND) values ('002170','01154     ','163');
go
SELECT * FROM ACCESSORISTI
go
CREATE VIEW [dbo].[BOLLE_VENDITA] AS
select 'METALPLUS' AZIENDA,
'' DESTABTIPDOC, '' CODICETIPDOC, ente.[MTP Authority code] CODICETIPOO, '' DESTABTIPOO, testata.[Reason Code] CODICECAUTR, rea.[Description] DESTABCAUTR, 
                testata.No_ IDVENDITET, '' FATTURARE_SN, '' CONFERMATO_SN, '' DEFINITIVO_SN,

testata.No_ FULLNUMDOC,testata.[posting Date] DATDOC,'' ANNODOC,testata.No_ NUMDOC,acc.codcf CODICECLIFO,testata.[Bill_Pay-to Name] RAGIONESOC,
testata.[Bill_Pay-to Country_Reg_ Code]NAZIONE,
acc.CODIND CODINDSP,'' FATTURAREA, '' FATTURAREALTER, '' SEGNALATORE, '' SEGNALATORE_RS,
'' NUMERORIGHE,
'' DATACR, '' DATAVR,
'' NRRIGA, DET.[Unit of Measure Code] CODICEUNIMI, DET.No_ IDMAGAZZ,DET.[Cross-Reference No_] MODELLO, DET.Quantity QTAUNI, DET.Quantity QTATOT, '' QTADAC, '' PREZZOUNI, 
'' PREZZOTOT, '' VALORE, '' DATACR_DET, '' DATAVR_DET, '' PREZZONET, 
'' DATA_RICHIESTA, '' DATA_CONFERMA, '' ID_OC, '' TIPO_OC, '' FULLNUMDOC_OC, '' DATDOC_OC, '' ANNODOC_OC, '' NUMDOC_OC, '' DATARIF_OC, '' DATACR_OC, '' DATAVR_OC, 
testata.[Your Reference] RIFERIMENTO, ente.[MTP Customer Line No_] RIFERIMENTORIGA,
acc.CODICE ACCESSORISTA,testata.[Ship-to Name] DESTINAZIONE

from [prod].[dbo].[METALPLUS$EOS CWS Shipment Header$a879d9e1-a8d9-4dc8-87d8-69d278c5e003] testata WITH (NOLOCK)
inner join ACCESSORISTI acc WITH (NOLOCK) on acc.[Ship-to Code]=testata.[Ship-to Code] COLLATE SQL_Latin1_General_CP1_CI_AS
INNER JOIN [prod].[dbo].[METALPLUS$EOS CWS Shipment Line$a879d9e1-a8d9-4dc8-87d8-69d278c5e003] DET  WITH (NOLOCK) ON DET.[document no_]=testata.No_
left outer join [prod].[dbo].[METALPLUS$EOS CWS Shipment Line$acfbaca5-f819-4981-a342-d769a95abeb3] ente WITH (NOLOCK) on ente.[Document No_]=testata.No_ AND ente.[Line No_]=DET.[Line No_]
inner join [prod].[dbo].[METALPLUS$Reason Code$437dbf0e-84ff-417a-965d-ed2bb9650972] rea WITH (NOLOCK) ON rea.Code = testata.[Reason Code]

--INNER JOIN [PROD].[dbo].[MetalPlus$Item Cross Reference$437dbf0e-84ff-417a-965d-ed2bb9650972] CROS WITH(NOLOCK) ON CROS.[Item No_]=DET.No_ and CROS.[Cross-Reference Type No_]=DET.[Destination No_]

where det.correction = 0 
