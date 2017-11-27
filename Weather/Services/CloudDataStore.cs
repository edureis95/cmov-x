using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;
using System.IO;

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
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "Items");

            if (File.Exists(filename))
            {
                using (var streamReader = new StreamReader(filename))
                {
                    string content = streamReader.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<Item>>(content);
                    if (items == null)
                        items = new List<Item>();
                }
            }
            else items = new List<Item>();
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

        public async Task<List<City>> GetCityAsync(string id)
        {
            if ( CrossConnectivity.Current.IsConnected)
            {

                var json = await client.GetStringAsync($"v1/current.json?key=27dee16894ba4fe797995725172411&q=" + id);

                var city = await Task.Run(() => JsonConvert.DeserializeObject<City>(json));
                cities.Add(city);

            }
            return cities;
        }

   
        public async Task<bool> AddCityAsync(Item item)
        {
            items.Add(item);
            saveItemsToFile();
            return await Task.FromResult(true);
        }

        public void saveItemsToFile()
        {
            var itemsJSON = JsonConvert.SerializeObject(items);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "Items");

            using (var streamWriter = new StreamWriter(filename))
            {
                streamWriter.WriteLine(itemsJSON);
            }
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
            saveItemsToFile();
        }
    }
}
