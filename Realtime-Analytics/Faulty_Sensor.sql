SELECT
     t1.time
     t1.dspl As SensorName
INTO
     PowerBIOutputAlias
FROM
    DMIInputAlias t1 TIMESTAMP BY time
LEFT OUTER JOIN  DMIInputAlias t2 TIMESTAMP BY time
ON
    t1.dspl=t2.dspl AND
    DATEDIFF(second,t1,t2) BETWEEN 1 and 30
WHERE t2.dspl IS NULL