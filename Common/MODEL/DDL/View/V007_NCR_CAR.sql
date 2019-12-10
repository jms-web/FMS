USE [FMS] 
GO

/****** Object:  View [dbo].[V007_NCR_CAR]    Script Date: 2019/12/04 11:10:27 ******/
SET
  ANSI_NULLS 
    ON 
GO

SET
  QUOTED_IDENTIFIER 
    ON 
GO

ALTER VIEW [dbo].[V007_NCR_CAR] AS 
SELECT
    HOKOKU_NO
  , isnull((SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI WHERE SYONIN_HOKOKUSYO_ID = 1 AND HOKOKU_NO = V002.HOKOKU_NO AND SYONIN_HANTEI_KB = '0'), 999) AS SYONIN_JUN
  , isnull((SELECT SYONIN_NAIYO FROM M014_SYONIN_ROUT WHERE SYONIN_HOKOKUSYO_ID = 1 AND SYONIN_JUN = isnull((SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI WHERE SYONIN_HOKOKUSYO_ID = 1 AND HOKOKU_NO = V002.HOKOKU_NO AND SYONIN_HANTEI_KB = '0'), 0))
  , (SELECT SYONIN_NAIYO FROM M014_SYONIN_ROUT WHERE SYONIN_HOKOKUSYO_ID = 1 AND SYONIN_JUN = 999)) AS SYONIN_NAIYO
  , 1 AS SYONIN_HOKOKUSYO_ID
  , (SELECT SYONIN_HOKOKUSYO_NAME FROM M013_SYONIN_HOKOKU WHERE SYONIN_HOKOKUSYO_ID = 1) AS SYONIN_HOKOKUSYO_NAME
  , (SELECT SYONIN_HOKOKUSYO_R_NAME FROM M013_SYONIN_HOKOKU WHERE SYONIN_HOKOKUSYO_ID = 1) AS SYONIN_HOKOKUSYO_R_NAME
  , isnull((SELECT SYAIN_ID FROM D004_SYONIN_J_KANRI WHERE SYONIN_HOKOKUSYO_ID = 1 AND HOKOKU_NO = V002.HOKOKU_NO AND SYONIN_JUN = (SELECT MIN(SYONIN_JUN) FROM D004_SYONIN_J_KANRI WHERE SYONIN_HOKOKUSYO_ID = 1 AND HOKOKU_NO = V002.HOKOKU_NO AND SYONIN_HANTEI_KB = '0')), '') AS GEN_TANTO_ID
  , isnull((SELECT SIMEI FROM M004_SYAIN WHERE SYAIN_ID = (SELECT SYAIN_ID FROM D004_SYONIN_J_KANRI WHERE SYONIN_HOKOKUSYO_ID = 1 
            AND HOKOKU_NO = V002.HOKOKU_NO 
            AND SYONIN_JUN = ( 
              SELECT
                  MIN(SYONIN_JUN) 
              FROM
                D004_SYONIN_J_KANRI 
              WHERE
                SYONIN_HOKOKUSYO_ID = 1 
                AND HOKOKU_NO = V002.HOKOKU_NO 
                AND SYONIN_HANTEI_KB = '0'
            )
        )
    ) 
    , ''
  ) AS GEN_TANTO_NAME                             --承認担当者名
  , ISNULL( 
    ( 
      SELECT
          MAX(UPD_YMDHNS) 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 1 
        AND HOKOKU_NO = V002.HOKOKU_NO 
        AND SYONIN_HANTEI_KB = '1'
    ) 
    , ''
  ) AS SYONIN_YMDHNS                              --承認日時（処置実施日および前処置実施日）
  , CASE CLOSE_FG 
    WHEN '0' THEN dbo.SC02_GET_TAIRYU_NISSU( 
      '1'
      , ( 
        SELECT
            MAX( 
            CASE 
              WHEN UPD_YMDHNS = '' 
                THEN ADD_YMDHNS 
              ELSE UPD_YMDHNS 
              END
          ) 
        FROM
          D004_SYONIN_J_KANRI 
        WHERE
          SYONIN_HOKOKUSYO_ID = 1 
          AND HOKOKU_NO = V002.HOKOKU_NO 
          AND SYONIN_HANTEI_KB = '0'
      ) 
      , CONVERT(nvarchar, GETDATE(), 112)
    ) 
    ELSE '0' 
    END AS TAIRYU_NISSU                           --滞留日数
  , CASE CLOSE_FG 
    WHEN '0' THEN CASE 
      WHEN dbo.SC02_GET_TAIRYU_NISSU( 
        '1'
        , ( 
          SELECT
              MAX( 
              CASE 
                WHEN UPD_YMDHNS = '' 
                  THEN ADD_YMDHNS 
                ELSE UPD_YMDHNS 
                END
            ) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 1 
            AND HOKOKU_NO = V002.HOKOKU_NO 
            AND SYONIN_HANTEI_KB = '0'
        ) 
        , CONVERT(nvarchar, GETDATE(), 112)
      ) >= ( 
        SELECT
            KEIKOKU_TAIRYU_NISSU 
        FROM
          M014_SYONIN_ROUT 
        WHERE
          SYONIN_HOKOKUSYO_ID = 1 
          AND SYONIN_JUN = ( 
            SELECT
                MAX(SYONIN_JUN) 
            FROM
              D004_SYONIN_J_KANRI 
            WHERE
              SYONIN_HOKOKUSYO_ID = 1 
              AND HOKOKU_NO = V002.HOKOKU_NO 
              AND SYONIN_HANTEI_KB = '0'
          )
      ) 
        THEN '1' 
      ELSE '0' 
      END 
    ELSE 0 
    END AS TAIRYU_FG                              --滞留フラグ
  , V002.KISYU_ID                                 --機種ID
  --,V002.KISYU							--機種
  , V002.KISYU_NAME                               --機種名
  , V002.BUHIN_BANGO                              --部品番号
  , V002.BUHIN_NAME                               --部品名
  , V002.GOKI                                     --号機
  , V002.SYANAI_CD                                --社内コード
  , V002.FUTEKIGO_KB                              --不適合区分
  , V002.FUTEKIGO_NAME                            --不適合区分名
  , V002.FUTEKIGO_S_KB                            --不適合詳細区分
  , V002.FUTEKIGO_S_NAME                          --不適合詳細区分名
  , V002.FUTEKIGO_JYOTAI_KB                       --不適合状態区分
  , V002.FUTEKIGO_JYOTAI_NAME                     --不適合状態区分
  , V002.JIZEN_SINSA_HANTEI_KB                    --事前審査判定区分
  , V002.JIZEN_SINSA_HANTEI_NAME                  --事前審査判定区分名
  , V002.ZESEI_SYOCHI_YOHI_KB                     --是正処置要否区分
  , V002.ZESEI_SYOCHI_YOHI_NAME                   --是正処置要否区分名
  , V002.SAISIN_IINKAI_HANTEI_KB                  --再審委員会判定区分
  , V002.SAISIN_IINKAI_HANTEI_NAME                --再審委員会判定区分名
  , V002.KENSA_KEKKA_KB                           --検査結果区分
  , V002.KENSA_KEKKA_NAME                         --検査結果区分名
  , V002.KONPON_YOIN_KB1                          --根本要因区分1
  , V002.KONPON_YOIN_NAME1                        --根本要因区分名1
  , V002.KONPON_YOIN_KB2                          --根本要因区分2
  , V002.KONPON_YOIN_NAME2                        --根本要因区分名2
  , V002.KISEKI_KOTEI_KB                          --帰責工程区分
  , V002.KISEKI_KOTEI_NAME                        --帰責工程区分名
  , '' AS SYOCHI_YOTEI_YMD                        --処置予定日
  , isnull( 
    ( 
      SELECT
          SUBSTRING(SYONIN_YMDHNS, 1, 8) 
      FROM
        V003_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 1 
        AND HOKOKU_NO = V002.HOKOKU_NO 
        AND SYONIN_JUN = 10
    ) 
    , ''
  ) AS KISO_YMD                                   --起草日
  , ( 
    SELECT
        SYAIN_ID 
    FROM
      V003_SYONIN_J_KANRI 
    WHERE
      SYONIN_HOKOKUSYO_ID = 1 
      AND HOKOKU_NO = V002.HOKOKU_NO 
      AND SYONIN_JUN = 10
  ) AS KISO_TANTO_ID                              --起草担当者ID
  , ( 
    SELECT
        SYAIN_NAME 
    FROM
      V003_SYONIN_J_KANRI 
    WHERE
      SYONIN_HOKOKUSYO_ID = 1 
      AND HOKOKU_NO = V002.HOKOKU_NO 
      AND SYONIN_JUN = 10
  ) AS KISO_TANTO_NAME                            --起草担当者名
  , CLOSE_FG                                      --クローズフラグ
  , CASE ( 
      SELECT
          SASIMODOSI_FG 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 1 
        AND HOKOKU_NO = V002.HOKOKU_NO 
        AND SYONIN_JUN = ( 
          SELECT
              MAX(SYONIN_JUN) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 1 
            AND HOKOKU_NO = V002.HOKOKU_NO
        )
    ) 
    WHEN '0' THEN 0 
    ELSE isnull( 
      ( 
        SELECT
            SYONIN_JUN 
        FROM
          R001_HOKOKU_SOUSA 
        WHERE
          SYONIN_HOKOKUSYO_ID = 1 
          AND HOKOKU_NO = V002.HOKOKU_NO 
          AND SOUSA_KB = '3' 
          AND ADD_YMDHNS = ( 
            SELECT
                MAX(ADD_YMDHNS) 
            FROM
              R001_HOKOKU_SOUSA 
            WHERE
              SYONIN_HOKOKUSYO_ID = 1 
              AND HOKOKU_NO = V002.HOKOKU_NO 
              AND SOUSA_KB = '3'
          )
      ) 
      , 0
    ) 
    END AS SASIMOTO_SYONIN_JUN                    --差戻元承認順
  , CASE ( 
      SELECT
          SASIMODOSI_FG 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 1 
        AND HOKOKU_NO = V002.HOKOKU_NO 
        AND SYONIN_JUN = ( 
          SELECT
              MAX(SYONIN_JUN) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 1 
            AND HOKOKU_NO = V002.HOKOKU_NO
        )
    ) 
    WHEN '0' THEN '' 
    ELSE isnull( 
      ( 
        SELECT
            SYONIN_NAIYO 
        FROM
          M014_SYONIN_ROUT 
        WHERE
          SYONIN_HOKOKUSYO_ID = 1 
          AND SYONIN_JUN = isnull( 
            ( 
              SELECT
                  SYONIN_JUN 
              FROM
                R001_HOKOKU_SOUSA 
              WHERE
                SYONIN_HOKOKUSYO_ID = 1 
                AND HOKOKU_NO = V002.HOKOKU_NO 
                AND SOUSA_KB = '3' 
                AND ADD_YMDHNS = ( 
                  SELECT
                      MAX(ADD_YMDHNS) 
                  FROM
                    R001_HOKOKU_SOUSA 
                  WHERE
                    SYONIN_HOKOKUSYO_ID = 1 
                    AND HOKOKU_NO = V002.HOKOKU_NO 
                    AND SOUSA_KB = '3'
                )
            ) 
            , 0
          )
      ) 
      , ''
    ) 
    END AS SASIMOTO_SYONIN_NAIYO                  --差戻元承認内容（差戻し元ステージ）
  , CASE ( 
      SELECT
          SASIMODOSI_FG 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 1 
        AND HOKOKU_NO = V002.HOKOKU_NO 
        AND SYONIN_JUN = ( 
          SELECT
              MAX(SYONIN_JUN) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 1 
            AND HOKOKU_NO = V002.HOKOKU_NO
        )
    ) 
    WHEN '0' THEN '' 
    ELSE isnull( 
      ( 
        SELECT
            RIYU 
        FROM
          R001_HOKOKU_SOUSA 
        WHERE
          SYONIN_HOKOKUSYO_ID = 1 
          AND HOKOKU_NO = V002.HOKOKU_NO 
          AND SOUSA_KB = '3' 
          AND ADD_YMDHNS = ( 
            SELECT
                MAX(ADD_YMDHNS) 
            FROM
              R001_HOKOKU_SOUSA 
            WHERE
              SYONIN_HOKOKUSYO_ID = 1 
              AND HOKOKU_NO = V002.HOKOKU_NO 
              AND SOUSA_KB = '3'
          )
      ) 
      , 0
    ) 
    END AS RIYU                                   --差戻理由
  , YOKYU_NAIYO                                   --要求内容
  , V002.BUMON_KB
  , V002.BUMON_NAME
  , V002.KOKYAKU_HANTEI_SIJI_KB
  , V002.KOKYAKU_HANTEI_SIJI_NAME
  , V002.KOKYAKU_SAISYU_HANTEI_KB
  , V002.KOKYAKU_SAISYU_HANTEI_NAME
  , V002.DEL_YMDHNS                               --2018.06.05 Add by funato
  , V002.HASSEI_YMD
  , V002.SURYO                                    --2019.02 Add by funato
FROM
  V002_NCR_J AS V002 
UNION ALL 
SELECT
    V005.HOKOKU_NO                                --報告書No
  , isnull( 
    ( 
      SELECT
          MAX(SYONIN_JUN) 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 2 
        AND HOKOKU_NO = V005.HOKOKU_NO 
        AND SYONIN_HANTEI_KB = '0'
    ) 
    , 999
  ) AS SYONIN_JUN                                 --承認順
  , isnull( 
    ( 
      SELECT
          SYONIN_NAIYO 
      FROM
        M014_SYONIN_ROUT 
      WHERE
        SYONIN_HOKOKUSYO_ID = 2 
        AND SYONIN_JUN = isnull( 
          ( 
            SELECT
                MAX(SYONIN_JUN) 
            FROM
              D004_SYONIN_J_KANRI 
            WHERE
              SYONIN_HOKOKUSYO_ID = 2 
              AND HOKOKU_NO = V005.HOKOKU_NO 
              AND SYONIN_HANTEI_KB = '0'
          ) 
          , 0
        )
    ) 
    , ( 
      SELECT
          SYONIN_NAIYO 
      FROM
        M014_SYONIN_ROUT 
      WHERE
        SYONIN_HOKOKUSYO_ID = 1 
        AND SYONIN_JUN = 999
    )
  ) AS SYONIN_NAIYO                               --承認内容（ステージ）
  , 2 AS SYONIN_HOKOKUSYO_ID                      --承認報告書ID
  , ( 
    SELECT
        SYONIN_HOKOKUSYO_NAME 
    FROM
      M013_SYONIN_HOKOKU 
    WHERE
      SYONIN_HOKOKUSYO_ID = 2
  ) AS SYONIN_HOKOKUSYO_NAME                      --承認報告書名
  , ( 
    SELECT
        SYONIN_HOKOKUSYO_R_NAME 
    FROM
      M013_SYONIN_HOKOKU 
    WHERE
      SYONIN_HOKOKUSYO_ID = 2
  ) AS SYONIN_HOKOKUSYO_R_NAME                    --承認報告書略名
  , isnull( 
    ( 
      SELECT
          SYAIN_ID 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 2 
        AND HOKOKU_NO = V005.HOKOKU_NO 
        AND SYONIN_JUN = ( 
          SELECT
              MIN(SYONIN_JUN) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 2 
            AND HOKOKU_NO = V005.HOKOKU_NO 
            AND SYONIN_HANTEI_KB = '0'
        )
    ) 
    , 0
  ) AS GEN_TANTO_ID                               --承認担当者ID（現処置担当者ID）
  , isnull( 
    ( 
      SELECT
          SIMEI 
      FROM
        M004_SYAIN 
      WHERE
        SYAIN_ID = ( 
          SELECT
              SYAIN_ID 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 2 
            AND HOKOKU_NO = V005.HOKOKU_NO 
            AND SYONIN_JUN = ( 
              SELECT
                  MIN(SYONIN_JUN) 
              FROM
                D004_SYONIN_J_KANRI 
              WHERE
                SYONIN_HOKOKUSYO_ID = 2 
                AND HOKOKU_NO = V005.HOKOKU_NO 
                AND SYONIN_HANTEI_KB = '0'
            )
        )
    ) 
    , ''
  ) AS GEN_TANTO_NAME                             --承認担当者名
  , ( 
    CASE 
      WHEN ( 
        SELECT
            TOP 1 SYONIN_JUN 
        FROM
          D004_SYONIN_J_KANRI 
        WHERE
          HOKOKU_NO = V005.HOKOKU_NO 
          AND SYONIN_HOKOKUSYO_ID = 2 
        ORDER BY
          UPD_YMDHNS DESC
      ) = 10 
        THEN ( 
        SELECT
            MAX(UPD_YMDHNS) 
        FROM
          D004_SYONIN_J_KANRI 
        WHERE
          SYONIN_HOKOKUSYO_ID = 1 
          AND HOKOKU_NO = V005.HOKOKU_NO 
          AND SYONIN_JUN = 40
      )                                           -- CAR ST1はNCR ST4の処置日時を参照
      ELSE ( 
        SELECT
            MAX(UPD_YMDHNS) 
        FROM
          D004_SYONIN_J_KANRI 
        WHERE
          SYONIN_HOKOKUSYO_ID = 2 
          AND HOKOKU_NO = V005.HOKOKU_NO 
          AND SYONIN_HANTEI_KB = '1'
      ) 
      END
  ) AS SYONIN_YMDHNS                              --承認日時（処置実施日および前処置実施日）
  --,dbo.SC02_GET_TAIRYU_NISSU('1'
  --					   ,(SELECT MAX(UPD_YMDHNS) FROM D004_SYONIN_J_KANRI
  --						 WHERE SYONIN_HOKOKUSYO_ID = 2
  --						  AND HOKOKU_NO = V005.HOKOKU_NO
  --							AND SYONIN_HANTEI_KB = '0')
  --					   ,CONVERT(nvarchar,GETDATE(),112)
  --						 )AS TAIRYU_NISSU									--滞留日数
  , CASE V005.CLOSE_FG 
    WHEN '0' THEN dbo.SC02_GET_TAIRYU_NISSU( 
      '1'
      , ( 
        SELECT
            MAX( 
            CASE 
              WHEN UPD_YMDHNS = '' 
                THEN ADD_YMDHNS 
              ELSE UPD_YMDHNS 
              END
          ) 
        FROM
          D004_SYONIN_J_KANRI 
        WHERE
          SYONIN_HOKOKUSYO_ID = 2 
          AND HOKOKU_NO = V002.HOKOKU_NO 
          AND SYONIN_HANTEI_KB = '0'
      ) 
      , CONVERT(nvarchar, GETDATE(), 112)
    ) 
    ELSE '0' 
    END AS TAIRYU_NISSU                           --滞留日数
  --,CASE WHEN dbo.SC02_GET_TAIRYU_NISSU('1'
  --									,(SELECT MAX(UPD_YMDHNS) FROM D004_SYONIN_J_KANRI
  --									  WHERE SYONIN_HOKOKUSYO_ID = 2
  --									  AND HOKOKU_NO = V005.HOKOKU_NO
  --													AND SYONIN_HANTEI_KB = '0')
  --									 ,CONVERT(nvarchar,GETDATE(),112)) >= (SELECT KEIKOKU_TAIRYU_NISSU FROM M014_SYONIN_ROUT
  --																			WHERE SYONIN_HOKOKUSYO_ID = 2
  --																			AND SYONIN_JUN = (SELECT MAX(SYONIN_JUN) FROM D004_SYONIN_J_KANRI
  --																							  WHERE SYONIN_HOKOKUSYO_ID = 2
  --																								AND HOKOKU_NO = V005.HOKOKU_NO
  --																								AND SYONIN_HANTEI_KB = '0' )) THEN '1'
  -- ELSE '0' END AS TAIRYU_FG		--滞留フラグ
  , CASE 
    WHEN dbo.SC02_GET_TAIRYU_NISSU( 
      '1'
      , CASE 
        WHEN ISNULL(RTRIM(V005.SYOCHI_YOTEI_YMD), '') = '' 
          THEN ( 
          SELECT
              MAX( 
              CASE 
                WHEN UPD_YMDHNS = '' 
                  THEN ADD_YMDHNS 
                ELSE UPD_YMDHNS 
                END
            ) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 2 
            AND HOKOKU_NO = V005.HOKOKU_NO 
            AND SYONIN_HANTEI_KB = '0'
        ) 
        ELSE V005.SYOCHI_YOTEI_YMD 
        END
      , CONVERT(nvarchar, GETDATE(), 112)
    ) >= ( 
      SELECT
          KEIKOKU_TAIRYU_NISSU 
      FROM
        M014_SYONIN_ROUT 
      WHERE
        SYONIN_HOKOKUSYO_ID = 2 
        AND SYONIN_JUN = ( 
          SELECT
              MAX(SYONIN_JUN) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 2 
            AND HOKOKU_NO = V005.HOKOKU_NO 
            AND SYONIN_HANTEI_KB = '0'
        )
    ) 
      THEN '1' 
    ELSE '0' 
    END AS TAIRYU_FG                              --滞留フラグ
  , V005.KISYU_ID                                 --機種ID
  --,V005.KISYU							--機種
  , V005.KISYU_NAME                               --機種名
  , BUHIN_BANGO                                   --部品番号
  , BUHIN_NAME                                    --部品名
  , V002.GOKI                                     --号機
  , SYANAI_CD                                     --社内コード
  , FUTEKIGO_KB                                   --不適合区分
  , FUTEKIGO_NAME                                 --不適合区分名
  , FUTEKIGO_S_KB                                 --不適合詳細区分
  , FUTEKIGO_S_NAME                               --不適合詳細区分名
  , FUTEKIGO_JYOTAI_KB                            --不適合状態区分
  , FUTEKIGO_JYOTAI_NAME                          --不適合状態区分
  , JIZEN_SINSA_HANTEI_KB                         --事前審査判定区分
  , JIZEN_SINSA_HANTEI_NAME                       --事前審査判定区分名
  , ZESEI_SYOCHI_YOHI_KB                          --是正処置要否区分
  , ZESEI_SYOCHI_YOHI_NAME                        --是正処置要否区分名
  , SAISIN_IINKAI_HANTEI_KB                       --再審委員会判定区分
  , SAISIN_IINKAI_HANTEI_NAME                     --再審委員会判定区分名
  , KENSA_KEKKA_KB                                --検査結果区分
  , KENSA_KEKKA_NAME                              --検査結果区分名
  , V005.KONPON_YOIN_KB1                          --根本要因区分1
  , V005.KONPON_YOIN_NAME1                        --根本要因区分名1
  , V005.KONPON_YOIN_KB2                          --根本要因区分2
  , V005.KONPON_YOIN_NAME2                        --根本要因区分名2
  , V005.KISEKI_KOTEI_KB                          --帰責工程区分
  , V005.KISEKI_KOTEI_NAME                        --帰責工程区分名
  , V005.SYOCHI_YOTEI_YMD                         ---処置予定
  , isnull( 
    ( 
      SELECT
          SUBSTRING(SYONIN_YMDHNS, 1, 8) 
      FROM
        V003_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 2 
        AND HOKOKU_NO = V005.HOKOKU_NO 
        AND SYONIN_JUN = 10
    ) 
    , ''
  ) AS KISO_YMD                                   --起草日
  , ( 
    SELECT
        SYAIN_ID 
    FROM
      V003_SYONIN_J_KANRI 
    WHERE
      SYONIN_HOKOKUSYO_ID = 2 
      AND HOKOKU_NO = V005.HOKOKU_NO 
      AND SYONIN_JUN = 10
  ) AS KISO_TANTO_ID                              --起草担当者ID
  , ( 
    SELECT
        SYAIN_NAME 
    FROM
      V003_SYONIN_J_KANRI 
    WHERE
      SYONIN_HOKOKUSYO_ID = 2 
      AND HOKOKU_NO = V005.HOKOKU_NO 
      AND SYONIN_JUN = 10
  ) AS KISO_TANTO_NAME                            --起草担当者名
  , V005.CLOSE_FG                                 --クローズフラグ
  , CASE ( 
      SELECT
          SASIMODOSI_FG 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 2 
        AND HOKOKU_NO = V005.HOKOKU_NO 
        AND SYONIN_JUN = ( 
          SELECT
              MAX(SYONIN_JUN) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 2 
            AND HOKOKU_NO = V005.HOKOKU_NO
        )
    ) 
    WHEN '0' THEN 0 
    ELSE isnull( 
      ( 
        SELECT
            SYONIN_JUN 
        FROM
          R001_HOKOKU_SOUSA 
        WHERE
          SYONIN_HOKOKUSYO_ID = 2 
          AND HOKOKU_NO = V005.HOKOKU_NO 
          AND SOUSA_KB = '3' 
          AND ADD_YMDHNS = ( 
            SELECT
                MAX(ADD_YMDHNS) 
            FROM
              R001_HOKOKU_SOUSA 
            WHERE
              SYONIN_HOKOKUSYO_ID = 2 
              AND HOKOKU_NO = V002.HOKOKU_NO 
              AND SOUSA_KB = '3'
          )
      ) 
      , 0
    ) 
    END AS SASIMOTO_SYONIN_JUN                    --差戻元承認順
  , CASE ( 
      SELECT
          SASIMODOSI_FG 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 2 
        AND HOKOKU_NO = V005.HOKOKU_NO 
        AND SYONIN_JUN = ( 
          SELECT
              MAX(SYONIN_JUN) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 2 
            AND HOKOKU_NO = V005.HOKOKU_NO
        )
    ) 
    WHEN '0' THEN '' 
    ELSE isnull( 
      ( 
        SELECT
            SYONIN_NAIYO 
        FROM
          M014_SYONIN_ROUT 
        WHERE
          SYONIN_HOKOKUSYO_ID = 2 
          AND SYONIN_JUN = isnull( 
            ( 
              SELECT
                  SYONIN_JUN 
              FROM
                R001_HOKOKU_SOUSA 
              WHERE
                SYONIN_HOKOKUSYO_ID = 2 
                AND HOKOKU_NO = V005.HOKOKU_NO 
                AND SOUSA_KB = '3' 
                AND ADD_YMDHNS = ( 
                  SELECT
                      MAX(ADD_YMDHNS) 
                  FROM
                    R001_HOKOKU_SOUSA 
                  WHERE
                    SYONIN_HOKOKUSYO_ID = 2 
                    AND HOKOKU_NO = V002.HOKOKU_NO 
                    AND SOUSA_KB = '3'
                )
            ) 
            , 0
          )
      ) 
      , ''
    ) 
    END AS SASIMOTO_SYONIN_NAIYO                  --差戻元承認内容（差戻し元ステージ）
  , CASE ( 
      SELECT
          SASIMODOSI_FG 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 2 
        AND HOKOKU_NO = V005.HOKOKU_NO 
        AND SYONIN_JUN = ( 
          SELECT
              MAX(SYONIN_JUN) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 2 
            AND HOKOKU_NO = V005.HOKOKU_NO
        )
    ) 
    WHEN '0' THEN '' 
    ELSE isnull( 
      ( 
        SELECT
            RIYU 
        FROM
          R001_HOKOKU_SOUSA 
        WHERE
          SYONIN_HOKOKUSYO_ID = 2 
          AND HOKOKU_NO = V005.HOKOKU_NO 
          AND SOUSA_KB = '3' 
          AND ADD_YMDHNS = ( 
            SELECT
                MAX(ADD_YMDHNS) 
            FROM
              R001_HOKOKU_SOUSA 
            WHERE
              SYONIN_HOKOKUSYO_ID = 2 
              AND HOKOKU_NO = V002.HOKOKU_NO 
              AND SOUSA_KB = '3'
          )
      ) 
      , 0
    ) 
    END AS RIYU                                   --差戻理由
  , YOKYU_NAIYO                                   --要求内容
  , V005.BUMON_KB
  , V005.BUMON_NAME
  , V002.KOKYAKU_HANTEI_SIJI_KB
  , V002.KOKYAKU_HANTEI_SIJI_NAME
  , V002.KOKYAKU_SAISYU_HANTEI_KB
  , V002.KOKYAKU_SAISYU_HANTEI_NAME
  , V005.DEL_YMDHNS                               --2018.06.05 Add by funato
  , V005.FUTEKIGO_HASSEI_YMD AS HASSEI_YMD
  , V005.SURYO 
FROM
  V005_CAR_J V005 
  LEFT OUTER JOIN V002_NCR_J V002 
    ON V005.HOKOKU_NO = V002.HOKOKU_NO 
UNION ALL 
SELECT
    D007.HOKOKU_NO
  , isnull( 
    ( 
      SELECT
          MAX(SYONIN_JUN) 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 1 
        AND HOKOKU_NO = D007.HOKOKU_NO 
        AND SYONIN_HANTEI_KB = '0'
    ) 
    , 999
  ) AS SYONIN_JUN
  , isnull( 
    ( 
      SELECT
          SYONIN_NAIYO 
      FROM
        M014_SYONIN_ROUT 
      WHERE
        SYONIN_HOKOKUSYO_ID = 3 
        AND SYONIN_JUN = isnull( 
          ( 
            SELECT
                MAX(SYONIN_JUN) 
            FROM
              D004_SYONIN_J_KANRI 
            WHERE
              SYONIN_HOKOKUSYO_ID = 3 
              AND HOKOKU_NO = D007.HOKOKU_NO 
              AND SYONIN_HANTEI_KB = '0'
          ) 
          , 0
        )
    ) 
    , ( 
      SELECT
          SYONIN_NAIYO 
      FROM
        M014_SYONIN_ROUT 
      WHERE
        SYONIN_HOKOKUSYO_ID = 3 
        AND SYONIN_JUN = 999
    )
  ) AS SYONIN_NAIYO
  , 3 AS SYONIN_HOKOKUSYO_ID
  , ( 
    SELECT
        SYONIN_HOKOKUSYO_NAME 
    FROM
      M013_SYONIN_HOKOKU 
    WHERE
      SYONIN_HOKOKUSYO_ID = 3
  ) AS SYONIN_HOKOKUSYO_NAME
  , ( 
    SELECT
        SYONIN_HOKOKUSYO_R_NAME 
    FROM
      M013_SYONIN_HOKOKU 
    WHERE
      SYONIN_HOKOKUSYO_ID = 3
  ) AS SYONIN_HOKOKUSYO_R_NAME                    --承認報告書略名
  , isnull( 
    ( 
      SELECT
          SYAIN_ID 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 3 
        AND HOKOKU_NO = D007.HOKOKU_NO 
        AND SYONIN_JUN = ( 
          SELECT
              MIN(SYONIN_JUN) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 1 
            AND HOKOKU_NO = D007.HOKOKU_NO 
            AND SYONIN_HANTEI_KB = '0'
        )
    ) 
    , ''
  ) AS GEN_TANTO_ID
  , isnull( 
    ( 
      SELECT
          SIMEI 
      FROM
        M004_SYAIN 
      WHERE
        SYAIN_ID = ( 
          SELECT
              SYAIN_ID 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 3 
            AND HOKOKU_NO = D007.HOKOKU_NO 
            AND SYONIN_JUN = ( 
              SELECT
                  MIN(SYONIN_JUN) 
              FROM
                D004_SYONIN_J_KANRI 
              WHERE
                SYONIN_HOKOKUSYO_ID = 3 
                AND HOKOKU_NO = D007.HOKOKU_NO 
                AND SYONIN_HANTEI_KB = '0'
            )
        )
    ) 
    , ''
  ) AS GEN_TANTO_NAME                             --承認担当者名
  , ISNULL( 
    ( 
      SELECT
          MAX(UPD_YMDHNS) 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 1 
        AND HOKOKU_NO = D007.HOKOKU_NO 
        AND SYONIN_HANTEI_KB = '1'
    ) 
    , ''
  ) AS SYONIN_YMDHNS                              --承認日時（処置実施日および前処置実施日）
  , CASE D007.CLOSE_FG 
    WHEN '0' THEN dbo.SC02_GET_TAIRYU_NISSU( 
      '1'
      , ( 
        SELECT
            MAX( 
            CASE 
              WHEN UPD_YMDHNS = '' 
                THEN ADD_YMDHNS 
              ELSE UPD_YMDHNS 
              END
          ) 
        FROM
          D004_SYONIN_J_KANRI 
        WHERE
          SYONIN_HOKOKUSYO_ID = 3 
          AND HOKOKU_NO = V002.HOKOKU_NO 
          AND SYONIN_HANTEI_KB = '0'
      ) 
      , CONVERT(nvarchar, GETDATE(), 112)
    ) 
    ELSE '0' 
    END AS TAIRYU_NISSU
  , CASE D007.CLOSE_FG 
    WHEN '0' THEN CASE 
      WHEN dbo.SC02_GET_TAIRYU_NISSU( 
        '1'
        , ( 
          SELECT
              MAX( 
              CASE 
                WHEN UPD_YMDHNS = '' 
                  THEN ADD_YMDHNS 
                ELSE UPD_YMDHNS 
                END
            ) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 1 
            AND HOKOKU_NO = V002.HOKOKU_NO 
            AND SYONIN_HANTEI_KB = '0'
        ) 
        , CONVERT(nvarchar, GETDATE(), 112)
      ) >= ( 
        SELECT
            KEIKOKU_TAIRYU_NISSU 
        FROM
          M014_SYONIN_ROUT 
        WHERE
          SYONIN_HOKOKUSYO_ID = 3 
          AND SYONIN_JUN = ( 
            SELECT
                MAX(SYONIN_JUN) 
            FROM
              D004_SYONIN_J_KANRI 
            WHERE
              SYONIN_HOKOKUSYO_ID = 3 
              AND HOKOKU_NO = V002.HOKOKU_NO 
              AND SYONIN_HANTEI_KB = '0'
          )
      ) 
        THEN '1' 
      ELSE '0' 
      END 
    ELSE 0 
    END AS TAIRYU_FG                              --滞留フラグ
  , V002.KISYU_ID
  , V002.KISYU_NAME
  , V002.BUHIN_BANGO
  , V002.BUHIN_NAME
  , V002.GOKI
  , V002.SYANAI_CD
  , V002.FUTEKIGO_KB
  , V002.FUTEKIGO_NAME
  , V002.FUTEKIGO_S_KB
  , V002.FUTEKIGO_S_NAME
  , V002.FUTEKIGO_JYOTAI_KB
  , V002.FUTEKIGO_JYOTAI_NAME
  , V002.JIZEN_SINSA_HANTEI_KB
  , V002.JIZEN_SINSA_HANTEI_NAME
  , V002.ZESEI_SYOCHI_YOHI_KB
  , V002.ZESEI_SYOCHI_YOHI_NAME
  , V002.SAISIN_IINKAI_HANTEI_KB
  , V002.SAISIN_IINKAI_HANTEI_NAME
  , V002.KENSA_KEKKA_KB
  , V002.KENSA_KEKKA_NAME
  , V002.KONPON_YOIN_KB1
  , V002.KONPON_YOIN_NAME1
  , V002.KONPON_YOIN_KB2
  , V002.KONPON_YOIN_NAME2
  , V002.KISEKI_KOTEI_KB
  , V002.KISEKI_KOTEI_NAME
  , '' AS SYOCHI_YOTEI_YMD
  , isnull( 
    ( 
      SELECT
          SUBSTRING(SYONIN_YMDHNS, 1, 8) 
      FROM
        V003_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 3 
        AND HOKOKU_NO = V005.HOKOKU_NO 
        AND SYONIN_JUN = 10
    ) 
    , ''
  ) AS KISO_YMD
  , ( 
    SELECT
        SYAIN_ID 
    FROM
      V003_SYONIN_J_KANRI 
    WHERE
      SYONIN_HOKOKUSYO_ID = 1 
      AND HOKOKU_NO = V002.HOKOKU_NO 
      AND SYONIN_JUN = 10
  ) AS KISO_TANTO_ID                              --起草担当者ID
  , ( 
    SELECT
        SYAIN_NAME 
    FROM
      V003_SYONIN_J_KANRI 
    WHERE
      SYONIN_HOKOKUSYO_ID = 1 
      AND HOKOKU_NO = V002.HOKOKU_NO 
      AND SYONIN_JUN = 10
  ) AS KISO_TANTO_NAME                            --起草担当者名
  , D007.CLOSE_FG                                 --クローズフラグ
  , CASE ( 
      SELECT
          SASIMODOSI_FG 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 1 
        AND HOKOKU_NO = V002.HOKOKU_NO 
        AND SYONIN_JUN = ( 
          SELECT
              MAX(SYONIN_JUN) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 1 
            AND HOKOKU_NO = V002.HOKOKU_NO
        )
    ) 
    WHEN '0' THEN 0 
    ELSE isnull( 
      ( 
        SELECT
            SYONIN_JUN 
        FROM
          R001_HOKOKU_SOUSA 
        WHERE
          SYONIN_HOKOKUSYO_ID = 1 
          AND HOKOKU_NO = V002.HOKOKU_NO 
          AND SOUSA_KB = '3' 
          AND ADD_YMDHNS = ( 
            SELECT
                MAX(ADD_YMDHNS) 
            FROM
              R001_HOKOKU_SOUSA 
            WHERE
              SYONIN_HOKOKUSYO_ID = 1 
              AND HOKOKU_NO = V002.HOKOKU_NO 
              AND SOUSA_KB = '3'
          )
      ) 
      , 0
    ) 
    END AS SASIMOTO_SYONIN_JUN                    --差戻元承認順
  , CASE ( 
      SELECT
          SASIMODOSI_FG 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 1 
        AND HOKOKU_NO = V002.HOKOKU_NO 
        AND SYONIN_JUN = ( 
          SELECT
              MAX(SYONIN_JUN) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 1 
            AND HOKOKU_NO = V002.HOKOKU_NO
        )
    ) 
    WHEN '0' THEN '' 
    ELSE isnull( 
      ( 
        SELECT
            SYONIN_NAIYO 
        FROM
          M014_SYONIN_ROUT 
        WHERE
          SYONIN_HOKOKUSYO_ID = 1 
          AND SYONIN_JUN = isnull( 
            ( 
              SELECT
                  SYONIN_JUN 
              FROM
                R001_HOKOKU_SOUSA 
              WHERE
                SYONIN_HOKOKUSYO_ID = 1 
                AND HOKOKU_NO = V002.HOKOKU_NO 
                AND SOUSA_KB = '3' 
                AND ADD_YMDHNS = ( 
                  SELECT
                      MAX(ADD_YMDHNS) 
                  FROM
                    R001_HOKOKU_SOUSA 
                  WHERE
                    SYONIN_HOKOKUSYO_ID = 1 
                    AND HOKOKU_NO = V002.HOKOKU_NO 
                    AND SOUSA_KB = '3'
                )
            ) 
            , 0
          )
      ) 
      , ''
    ) 
    END AS SASIMOTO_SYONIN_NAIYO                  --差戻元承認内容（差戻し元ステージ）
  , CASE ( 
      SELECT
          SASIMODOSI_FG 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 1 
        AND HOKOKU_NO = V002.HOKOKU_NO 
        AND SYONIN_JUN = ( 
          SELECT
              MAX(SYONIN_JUN) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 1 
            AND HOKOKU_NO = V002.HOKOKU_NO
        )
    ) 
    WHEN '0' THEN 0 
    ELSE isnull( 
      ( 
        SELECT
            SYONIN_JUN 
        FROM
          R001_HOKOKU_SOUSA 
        WHERE
          SYONIN_HOKOKUSYO_ID = 1 
          AND HOKOKU_NO = V002.HOKOKU_NO 
          AND SOUSA_KB = '3' 
          AND ADD_YMDHNS = ( 
            SELECT
                MAX(ADD_YMDHNS) 
            FROM
              R001_HOKOKU_SOUSA 
            WHERE
              SYONIN_HOKOKUSYO_ID = 1 
              AND HOKOKU_NO = V002.HOKOKU_NO 
              AND SOUSA_KB = '3'
          )
      ) 
      , 0
    ) 
    END AS SASIMOTO_SYONIN_JUN                    --差戻元承認順
  , CASE ( 
      SELECT
          SASIMODOSI_FG 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 1 
        AND HOKOKU_NO = V002.HOKOKU_NO 
        AND SYONIN_JUN = ( 
          SELECT
              MAX(SYONIN_JUN) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 1 
            AND HOKOKU_NO = V002.HOKOKU_NO
        )
    ) 
    WHEN '0' THEN '' 
    ELSE isnull( 
      ( 
        SELECT
            SYONIN_NAIYO 
        FROM
          M014_SYONIN_ROUT 
        WHERE
          SYONIN_HOKOKUSYO_ID = 1 
          AND SYONIN_JUN = isnull( 
            ( 
              SELECT
                  SYONIN_JUN 
              FROM
                R001_HOKOKU_SOUSA 
              WHERE
                SYONIN_HOKOKUSYO_ID = 1 
                AND HOKOKU_NO = V002.HOKOKU_NO 
                AND SOUSA_KB = '3' 
                AND ADD_YMDHNS = ( 
                  SELECT
                      MAX(ADD_YMDHNS) 
                  FROM
                    R001_HOKOKU_SOUSA 
                  WHERE
                    SYONIN_HOKOKUSYO_ID = 1 
                    AND HOKOKU_NO = V002.HOKOKU_NO 
                    AND SOUSA_KB = '3'
                )
            ) 
            , 0
          )
      ) 
      , ''
    ) 
    END AS SASIMOTO_SYONIN_NAIYO                  --差戻元承認内容（差戻し元ステージ）
  , CASE ( 
      SELECT
          SASIMODOSI_FG 
      FROM
        D004_SYONIN_J_KANRI 
      WHERE
        SYONIN_HOKOKUSYO_ID = 1 
        AND HOKOKU_NO = V002.HOKOKU_NO 
        AND SYONIN_JUN = ( 
          SELECT
              MAX(SYONIN_JUN) 
          FROM
            D004_SYONIN_J_KANRI 
          WHERE
            SYONIN_HOKOKUSYO_ID = 1 
            AND HOKOKU_NO = V002.HOKOKU_NO
        )
    ) 
    WHEN '0' THEN '' 
    ELSE isnull( 
      ( 
        SELECT
            RIYU 
        FROM
          R001_HOKOKU_SOUSA 
        WHERE
          SYONIN_HOKOKUSYO_ID = 1 
          AND HOKOKU_NO = V002.HOKOKU_NO 
          AND SOUSA_KB = '3' 
          AND ADD_YMDHNS = ( 
            SELECT
                MAX(ADD_YMDHNS) 
            FROM
              R001_HOKOKU_SOUSA 
            WHERE
              SYONIN_HOKOKUSYO_ID = 1 
              AND HOKOKU_NO = V002.HOKOKU_NO 
              AND SOUSA_KB = '3'
          )
      ) 
      , 0
    ) 
    END AS RIYU                                   --差戻理由
    ,YOKYU_NAIYO
    ,V002.BUMON_KB
    ,V002.BUMON_NAME
    ,V002.KOKYAKU_HANTEI_SIJI_KB
    ,V002.KOKYAKU_HANTEI_SIJI_NAME
    ,V002.KOKYAKU_SAISYU_HANTEI_KB
    ,V002.KOKYAKU_SAISYU_HANTEI_NAME
    ,V002.DEL_YMDHNS
    ,V002.HASSEI_YMD
    ,V002.SURYO
FROM
  D007_FCR_J AS D007 
  LEFT JOIN V002_NCR_J AS V002 
    ON D007.HOKOKU_NO = V002.HOKOKU_NO 
  LEFT JOIN V005_CAR_J AS V005 
    ON D007.HOKOKU_NO = V005.HOKOKU_NO 
GO
