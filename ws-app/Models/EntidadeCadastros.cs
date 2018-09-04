using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_app.Models
{
    public class UsuarioCadastrar
    {
        public string id_usuario { get; set; }
        public string nome_usuario { get; set; }
        public string apelido { get; set; }
        public string data_nascimento { get; set; }
        public string email_usuario { get; set; }
        public string email_usuario_2 { get; set; }
        public string tel_fixo_ddd { get; set; }
        public string tel_fixo { get; set; }
        public string tel_celular_ddd { get; set; }
        public string tel_celular { get; set; }
        public string usuario_cuidador { get; set; }
        public string endereco_cep { get; set; }
        public string endereco_rua { get; set; }
        public string endereco_numero { get; set; }
        public string endereco_bairro { get; set; }
        public string endereco_cidade { get; set; }
        public string endereco_estado { get; set; }
        public string endereco_pais { get; set; }
        public string operacao { get; set; }
    }

    public class CategoriaCadastrar
    {
        public string id_categoria { get; set; }
        public string nome_categoria { get; set; }
        public string operacao { get; set; }
    }


    public class TipoCategoriaCadastrar
    {
        public string id_categoria { get; set; }
        public string id_tipo_pet { get; set; }
        public string nome_tipo_pet { get; set; }
        public string operacao { get; set; }
    }

    public class PetsCadastrar
    {
        public string id_usuario  {get;set;}
        public string id_pet {get;set;}
        public string nome_pet {get;set;}
        public string id_categoria {get;set;}
        public string id_tipo_pet {get;set;}
        public string doacao { get; set; }
        public string desaparecido { get; set; }
        public string observacoes { get; set; }
        public string operacao { get; set; }
    }

    public class CurtidasCadastrar
    {
        public string id_publicacao { get; set; }
        public string id_autor_publicacao { get; set; }
        public string id_autor_curtida { get; set; }
        public string tipo_curtida { get; set; }
        public string operacao { get; set; }
    }

    public class ComentariosCadastrar
    {
        public string id_publicacao { get; set; }
        public string id_autor_publicacao { get; set; }
        public string id_autor_comentario { get; set; }
        public string id_sequencia { get; set; }
        public string texto_comentario { get; set; }
        public string operacao { get; set; }
    }
}