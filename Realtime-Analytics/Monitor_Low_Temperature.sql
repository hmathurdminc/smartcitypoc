SELECT
    System.timestamp AS OutputTime,
    MIN(temperature) AS minTemperature
    MAX(temperature) AS maxTemperature
INTO
    [PowerBIOutputAlias]
FROM
    [DMIInputAlias]
GROUP BY TumblingWindow (second,60), OutputTime  
HAVING MIN(temperature)<40 
GROUP BY TumblingWindow (second,60), OutputTime  
 
