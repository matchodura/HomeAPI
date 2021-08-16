using HomeAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeAPI.Helpers
{
    public class SensorDataLogging
    {
        public SensorDataLogging()
        {

        }

        public async Task<DHTSensor> GetDHTData(string calledBy)
        {
            string responseMessage = "";
            string clientAdress = Constants.Constants.NODEMCU_IP_ADDRESS;
            int timeout = 10;

            var client = new HttpClient()
            {
                BaseAddress = new Uri(clientAdress),
                Timeout = TimeSpan.FromSeconds(timeout)
            };

            DHTSensor dht = new DHTSensor();

            try
            {
                HttpResponseMessage response = await client.GetAsync(clientAdress + "/values/dht");
                response.EnsureSuccessStatusCode();
                responseMessage = await response.Content.ReadAsStringAsync();

                if (response != null)
                {
                    dht = JsonConvert.DeserializeObject<DHTSensor>(responseMessage);
                    dht.MeasureTime = DateTime.Now;
                    dht.CalledBy = calledBy;
                }

            }

            catch (HttpRequestException e)
            {
                responseMessage = e.Message;
            }

            return dht;
        }


        public async Task<LightSensor> GetLightSensorData(string calledBy)
        {
            string responseMessage = "";
            string clientAdress = Constants.Constants.NODEMCU_IP_ADDRESS;
            int timeout = 10;

            var client = new HttpClient()
            {
                BaseAddress = new Uri(clientAdress),
                Timeout = TimeSpan.FromSeconds(timeout)
            };

            LightSensor lightSensor = new LightSensor();

            try
            {
                HttpResponseMessage response = await client.GetAsync(clientAdress + "/values/light");
                response.EnsureSuccessStatusCode();
                responseMessage = await response.Content.ReadAsStringAsync();

                if (response != null)
                {
                    lightSensor = JsonConvert.DeserializeObject<LightSensor>(responseMessage);
                    lightSensor.MeasureTime = DateTime.Now;
                    lightSensor.CalledBy = calledBy;
                }

            }

            catch (HttpRequestException e)
            {
                responseMessage = e.Message;
            }

            return lightSensor;
        }


        public async Task<RainSensor> GetRainData(string calledBy)
        {
            string responseMessage = "";
            string clientAdress = Constants.Constants.NODEMCU_IP_ADDRESS;
            int timeout = 10;

            var client = new HttpClient()
            {
                BaseAddress = new Uri(clientAdress),
                Timeout = TimeSpan.FromSeconds(timeout)
            };

            RainSensor rainSensor = new RainSensor();

            try
            {
                HttpResponseMessage response = await client.GetAsync(clientAdress + "/values/rain");
                response.EnsureSuccessStatusCode();
                responseMessage = await response.Content.ReadAsStringAsync();

                if (response != null)
                {
                    rainSensor = JsonConvert.DeserializeObject<RainSensor>(responseMessage);
                    rainSensor.MeasureTime = DateTime.Now;
                    rainSensor.CalledBy = calledBy;
                }

            }

            catch (HttpRequestException e)
            {
                responseMessage = e.Message;
            }



            return rainSensor;
        }

    }
}
