using System;
namespace AppConsolidacionFinanciera.Models
{
    public class TipoCambio
    {
        public class RespuestaTipoCambio
        {
            public string StatusCode { get; set; }
            public string Success { get; set; }
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
            public string Estatus { get; set; }

          
        }
      
    }
}
