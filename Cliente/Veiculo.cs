using System;
using System.Collections.Generic;

namespace Veiculo
{
    public class Veiculo
    {
        public string Nome {get; set;}
        public int Ano {get; set;}

        public Veiculo (string nome, int ano){
            this.Nome = nome;

            this.Ano = ano;
        }
    }


    public class Carro : Veiculo 
    {

        public Carro() : base("", 0)
        {

        }
        public Carro(string nome, int ano) : base (nome, ano)
        {


        }

    }

}
