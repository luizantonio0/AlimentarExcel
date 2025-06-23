using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace com.Entities
{
    public class GerarExcel
    {
        //Padrão
        public readonly String[] Scopes = { SheetsService.Scope.Spreadsheets };

        //Qualquer nome
        public readonly string ApplicationName = "Teste";

        //O Id da planilha
        //Está o Id do controle Liberação ponto
        public readonly string SpreadsheetsId = "1m199_EDPHCn_rET8IQVVf-7sZbockIjZ6ahIjJtdzgU";

        //Qual o nome da planilha que deseja modificar
        public readonly string sheet = "teste";
        private SheetsService? service;

        public GerarExcel()
        {
            try
            {
                GoogleCredential credential;
                using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleCredential.FromStream(stream)
                        .CreateScoped(Scopes);
                }

                service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n\n" + e.StackTrace);
            }
        }

        public void Update(List<IList<object>> data)
        {
            if (service == null) throw new InvalidOperationException("SheetsService is not initialized.");

            var dataRange = new ValueRange
            {
                //O range escrito aqui significa quantas linhas forem necessarias a partir da Linha/Coluna A2
                Range = $"{sheet}!A2",
                Values = data
            };

            var batchRequest = new BatchUpdateValuesRequest
            {
                Data = new List<ValueRange> { dataRange },
                ValueInputOption = "USER_ENTERED"
            };

            var batchUpdateRequest = service.Spreadsheets.Values.BatchUpdate(batchRequest, SpreadsheetsId);
            var batchUpdateResponse = batchUpdateRequest.Execute();
        }
    }
}