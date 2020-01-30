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

        public Endereco(string CEP, string tipoEndereco)
        {
            var data = new System.Data.DataSet();
            try
            {
                data.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + CEP.Replace("-","").Trim());
                var resultado = data.Tables[0].Rows[0];
                this.nomeRua = resultado["logradouro"].ToString().Trim();
                this.cidade = resultado["cidade"].ToString().Trim();
                this.estado = resultado["uf"].ToString().Trim();
                this.numeroResidencia = 0; //Cep não carrega número da casa

            }
            catch (System.Exception)
            {
                
                this.nomeRua = "";
                this.cidade = "";
                this.estado = "";
                this.numeroResidencia = 0; 
            }
                this.CEP = CEP;
                this.tipoEndereco = tipoEndereco;
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