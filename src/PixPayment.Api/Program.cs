using PixPayment.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Adiciona suporte para Controllers (essencial para o PixController funcionar)
builder.Services.AddControllers(); 

// 2. Configura o Swagger (Interface Visual)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Registra serviço de Pix
builder.Services.AddScoped<PixService>();

var app = builder.Build();

// 4. Ativa o Swagger Visual se estiver em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // cria a página /swagger/index.html
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 5. Mapeia os Controllers (Faz a rota /api/pix ser encontrada)
app.MapControllers(); 

app.Run();