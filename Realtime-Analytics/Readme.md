# City and County of Denver Smart City Proof of Concept(PoC) - Stream Analytics Model

**Proposed Azure Techincal Design for Stream Analytics model**

![alt text](https://github.com/smartcitypoc/smartcitypoc/blob/master/Realtime-Analytics/Images/Proposed_Azure_Technical_Design_StreamAnalytics.png)

**Use Case 2: Develop real-time visualizations and dashboards based on events produced by IoT devices such as weather sensors, traffic signals etc. to analyze and improve security, safety and well-being of Denver citizens.**

To build stream analytics models, DMI used a custom simulator to simulate the data that is required for the real-time analytics. Leveraging this sample datasets, we built Azure Stream Analytics queries  analyze weather patterns and traffic congestion in a specific neighborhood within a particular timeframe. In order to build the Stream Analytics components, we leveraged Azure IoT hub, Azure Stream Analytics, and Power BI.

***Data Inputs:*** 

- Weather Data Simulator
DMI developed a light weight weather data simulator that will act as weather sensors, emitting `deviceId`, `location`, `visibility`, `DryBulbFarenheit`, `WetBulbFarenheit`, `DewPointFarenheit`, `RelativeHumidity`, `WindSpeed`, `WindDirection`, `StationPressure`, `Altimeter` as data points. This telemetry data will be ingested into Azure IoT hub service and will made available to Azure Stream Analytics for further processing and transformation to produce real-time alerts, visualizations and dashboards.




