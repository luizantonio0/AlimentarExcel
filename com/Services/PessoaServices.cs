#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using com.Entities;
using Newtonsoft.Json;

namespace com.Services
{
    public class PessoaServices
    {
        private static string URL = "http://localhost:5247/pessoas";
        public async Task<Pessoa> GetPessoaAsync()
        {
            string jsonString;
            try
            {
                HttpClient httpClient = new HttpClient();
                var res = await httpClient.GetAsync(URL);
                Console.WriteLine(res.StatusCode + "\n");
                if (!res.IsSuccessStatusCode)
                {
                    Console.WriteLine("Erro ao consumir API: " + res.StatusCode);
                }
                jsonString = await res.Content.ReadAsStringAsync();

            }
            catch (Exception e)
            {

                throw new Exception("Erro: " + e.Message);
            }
            Pessoa? pessoa = JsonConvert.DeserializeObject<Pessoa>(jsonString);
            if (pessoa == null)
            {
                throw new Exception("Erro: Não foi possível desserializar a resposta para Pessoa.");
            }
            return pessoa;
        } 

        public async Task<List<Pessoa>> GetListPessoaAsync()
        {
            string jsonString;
            try
            {
                HttpClient httpClient = new HttpClient();
                var res = await httpClient.GetAsync(URL);
                Console.WriteLine(res.StatusCode + "\n");
                jsonString = await res.Content.ReadAsStringAsync();

            }
            catch (Exception e)
            {

                throw new Exception("Erro: " + e.Message);
            }
            List<Pessoa>? pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(jsonString);
            if (pessoas == null)
            {
                throw new Exception("Erro: Não foi possível desserializar a resposta para Pessoa.");
            }
            return pessoas;
        } 
    }
}