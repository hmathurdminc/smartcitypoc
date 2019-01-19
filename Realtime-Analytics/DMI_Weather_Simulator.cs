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
