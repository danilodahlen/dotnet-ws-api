using System.Web.Http;
using ws_app.Models;
using ws_app.Connection;

namespace ws_app.Controllers
{
    [RoutePrefix("api/cadastro")]
    public class cadastroController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("gravarUsuario")]
        public string gravarUsuario(UsuarioCadastrar usuario)
        {
            Parametrizar Parametros = new Parametrizar(19);

            Parametros.AddParam("id_usuario", usuario.id_usuario, "string");
            Parametros.AddParam("nome_usuario ", usuario.nome_usuario, "string");
            Parametros.AddParam("apelido_usuario", usuario.apelido, "string");
            Parametros.AddParam("data_nascimento", usuario.data_nascimento, "date");
            Parametros.AddParam("email_usuario", usuario.email_usuario, "string");
            Parametros.AddParam("email_usuario_2", usuario.email_usuario_2, "string");
            Parametros.AddParam("tel_fixo_ddd", usuario.tel_fixo_ddd, "string");
            Parametros.AddParam("tel_fixo", usuario.tel_fixo, "string");
            Parametros.AddParam("tel_celular_ddd", usuario.tel_celular_ddd, "string");
            Parametros.AddParam("tel_celular", usuario.tel_celular, "string");
            Parametros.AddParam("usuario_cuidador", usuario.usuario_cuidador, "bit");
            Parametros.AddParam("endereco_cep", usuario.endereco_cep, "string");
            Parametros.AddParam("endereco_rua", usuario.endereco_rua, "string");
            Parametros.AddParam("endereco_numero", usuario.endereco_numero, "string");
            Parametros.AddParam("endereco_bairro", usuario.endereco_bairro, "string");
            Parametros.AddParam("endereco_cidade", usuario.endereco_cidade, "string");
            Parametros.AddParam("endereco_estado", usuario.endereco_estado, "string");
            Parametros.AddParam("endereco_pais", usuario.endereco_pais, "string");
            Parametros.AddParam("operacao", usuario.operacao, "int");
            
            return ConnectionDB.executarProcedure("Proc_GravarUsuario", Parametros.ObterParametros(), Parametros.getQuantidade(),"string").ToString();
        }
        
        [AcceptVerbs("POST")]
        [Route("gravarCategoria")]
        public string gravarCategoria(CategoriaCadastrar categoria)
        {
            Parametrizar Parametros = new Parametrizar(3);

            Parametros.AddParam("id_categoria", categoria.id_categoria, "string");
            Parametros.AddParam("nome_categoria", categoria.nome_categoria, "string");
            Parametros.AddParam("operacao", categoria.operacao, "int");

            return ConnectionDB.executarProcedure("Proc_GravarCategoria", Parametros.ObterParametros(), Parametros.getQuantidade(), "string").ToString();
        }
        
        [AcceptVerbs("POST")]
        [Route("gravarTipoCategoria")]
        public string gravarTipoCategoria(TipoCategoriaCadastrar categoria)
        {
            Parametrizar Parametros = new Parametrizar(4);

            Parametros.AddParam("id_categoria", categoria.id_categoria, "string");
            Parametros.AddParam("id_tipo_pet", categoria.id_tipo_pet, "string");
            Parametros.AddParam("nome_tipo_pet", categoria.id_tipo_pet, "string");
            Parametros.AddParam("operacao", categoria.operacao, "int");

            return ConnectionDB.executarProcedure("Proc_GravarTipoCategoria", Parametros.ObterParametros(), Parametros.getQuantidade(), "string").ToString();
        }
        
        [AcceptVerbs("POST")]
        [Route("gravarPets")]
        public string gravarPets(PetsCadastrar pets)
        {
            Parametrizar Parametros = new Parametrizar(9);
            
            Parametros.AddParam("id_usuario", pets.id_usuario, "string");
            Parametros.AddParam("id_pet", pets.id_pet, "string");
            Parametros.AddParam("nome_tipo_pet", pets.nome_pet, "string");
            Parametros.AddParam("id_categoria", pets.id_categoria, "string");
            Parametros.AddParam("id_tipo_pet", pets.id_tipo_pet, "string");
            Parametros.AddParam("doacao", pets.doacao, "bit");
            Parametros.AddParam("desaparecido", pets.desaparecido, "bit");
            Parametros.AddParam("observacoes", pets.observacoes, "string");
            Parametros.AddParam("operacao", pets.operacao, "int");

            return ConnectionDB.executarProcedure("Proc_GravarPetsUsuarios", Parametros.ObterParametros(), Parametros.getQuantidade(), "string").ToString();
        }
        
    }
}
