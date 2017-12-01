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
            string filename = Path.Combine(path, "ListItems");

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
                    City city;
                    try
                    {
                        var json = await client.GetStringAsync($"v1/current.json?key=cd20888511644f0d9ca151930173011&q=" + item.Description);
                        city = await Task.Run(() => JsonConvert.DeserializeObject<City>(json));
                    }
                    catch(Exception exception)
                    {
                        continue;
                    }
                    city.Id = item.Id;
                    cities.Add(city);
                }
            }
            return cities;
        }

        public async Task<List<SearchModel>> Search(string name)
        {
            List<SearchModel> cities = new List<SearchModel>();
            if ( CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"v1/search.json?key=cd20888511644f0d9ca151930173011&q=" + name);

                cities = await Task.Run(() => JsonConvert.DeserializeObject<List<SearchModel>>(json));  
            }
            return cities;
        }

        public async Task<PastDay> GetCityAsync(string id,string date)
        {
            if ( CrossConnectivity.Current.IsConnected)
            {
           
                var json = await client.GetStringAsync($"v1/history.json?key=cd20888511644f0d9ca151930173011&q=" +id+"&dt="+date);

                var city = await Task.Run(() => JsonConvert.DeserializeObject<PastDay>(json));
                return city;

            }
            return null;
        }

        public async Task<ForecastJson> GetForecast(string id)
        {
            if (CrossConnectivity.Current.IsConnected)
            {

                var json = await client.GetStringAsync($"v1/forecast.json?key=cd20888511644f0d9ca151930173011&q=" +id+"&days=7");

                var forecast = await Task.Run(() => JsonConvert.DeserializeObject<ForecastJson>(json));
                return forecast;

            }
            return null;
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
            string filename = Path.Combine(path, "ListItems");

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
        
            items.Remove(items.Find(Item => Item.Description.Contains(Id)));
            saveItemsToFile();

        }
    }
}
