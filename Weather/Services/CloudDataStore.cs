using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Weather
{
    public class CloudDataStore
    {
        HttpClient client;
        City city;

        public CloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            city = new City();
        }

        public async Task<City> GetCityAsync(bool forceRefresh = false)
        {
            Console.WriteLine("Entrou aqui");
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"v1/current.json?key=27dee16894ba4fe797995725172411&q=Porto");
                Console.WriteLine(json);
                city = await Task.Run(() => JsonConvert.DeserializeObject<City>(json));
          
            }
            return city;
        }

        public async Task<City> GetCityAsync(string id)
        {
            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"v1/current.json?key=27dee16894ba4fe797995725172411&q=Porto");
                
                return await Task.Run(() => JsonConvert.DeserializeObject<City>(json));
            }
            return null;
        }

        public async Task<bool> AddCityAsync(City city)
        {
            if (city == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedCity = JsonConvert.SerializeObject(city);

            var response = await client.PostAsync($"api/item", new StringContent(serializedCity, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        /*public async Task<bool> UpdateCityAsync(City city)
        {
            if (city == null || city.Location == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedCity = JsonConvert.SerializeObject(city);
            var buffer = Encoding.UTF8.GetBytes(serializedCity);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/item/{city.location}"), byteContent);
            return response.IsSuccessStatusCode;
        }*/

        public async Task<bool> DeleteCityAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !CrossConnectivity.Current.IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/item/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
