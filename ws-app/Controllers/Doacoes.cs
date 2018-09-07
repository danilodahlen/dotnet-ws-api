using System.Web.Http;
using ws_app.Models;
using ws_app.Connection;

namespace ws_app.Controllers
{
    [RoutePrefix("api/doacao")]
    public class doacaoController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("retornaDoacoes")]
        public string retornaDoacoes(retornaDoacoes doacoes)
        {
            Parametrizar Parametros = new Parametrizar(2);

            Parametros.AddParam("atual_estado", doacoes.atual_estado, "string");
            Parametros.AddParam("atual_cidade", doacoes.atual_cidade, "string");

            return ConnectionDB.executarProcedure("Proc_ws_retornaDoacoes", Parametros.ObterParametros(), Parametros.getQuantidade(), "string").ToString();
        }
    }
}