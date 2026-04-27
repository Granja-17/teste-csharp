var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddRazorPages();


/** pedaço de codigo inicio */

//builder.Services.AddHttpClient();

builder.Services.AddHttpClient("RestCountries", c =>

{

    c.BaseAddress = new Uri("https://restcountries.com/");

})

.ConfigurePrimaryHttpMessageHandler(() =>

{

    return new HttpClientHandler

    {
        SslProtocols = System.Security.Authentication.SslProtocols.Tls12
    };
});

/** pedaço de codigo fim*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
