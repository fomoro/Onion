﻿using Miles.Booking.Domain.Entities;
using Miles.Booking.Repository;
using Newtonsoft.Json;
using System.Text;

namespace Miles.Booking.Service.CoursesProvider
{
    public class CoursesProvider : ICoursesProvider
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CoursesProvider(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<(bool IsSuccess, int? Id)> AddAsync(Course course)
        {
            var client = httpClientFactory.CreateClient("coursesService");
            var body = new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/courses", body);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<int?>(content);
                return (true, result);
            }
            return (false, null);
        }

        public async Task<ICollection<Course>> GetAllAsync()
        {
            var client = httpClientFactory.CreateClient("coursesService");
            var response = await client.GetAsync("api/courses");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ICollection<Course>>(content);
                return result;
            }
            return null;
        }

        public async Task<Course> GetAsync(int id)
        {
            var client = httpClientFactory.CreateClient("coursesService");
            var response = await client.GetAsync($"api/courses/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Course>(content);
                return result;
            }
            return null;
        }

        public async Task<ICollection<Course>> SearchAsync(string search)
        {
            var client = httpClientFactory.CreateClient("coursesService");
            var response = await client.GetAsync($"api/courses/search/{search}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ICollection<Course>>(content);
                return result;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(int id, Course course)
        {
            var client = httpClientFactory.CreateClient("coursesService");
            var body = new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"api/courses/{id}", body);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
