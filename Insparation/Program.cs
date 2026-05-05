using Insparation.Features.GenerateInsparation;
using Insparation.Services.AIService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddScoped<IAiService, AiService>();
builder
    .Services.AddOptions<AiServiceOptions>()
    .BindConfiguration("AiService")
    .ValidateDataAnnotations()
    .ValidateOnStart();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGenerateInsparationEndpoint();
app.Run();

