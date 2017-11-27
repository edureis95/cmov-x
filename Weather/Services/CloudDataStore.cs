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
        List<City> cities;
        public List<Item> items;

        public CloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            cities = new List<City>();
            items = new List<Item>();
        }

        public async Task<List<City>> GetCityAsync(bool forceRefresh = true)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                cities.Clear();
                foreach (var item in items)
                {  
                    var json = await client.GetStringAsync($"v1/current.json?key=27dee16894ba4fe797995725172411&q=" + item.Description);
                    var city = await Task.Run(() => JsonConvert.DeserializeObject<City>(json));
                    city.Id = item.Id;
                    cities.Add(city);
                }
            }
            return cities;
        }

        public async Task<PastDay> GetCityAsync(string id,string date)
        {
            if ( CrossConnectivity.Current.IsConnected)
            {
           
                var json = await client.GetStringAsync($"v1/history.json?key=27dee16894ba4fe797995725172411&q="+id+"&dt="+date);

                var city = await Task.Run(() => JsonConvert.DeserializeObject<PastDay>(json));
                return city;

            }
            return null;
        }

   
        public async Task<bool> AddCityAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
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

        public void removeItemById(string Id)
        {
            items.Remove(items.Find(Item => Item.Id == Id));
        }
    }
}
