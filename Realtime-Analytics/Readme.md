# City and County of Denver Smart City Proof of Concept(PoC) - Stream Analytics Model

**Proposed Azure Techincal Design for Stream Analytics model**

![alt text](https://github.com/smartcitypoc/smartcitypoc/blob/master/Realtime-Analytics/Images/Proposed_Azure_Technical_Design_StreamAnalytics.png)

**Use Case 2: Develop real-time visualizations and dashboards based on events produced by IoT devices such as weather sensors, traffic signals etc. to analyze and improve security, safety and well-being of Denver citizens.**

To build stream analytics models, DMI used a custom simulator to simulate the data that is required for the real-time analytics. Leveraging this sample datasets, we built Azure Stream Analytics queries  analyze weather patterns and traffic congestion in a specific neighborhood within a particular timeframe. In order to build the Stream Analytics components, we leveraged Azure IoT hub, Azure Stream Analytics, and Power BI.

***Data Inputs:*** 

- Weather Data Simulator
DMI developed a light weight weather data simulator that will act as weather sensors, emitting `deviceId`, `location`, `visibility`, `DryBulbFarenheit`, `WetBulbFarenheit`, `DewPointFarenheit`, `RelativeHumidity`, `WindSpeed`, `WindDirection`, `StationPressure`, `Altimeter` as data points. This telemetry data will be ingested into Azure IoT hub service and will made available to Azure Stream Analytics for further processing and transformation to produce real-time alerts, visualizations and dashboards.
Below is the example code for weather data simulator.

```
-----------------------------------------------------------------------------------------
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedDevice
{
    class Program
    {
        private static DeviceClient DMI_DeviceClient;
        private readonly static string DeviceID = "DMI-Test-Device";
        private readonly static string IoTHubURL = "DMITestHub2114285602.azure-devices.net";
        // Primary key for the device from IoT hub in the portal. 
        private readonly static string Device_Key = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
        private readonly static string currentLocation = "Intersection:E16 th Avenue";
        private static void Main(string[] args)
        {
            Console.WriteLine("DMI Weather Data Simulator : Simulated device\n"); 
            DMI_DeviceClient = DeviceClient.Create(IoTHubURL, new DeviceAuthenticationWithRegistrySymmetricKey(DeviceID, Device_Key), TransportType.Mqtt);
            SendDeviceToCloudMessagesAsync();
            Console.WriteLine("Press the Enter key to stop.");
            Console.ReadLine();
        }
        private static async void SendDeviceToCloudMessagesAsync()
        {
            double minTemperature = 38;
            double minHumidity = 60;
            double minVisibility = 0;
            double DryBulbFarenheit = -18;
            double WetBulbFarenheit = -5;
            double DewPointFarenheit = -17;
            double RelativeHumidity = 1;
            double WindSpeed = 1;
            int WindDirection = 1;
            double StationPressure = 25;
            double SeaLevelPressure = 30;
            double Altimeter = 30;
                        

            Random rand = new Random();

            while (true)
            {
                double currentTemperature = minTemperature + rand.NextDouble() * 10;
                double currentHumidity = minHumidity + rand.NextDouble() * 20;
                double currentVisibility = minVisibility + rand.NextDouble() * 30;
                double currentDryBulbFarenheit = DryBulbFarenheit + rand.NextDouble() * 15;
                double currentWetBulbFarenheit = WetBulbFarenheit + rand.NextDouble() * 15;
                double currentWetDewPointFarenheit = DewPointFarenheit + rand.NextDouble() * 15;
                double currentRelativeHumidity = RelativeHumidity + rand.NextDouble() * 20;
                double currentWindSpeed = WindSpeed + rand.NextDouble() * 25;
                int     currentWindDirection = WindDirection + rand.Next() * 25;
                double currentStationPressure = StationPressure + rand.NextDouble() * 25;
                double currentSeaLevelPressure = SeaLevelPressure + rand.NextDouble() * 25;
                double currentAltimeter = Altimeter + rand.NextDouble() * 25;
                string infoString;
                string levelValue;
                

 

                var telemetryDataPoint = new
                {
                    deviceId = DeviceID,
		      temperature = currentTemperature, 	
		      messagestate = infoString,	
                    location = currentLocation,
                    visibility = currentVisibility,
                    DryBulbFarenheit = currentDryBulbFarenheit,
                    WetBulbFarenheit = currentWetBulbFarenheit,
                    DewPointFarenheit = currentWetDewPointFarenheit,
                    RelativeHumidity = currentRelativeHumidity,
                    WindSpeed = currentWindSpeed,
                    WindDirection = currentWindDirection,
                    StationPressure = currentStationPressure,
                    Altimeter = currentAltimeter,
                    
                };
                var telemetryDataString = JsonConvert.SerializeObject(telemetryDataPoint);

                //set the body of the message to the serialized value of the telemetry data
                var message = new Message(Encoding.ASCII.GetBytes(telemetryDataString));
                message.Properties.Add("level", levelValue);

                await DMI_DeviceClient.SendEventAsync(message);
                Console.WriteLine("{0} > Sent message: {1}", DateTime.Now, telemetryDataString);

                await Task.Delay(1000);
            }
        }
    }
}
```




