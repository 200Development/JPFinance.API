using JPFinance.API.Clients;
using JPFinance.API.Interfaces.Clients;
using JPFinance.API.Interfaces.Repositories;
using JPFinance.API.Interfaces.Services;
using JPFinance.API.Repositories;
using JPFinance.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPennywiseRepository, PennywiseRepository>(_ => new PennywiseRepository(builder.Configuration.GetConnectionString("Pennywise")));
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddHttpClient<IPlaidClient, PlaidClient>(c =>
{
    var environment = builder.Configuration.GetValue<string>("Environment");
    var baseAddress = environment switch
    {
        "Development" => "https://development.plaid.com",
        "Sandbox" => "https://sandbox.plaid.com",
        _ => throw new Exception("Invalid environment for Plaid client")
    };
    c.BaseAddress = new Uri(baseAddress);
    c.DefaultRequestHeaders.Add("Accept","application/json");
    c.DefaultRequestHeaders.Add("PLAID-CLIENT-ID", builder.Configuration["PLAID_CLIENT_ID"]);

    var secretKey = environment switch
    {
        "Development" => builder.Configuration["PLAID_DEVELOPMENT_SECRET"],
        "Sandbox" => builder.Configuration["PLAID_SANDBOX_SECRET"],
        _ => throw new Exception("Invalid environment for Plaid client secret.")
    };
    c.DefaultRequestHeaders.Add("PLAID-SECRET", secretKey);

});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(b =>
    b.WithOrigins() // Allow only this origin
        .AllowAnyHeader()
        .AllowAnyMethod());
app.MapControllers();

app.Run();
