using System;
using System.ComponentModel.Design;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient htppClient, IConfiguration configuration)
        {
            _httpClient=htppClient;
            _configuration=configuration;
        }
        public async Task SendPlatformToCommand(PlatformReadDto platform)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platform),
                Encoding.UTF8,
                "application/json");

            var response= await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpContent);

            if(response.IsSuccessStatusCode)
                 Console.WriteLine("Sync post to Comman Service was OK");
            else
                 Console.WriteLine("Sync post to Comman Service was Not OK");
            
        }
    }
}