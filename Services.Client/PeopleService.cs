using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services.Client
{
    public class PeopleService<T> : ICrudService<T> where T : Person
    {
        private HttpClient _client;
        private string Controller { get; }

        public PeopleService(string controller)
        {
            Controller = controller;
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:49513");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("gzip"));
        }

        public int Create(T entity)
        {
            //var response = _client.PostAsJsonAsync();
            return 0;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Read()
        {
            throw new NotImplementedException();
        }

        public async void Update(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(T entity)
        {
            var response = await _client.PostAsJsonAsync($"/api/{Controller}", entity);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<int>();
            }
            return 0;
        }

        public async Task<T> ReadAsync(int id)
        {
            var response = await _client.GetAsync($"/api/{Controller}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            return null;
        }

        public async Task<IEnumerable<T>> ReadAsync()
        {
            var response = await _client.GetAsync($"/api/{Controller}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<T>>();
            }
            return null;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            var response = await _client.PutAsJsonAsync($"/api/{Controller}/{id}", entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"/api/{Controller}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
