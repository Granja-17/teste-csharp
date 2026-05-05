using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCoreApp.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace simpleapp.Pages;


public class IndexModel : PageModel

{
    private readonly IHttpClientFactory _httpClientFactory;

    public IndexModel(IHttpClientFactory httpClientFactory)

    {
        _httpClientFactory = httpClientFactory;
    }


    public List<Pais> Paises { get; set; } = new();

    public async Task OnGetAsync()

    {
        //var client = _httpClientFactory.CreateClient();
        //var response = await client.GetAsync("https://restcountries.com/v3.1/all");
        var client = _httpClientFactory.CreateClient("RestCountries");
        var response = await client.GetAsync("v3.1/all?fields=name,capital,currencies,cca2,flags");

        if (response.IsSuccessStatusCode)

        {
            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var dados = JsonSerializer.Deserialize<List<CountryApiResponse>>(json, options);


            Paises = dados.Select(d => new Pais

            {

                OfficialName = d.name?.official,

                Cca2 = d.cca2,

                FlagUrl = d.flags?.png

            }).ToList();
        }
    }


    /*

private readonly ILogger<IndexModel> _logger;



    public IndexModel(ILogger<IndexModel> logger)

    {

        _logger = logger;

    }


    public void OnGet()

    {


    }

*/

}