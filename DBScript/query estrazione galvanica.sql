                            select sum(mf.qta)qta,sum(mf.qtadater)qtadater,
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
                                  left join ap_galvanica_piano gp on gp.idmagazz = LAN.IDMAGAZZ and gp.idmagazz_wip = mod.idmagazz and gp.datagalvanica = to_date('15/06/2019','DD/MM/YYYY')
                            where 
                            mf.idtabfas in ('0000000046','0000000272','0000000273','0000000606')
                            and mf.qtadater > 0
                            and mf.datamovfase < to_date('15/06/2019 23:59:59','DD/MM/YYYY HH24:MI:SS')
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

                            select sum(mf.qta),sum(mf.qtadater),
                                        MODLAN.IDMAGAZZ AS IDMAGAZZ_LANCIO,
                                        MODLAN.MODELLO AS MODELLO_LANCIO,
                                        MOD.IDMAGAZZ AS IDMAGAZZ_WIP,
                                        MOD.MODELLO AS MODELLO_WIP,
                                        MOD.SUPERFICIE,
                                        am.pezzibarra,
                                        fo.ordine,
                                        trim(cli.ragionesoc) REPARTO,
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
                                  left join ap_galvanica_piano gp on gp.idmagazz = LAN.IDMAGAZZ and gp.idmagazz_wip = mod.idmagazz and gp.datagalvanica = to_date('15/06/2019','DD/MM/YYYY')
                            where 
                            mf.idtabfas in ('0000000046','0000000272','0000000273','0000000606')
                            and mf.qtadater > 0
                            and mf.datamovfase < to_date('15/06/2019 23:59:59','DD/MM/YYYY HH24:MI:SS')
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
                                        gp.idgalvapiano,
                                        cli.ragionesoc;