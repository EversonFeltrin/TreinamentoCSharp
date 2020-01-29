using System;

namespace cliente
{
    public class Endereco
    {
        public string nomeRua;
        public string CEP;
        public int numeroResidencia;
        public string cidade;
        public string estado;

        public string tipoEndereco;

        public Endereco(string nomeRua, string CEP, int numeroResidencia, string cidade, string estado, string tipoEndereco )
        {
            this.nomeRua = nomeRua;
            this.CEP = CEP;
            this.numeroResidencia = numeroResidencia;
            this.cidade = cidade;
            this.estado = estado;
            this.tipoEndereco = tipoEndereco;
        }

        public Endereco(string CEP, string tipoEndereco) : this("", CEP, 0, "", "", tipoEndereco)
        {

        }

        public string GetAddress(){
            return $"Rua {nomeRua}, {numeroResidencia}, CEP: {CEP}, {cidade} - {estado}";
        }
    }
}