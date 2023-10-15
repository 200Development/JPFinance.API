using JPFinance.API.Interfaces;
using JPFinance.API.Repositories;
using JPFinance.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPennywiseRepository, PennywiseRepository>(_ => new PennywiseRepository(builder.Configuration.GetConnectionString("Pennywise")));
builder.Services.AddScoped<IPlaidRepository, PlaidRepository>();
builder.Services.AddScoped<IPlaidService, PlaidService>();
builder.Services.AddHttpClient<PlaidService>("SandboxClient", c =>
{
    c.BaseAddress = new Uri("https://sandbox.plaid.com");
    c.DefaultRequestHeaders.Add("Accept","application/json");
    c.DefaultRequestHeaders.Add("PLAID-CLIENT-ID", builder.Configuration["PLAID_CLIENT_ID"]);
    c.DefaultRequestHeaders.Add("PLAID-SECRET", builder.Configuration["PLAID_SANDBOX_SECRET"]);

});
builder.Services.AddHttpClient<PlaidService>("DevelopmentClient", c =>
{
    c.BaseAddress = new Uri("https://development.plaid.com");
    c.DefaultRequestHeaders.Add("Accept", "application/json");
    c.DefaultRequestHeaders.Add("PLAID-CLIENT-ID", builder.Configuration["PLAID_CLIENT_ID"]);
    c.DefaultRequestHeaders.Add("PLAID-SECRET", builder.Configuration["PLAID_DEVELOPMENT_SECRET"]);
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
    b.WithOrigins("http://localhost:3000") // Allow only this origin
        .AllowAnyHeader()
        .AllowAnyMethod());
app.MapControllers();

app.Run();
