using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static AppConsolidacionFinanciera.Models.Login;
using static AppConsolidacionFinanciera.Models.TipoCambio;

namespace AppConsolidacionFinanciera
{
    public class App
    {
        private readonly IConfigurationRoot _config;
        private readonly ILogger<App> _logger;

        public App(IConfigurationRoot config, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<App>();
            _config = config;
        }

        public async Task Run()
        {
            int Id = _config.GetSection("IdUser").Get<int>();
            string User = _config.GetSection("UserName").Get<string>();
            string Password = _config.GetSection("UserPassword").Get<string>();
            /*  foreach (string emailAddress in emailAddresses)
              {
                  _logger.LogInformation("Email address: {@EmailAddress}", emailAddress);
              }*/
            _logger.LogInformation("Iniciando Proceso Conexion...");
            ConsumeEventSync objsync = new ConsumeEventSync();

          var result=  objsync.PostEvent_data(Id,User,Password); //Adding Event
            Respuesta respuesta = JsonConvert.DeserializeObject<Respuesta>(result);
            _logger.LogInformation("Conexion Establecida");
            _logger.LogInformation(respuesta.Message);
            var token = respuesta.Response.Data.Token;
            var usuario = respuesta.Response.Data.Usuario.Usuario;

            if (!String.IsNullOrEmpty(token))
            {
                _logger.LogInformation("Obteniendo Informacion...");
               var x= objsync.Postdata(usuario, token);
                RespuestaTipoCambio respuestat= JsonConvert.DeserializeObject<RespuestaTipoCambio>(x);
                _logger.LogInformation(respuesta.StatusCode);
            }
            else {
                _logger.LogInformation("Intente de Nuevamente...");
            }
            _logger.LogInformation("Proceso Terminado Correctamente...");
        }
    }
}
