var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Api rest full minimalista");
app.MapGet("/net6",(string frase)=>$".Net 6 es {frase}");
app.MapGet("/prueba/{net6}/{frase}", (string net6, string frase) 
    => $"{net6} es {frase}");
app.MapGet("/bitcoin", async () => { 
    HttpClient client = new HttpClient();
    var respuesta = await client.GetAsync("https://api.coindesk.com/v1/bpi/currentprice.json");
    respuesta.EnsureSuccessStatusCode();
    string escritor= await respuesta.Content.ReadAsStringAsync();
    return escritor;
});
app.Run();
