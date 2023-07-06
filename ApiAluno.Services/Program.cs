
using ApiProdutos.Services.Security;

var builder = WebApplication.CreateBuilder(args);
    
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//adicionando a configura��o para autentica��o com JWT
JwtConfiguration.Configure(builder);

//ativando a biblioteca do AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

/*
    definindo a pol�tica de acesso da API, configurando quais
    aplica��es poder�o fazer chamadas para a nossa API (ALL)
*/
builder.Services.AddCors(
       s => s.AddPolicy("CorsSetup", builder =>
       {
           builder.AllowAnyOrigin()
                  //qualquer projeto/origem pode acessar a API
                  .AllowAnyMethod()
                  //qualquer m�todo (POST, PUT, DELETE, GET)
                  .AllowAnyHeader();
           //qualquer informa��o de cabe�alho
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
