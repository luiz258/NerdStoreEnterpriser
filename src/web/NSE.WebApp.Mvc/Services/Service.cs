
using NSE.WebApp.Mvc.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Services
{
    public abstract class Service
    {

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMensage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<T>(await responseMensage.Content.ReadAsStringAsync(), options);
        }

        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(
                JsonSerializer.Serialize(dado),
                encoding: Encoding.UTF8,
                "application/json"
                );
        }

        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpRequestException(response.StatusCode);
                case 400:
                    return false;
            }
            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
