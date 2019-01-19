# City and County of Denver Smart City Proof of Concept(PoC) - Restful Public API in JSON format

**Proposed Azure Based RESTful API Design**

![alt text](https://github.com/smartcitypoc/smartcitypoc/blob/master/RESTful%20API/Images/Proposed_Azure_Restful_API.png)

> **Crime API Specification**

  This API returns the reported crimes between the provided start and end date, user can optionally provide the neighbourhoodID. The API will return maximum of seven days of data irrespective of the end date in case the duration is more than seven days.

1. ****Request****

    `GET /api/crimedata`

    - Parameters Name
      - startDate
      - endDate
      - neighbourhoodID
    - Type
      - String
    - Description
      - Starting date in YYYY-MM-DD format (required parameter)
      - End date in YYYY-MM-DD format (required parameter)
      - id of the neighbourhood (optional parameter)
 
2. ****Response****

    `application/json`
 
3. ****Sample Request****

    https://smartcitydenver.azurewebsites.net/api/crimedata?startDate=2016-12-22&endDate=2016-12-23&neighbourhoodID=five-points

4. ****Example code for Azure Function Rest Endpoints for Crime Data****

    https://github.com/smartcitypoc/smartcitypoc/blob/master/RESTful%20API/crime.csx


 > **Census API Specification**

    This API returns the Census information for the ```neighbourhoodId```.

1. ****Request****

    `GET /api/censusdata`

    - Parameters Name		
      - neighbourhoodID	
    - Type
      - String
    - Description
      - id of the neighbourhood (required parameter)
  
2. ****Response****

    `application/json`
 
3. ***Sample Request***

    https://smartcitydenver.azurewebsites.net/api/censusdata?neighbourhoodID=five-points

4. ****Example code for Azure Function Rest Endpoints for Census Data****

    https://github.com/smartcitypoc/smartcitypoc/blob/master/RESTful%20API/census.csx

 
