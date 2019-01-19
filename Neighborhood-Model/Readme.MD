# City and County of Denver Smart City Proof of Concept(PoC) - Reusable Model Development

                          Proposed Azure Techincal Design for Crime Preditcion model

![alt text](https://github.com/smartcitypoc/smartcitypoc/blob/master/Neighborhood-Model/Images/Proposed_Azure_Reference_Architecture_Neighborhood.png) 

***Data Inputs:*** The following two datasets where obtained from the City of Denver Data Repository and utilized to build the Machine Learning model.

 - ****Crime Dataset:**** City of Denver Crime dataset1 includes criminal offenses in the City and County of Denver for the previous five calendar years plus the current year to date. The data is based on the National Incident Based Reporting System (NIBRS) which includes all victims of person crimes and all crimes within an incident.

 - ****Census Neighborhood Demographics Dataset:**** City of Denver Census Neighborhood Demographics (2010) Dataset2 includes the housing and population data of the 2010 Denver census.

 - ***Data Preprocessing:*** Crime dataset was preprocessed by removing the missing data and duplicate records. Additional data fields were derived (`YEAR, DAY OF THE WEEK, HOUR`) from `REPORTED_DATE` in the dataset. Field `TIME` is assigned with label `Morning (6 AM to 12 PM)`, `Afternoon (12 PM to 5 PM)`, `Evening (5 PM to 8 PM)`, and `Night (8 PM to 6 AM)` based on hour.

Crime dataset is aggregated by fields `NEIGHBORHOOD_ID, MONTH, DAY, and TIME` and further joined with Census dataset by the field `NEIGHBORHOOD_ID`. Census dataset was additionally added with field `NEIGHBORHOOD_ID` to match with the Crime dataset for merging.

                          Data preprocessing workflow developed leveraging Azure Machine Learning

![alt text](https://github.com/smartcitypoc/smartcitypoc/blob/master/Neighborhood-Model/Images/Azure_Machine_Learning_Data_Preprocessing_Workflow.png) 


***Correlation Analysis and Feature Selection***

- ****Time of Crime:**** Fields `MONTH, DAY, and TIME` were selected as predictor variables for model building which feature the time of crime.

- ****Location of Crime:**** Field `NEIGHBORHOOD_ID` was included in predictor variables to feature the location element to the crime prediction model.

- ****Neighborhood Demographics:**** Pearson Correlation of multiple demographic features from the Census dataset with crime frequency was derived and analyzed. Correlation value of >=0.3 was set as the threshold to filter the demographic features. Fields selected from Census dataset to build the model were, `VACANTUNITS_2010`, `AGE_22_TO_24`, `AGE_25_TO_29`, `AGE_30_TO_34`, `AGE_20_TO_29`, `AGE_30_TO_39`, `HH_W_NONRELATIVES`, `GQ_OTHER_NONINST`, `VACANT_HU`, `VACANT_FOR_SALE`, `VACANT_SOLD_NOT_OCC`, `RENTED_AGE_15_TO_24`.

- ****Training Dataset:**** Crime data from 2013 to 2017 across 78 Neighborhoods was selected for training the predictive model.

***Documented Algorithms*** 

 - Boosted Decision Tree Regression: Boosted Decision Tree Regression3  Supervised learning method was used to build the model and predict frequency of crimes in a specific location within a particular time. Turning parameters were set as below:
   - Maximum number of leaves per tree : 20.
   - Minimum number of training instances required to form a leaf : 10.
   - Learning rate : 0.2.
   - Total number of trees constructed : 100.


                          Crime Prediction Model Development Workflow using Azure Machine Learning

![alt text](https://github.com/smartcitypoc/smartcitypoc/blob/master/Neighborhood-Model/Images/Azure_Workflow_Model_Development.png) 

***Algorithm Output:*** The algorithm outputs the number of crimes predicted for a particular Neighborhood at a particular time for the year 2018.

 - ***Performance Estimates:***

 - ****Test Data Description:**** Crime data of year 2018 of 78 Neighborhoods was selected as test dataset to evaluate the model prediction performance. 

  - ****Validation:**** Model showed prediction accuracy of `MAE`: 1.8, `RMSE`: 2.5, and `Coefficient of Determination`: 0.51 on test set evaluation.

   - ***Model Output***

   - ****Example Crime Prediction Model Data Output****

     - The Inputs to the crime prediction model are `NEIGHBORHOOD_ID`, `Demographic features of the neighborhood`, `Month`, `Day`, and `Time`. 

  - The Outputs from the model are the predicted number of crimes for the specific neighborhood as shown below.

![alt text](https://github.com/smartcitypoc/smartcitypoc/blob/master/Neighborhood-Model/Images/Neighborhood_Model_Input_Output.png)
