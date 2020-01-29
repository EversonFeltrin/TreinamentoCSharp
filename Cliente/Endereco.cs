namespace cliente
{
    public class Endereco
    {
        private string nomeRua;
        private string CEP;
        private int numeroResidencia;
        private string cidade;
        private string estado;

        private string tipoEndereco;

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

        public string GetAddress()
        {
            return $"Rua {nomeRua}, {numeroResidencia}, CEP: {CEP}, {cidade} - {estado}";
        }

        // "Tipo" ao invés de "Type", porque a classe Object já tem
        // um método "GetType()", e dá conflito.
        public string GetTipo()
        {
            return tipoEndereco;
        }
    }
}