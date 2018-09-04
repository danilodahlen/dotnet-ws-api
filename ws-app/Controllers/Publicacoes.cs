using System.Web.Http;
using ws_app.Models;
using ws_app.Connection;

namespace ws_app.Controllers
{
    public class Publicacoes
    {
        [AcceptVerbs("POST")]
        [Route("gravarPublicacao")]
        public string gravarPublicacao(Publicacao publicacao)
        {
            Parametrizar Parametros = new Parametrizar(6);

            Parametros.AddParam("id_publicacao", publicacao.id_publicacao, "int");
            Parametros.AddParam("id_autor_publicacao", publicacao.id_autor_publicacao, "string");
            Parametros.AddParam("id_arquivo", publicacao.id_arquivo, "int");
            Parametros.AddParam("titulo_publicacao", publicacao.titulo_publicacao, "string");
            Parametros.AddParam("texto_publicacao", publicacao.texto_publicacao, "string");
            Parametros.AddParam("operacao", publicacao.operacao, "int");

            return ConnectionDB.executarProcedure("Proc_GravarPublicacao", Parametros.ObterParametros(), Parametros.getQuantidade(), "string").ToString();
        }

        [AcceptVerbs("POST")]
        [Route("gravarCurtida")]
        public string gravarCurtida(CurtidaPublicacao curtida)
        {
            Parametrizar Parametros = new Parametrizar(5);
            
            Parametros.AddParam("id_publicacao", curtida.id_publicacao, "string");
            Parametros.AddParam("id_autor_publicacao", curtida.id_autor_publicacao, "string");
            Parametros.AddParam("id_autor_curtida", curtida.id_autor_curtida, "string");
            Parametros.AddParam("tipo_curtida", curtida.tipo_curtida, "int");
            Parametros.AddParam("operacao", curtida.operacao, "int");

            return ConnectionDB.executarProcedure("Proc_GravarPublicacaoCurtida", Parametros.ObterParametros(), Parametros.getQuantidade(), "string").ToString();
        }
        
        [AcceptVerbs("POST")]
        [Route("gravarComentario")]
        public string gravarComentario(ComentarioPublicacao comentario)
        {
            Parametrizar Parametros = new Parametrizar(6);

            Parametros.AddParam("id_publicacao", comentario.id_publicacao, "string");
            Parametros.AddParam("id_autor_publicacao", comentario.id_autor_publicacao, "string");
            Parametros.AddParam("id_autor_comentario", comentario.id_autor_comentario, "string");
            Parametros.AddParam("id_sequencia", comentario.id_sequencia, "string");
            Parametros.AddParam("texto_comentario", comentario.texto_comentario, "string");
            Parametros.AddParam("operacao", comentario.operacao, "int");

            return ConnectionDB.executarProcedure("Proc_GravarPublicacaoComentario", Parametros.ObterParametros(), Parametros.getQuantidade(), "string").ToString();
        }

        [AcceptVerbs("POST")]
        [Route("retornaPublicacao")]
        public string retornaPublicacao(retornaPublicacao publicacao)
        {
            string retorno;

            Parametrizar ParametrosP = new Parametrizar(3);

            ParametrosP.AddParam("id_publicacao", publicacao.id_publicacao, "string");
            ParametrosP.AddParam("id_autor_publicacao", publicacao.id_autor_publicacao, "string");
            ParametrosP.AddParam("perfil", publicacao.perfil, "int");

            retorno = ConnectionDB.executarProcedure("Proc_ws_retornaPublicacao", ParametrosP.ObterParametros(), ParametrosP.getQuantidade(), "string").ToString();

            Parametrizar ParametrosComentario = new Parametrizar(1);

            ParametrosComentario.AddParam("id_publicacao", publicacao.id_publicacao, "string");

            retorno += "|" + ConnectionDB.executarProcedure("Proc_ws_retornaComentario", ParametrosComentario.ObterParametros(), ParametrosComentario.getQuantidade(), "string").ToString();

            Parametrizar ParametrosCurtida = new Parametrizar(1);

            ParametrosCurtida.AddParam("id_publicacao", publicacao.id_publicacao, "string");

            retorno += "|" + ConnectionDB.executarProcedure("Proc_ws_retornaCurtida", ParametrosCurtida.ObterParametros(), ParametrosCurtida.getQuantidade(), "string").ToString();

            return retorno;
        }
    }
}