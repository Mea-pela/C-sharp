using System.Text;
using System.Text.Json;
Funzione();

async Task GetToken()
{
    using HttpClient httpClient = new();

    httpClient.BaseAddress = new Uri("https://apibsmartexport.piusi.com/");

    httpClient.DefaultRequestHeaders.Accept.Clear();
    httpClient.DefaultRequestHeaders.Accept.Add(
        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/json"));

    httpClient.DefaultRequestHeaders.Authorization =
        new System.Net.Http.Headers.AuthenticationHeaderValue(
            "Bearer",
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
        );

    var body = new
    {
        client_id = "PIUSI-3007-MDYYJ",
        client_secret = "207E32B3DEBCD59D1A7B6EE3C876CC58"
    };

    string json = JsonSerializer.Serialize(body);

    var content = new StringContent(
        json,
        Encoding.UTF8,
        "application/json");

    HttpResponseMessage response =
        await httpClient.PostAsync("api/Auth/token", content);

    string result = await response.Content.ReadAsStringAsync();

    Console.WriteLine(result);
}