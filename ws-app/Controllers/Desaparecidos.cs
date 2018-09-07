using System.Web.Http;
using ws_app.Models;
using ws_app.Connection;

namespace ws_app.Controllers
{
    [RoutePrefix("api/desaparecido")]
    public class Desaparecidos
    {
        [AcceptVerbs("POST")]
        [Route("retornaDesaparecidos")]
        public string retornaDesaparecidos(retornaDesaparecidos desaparecidos)
        {
            Parametrizar Parametros = new Parametrizar(2);

            Parametros.AddParam("atual_estado", desaparecidos.atual_estado, "string");
            Parametros.AddParam("atual_cidade", desaparecidos.atual_cidade, "string");

            return ConnectionDB.executarProcedure("Proc_ws_retornaDesaparecido", Parametros.ObterParametros(), Parametros.getQuantidade(), "string").ToString();
        }
    }
}