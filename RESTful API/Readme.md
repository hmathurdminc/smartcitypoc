# City and County of Denver Smart City Proof of Concept(PoC) - Restful Public API in JSON format

**Proposed Azure Based RESTful API Design**

![alt text](https://github.com/smartcitypoc/smartcitypoc/blob/master/RESTful%20API/Images/Proposed_Azure_Restful_API.png)

**Data Inputs:** 

***Crime API Spec***
This API returns the reported crimes between the provided start and end date, user can optionally provide the neighbourhoodID. The API will return maximum of seven days of data irrespective of the end date in case the duration is more than seven days.

****Request****
```GET	/api/crimedata```

- Parameters Name
  - startDate
  - endDate
  - neighbourhoodID
- Type	
- Description
	String	Starting date in YYYY-MM-DD format (required parameter)
	String	End date in YYYY-MM-DD format (required parameter)
	String	id of the neighbourhood (optional parameter)
 
Response
application/json
 
Sample Request – https://smartcitydenver.azurewebsites.net/api/crimedata?startDate=2016-12-22&endDate=2016-12-23&neighbourhoodID=five-points
 
 
Census API Spec
This API returns the Census information for the neighbourhoodId.
Request
GET	/api/censusdata

Parameters Name	Type	Description
neighbourhoodID	String	id of the neighbourhood (required parameter)
 
 
Response
application/json
 
Sample Request – https://smartcitydenver.azurewebsites.net/api/censusdata?neighbourhoodID=five-points
 
