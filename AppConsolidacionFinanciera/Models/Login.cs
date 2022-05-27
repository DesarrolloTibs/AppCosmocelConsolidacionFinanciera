using System;
namespace AppConsolidacionFinanciera.Models
{
    public class Login
    {
        public class Respuesta
        {
            public string StatusCode { get; set; }
            public string Success { get; set; }
            public string Error { get; set; }
            public string Message { get; set; }

            public Nivel1 Response { get; set; }

        }
        public class Nivel1
        {
            public Nivel2 Data { get; set; }

        }
        public class Nivel2
        {
            public string Mensaje { get; set; }
            public string Token { get; set; }

            public Nivel3 Usuario { get; set; }

        }
        public class Nivel3
        {
            public string Id { get; set; }
            public string Usuario { get; set; }
        }
    }
}
