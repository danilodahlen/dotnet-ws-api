using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_app.Models
{
    public class Publicacao
    {
        public string id_publicacao {get;set;}
        public string id_autor_publicacao{get;set;}
        public string id_arquivo {get;set;}
        public string titulo_publicacao {get;set;}
        public string texto_publicacao {get;set;}
        public string operacao { get; set; }
    }

    public class CurtidaPublicacao
    {
        public string id_publicacao {get;set;}
        public string id_autor_publicacao {get;set;}
        public string id_autor_curtida {get;set;}
        public string tipo_curtida {get;set;}
        public string operacao { get; set; }
    }

    public class ComentarioPublicacao
    {
        public string id_publicacao {get;set;}
        public string id_autor_publicacao {get;set;}
        public string id_autor_comentario {get;set;}
        public string id_sequencia {get;set;}
        public string texto_comentario {get;set;}
        public string operacao { get; set; }
    }

    public class retornaPublicacao
    {
        public string id_publicacao {get;set;}
		public string id_autor_publicacao {get;set;}
        public string perfil { get; set; }
    }    
}