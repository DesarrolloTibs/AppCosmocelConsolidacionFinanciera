using System;
using System.Net;
using AppConsolidacionFinanciera.Models;
using Newtonsoft.Json;
using static AppConsolidacionFinanciera.Models.Login;
using static AppConsolidacionFinanciera.Models.TipoCambio;

namespace AppConsolidacionFinanciera
{
    public class ConsumeEventSync
    {
        public ConsumeEventSync()
        {
        }

        public string PostEvent_data(int IdUser,string UserName, string UserPassword) //Adding Event  
        {
            using (var client = new WebClient())
            {
                UserModel objtb = new UserModel(); //Setting parameter to post  
                objtb.idUsername = IdUser;
                objtb.username = UserName;
                objtb.userpassword = UserPassword;
             
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.UploadString("https://localhost:5001/api/SignIn", JsonConvert.SerializeObject(objtb));
            

                return result;

            }
        }
        public string Postdata(string User,string Token) //Adding Event  
        {
            using (var client = new WebClient())
            {
                UserModelParam objtb = new UserModelParam(); //Setting parameter to post  
         
                objtb.usuario = User;
           
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                client.Headers.Add("Authorization", "Bearer " + Token);
                var result = client.UploadString("https://localhost:5001/api/TipoCambio", JsonConvert.SerializeObject(objtb));
           
                //Respuesta respuesta = JsonConvert.DeserializeObject<Respuesta>(result);
                RespuestaTipoCambio respuesta = JsonConvert.DeserializeObject<RespuestaTipoCambio>(result);

                // Console.WriteLine(respuesta.Response.Data.Token);


                return result;
            }
        }
    }
}
