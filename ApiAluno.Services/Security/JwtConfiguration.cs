using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiProdutos.Services.Security
{
    public class JwtConfiguration
    {
        /// <summary>
        /// Chave secreta para criptografar/descriptografar os tokens
        /// Essa chave deverá ser a mesma utilizada na API de Usuários
        /// </summary>

        private static string SecretKey= @"81A5374D-464E-4900-937E-A3CDFF2FB66D";

        /// <summary>
        /// Método para configurar o tipo de autenticação do projeto API
        /// de forma a utilizar o framework JWT
        /// </summary>
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
                }
            ).AddJwtBearer(bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                  ValidateIssuerSigningKey = true,

                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.ASCII.GetBytes(SecretKey)),

                     ValidateIssuer = false,
                 ValidateAudience = false
                };
            });
        }
    }
}
