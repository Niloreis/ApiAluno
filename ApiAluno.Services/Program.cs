
using ApiProdutos.Services.Security;

var builder = WebApplication.CreateBuilder(args);
    
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//adicionando a configuração para autenticação com JWT
JwtConfiguration.Configure(builder);

//ativando a biblioteca do AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

/*
    definindo a política de acesso da API, configurando quais
    aplicações poderão fazer chamadas para a nossa API (ALL)
*/
builder.Services.AddCors(
       s => s.AddPolicy("CorsSetup", builder =>
       {
           builder.AllowAnyOrigin()
                  //qualquer projeto/origem pode acessar a API
                  .AllowAnyMethod()
                  //qualquer método (POST, PUT, DELETE, GET)
                  .AllowAnyHeader();
           //qualquer informação de cabeçalho
       })
   );

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsSetup"); //ativando o CORS

app.Run();
