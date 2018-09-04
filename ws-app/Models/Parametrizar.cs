using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_app.Models
{
    class Parametrizar 
    {
        private int _quantidade;
        private int _contador = 0;
        string[,] parametros = new string[999, 3];

        public Parametrizar(int v_Quant)
        {
            setQuantidade(v_Quant);
        }
        
        public void setQuantidade(int v_Quant)
        {
            this._quantidade = v_Quant;
        }

        public int getQuantidade()
        {
            return this._quantidade;
        }

        public int getProxima()
        {
            return this._contador;
        }

        public void setProxima()
        {
            if(this._contador < this._quantidade)
                this._contador++;
        }

        public void AddParam(string param,string valor, string tipo)
        {
            parametros[getProxima(), 0] = param;
            parametros[getProxima(), 1] = valor;
            parametros[getProxima(), 2] = tipo;
            setProxima();
        }

        public string[,] ObterParametros()
        {
            return parametros;
        }

    }
}