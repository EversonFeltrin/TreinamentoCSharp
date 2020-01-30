using System;
using System.Collections.Generic;

namespace cliente{

    public class Cliente
    {
        // Atributos de um cliente
        private string nome;
        private int idade;
        private char sexo;

        private string carteiraMotorista;
        private string numeroReservista;
        
        private List<Endereco> endereco;
        
        
        public Cliente(string nome, int idade, char sexo)
        {
            this.nome = nome;
            this.idade = idade;
            this.sexo = sexo;
            this.numeroReservista = "";
            this.carteiraMotorista = "";
            this.endereco = new List<Endereco>();
        }

        public string GetClientData()
        {
            var clientData = "";

            if(!string.IsNullOrWhiteSpace(nome))
                clientData = clientData + $"Nome: {nome}\n";
            
            if(idade > 0)
                clientData = clientData + $"Idade: {idade}\n";
            
            if(sexo == 'm' || sexo == 'f')
                clientData = clientData + $"Sexo: {sexo}\n";
            
            if(!string.IsNullOrWhiteSpace(numeroReservista))
                clientData = clientData + $"Numero Reservista: {numeroReservista}\n";
            
            if(!string.IsNullOrWhiteSpace(carteiraMotorista))
                clientData = clientData + $"Carteira de Motorista: {carteiraMotorista}\n";
            

            foreach(var _endereco in endereco )
                clientData = clientData + $"Endereço: {_endereco.GetAddress()}\n";

            return clientData;
            
        }

        public int GetBirthYear()
        {
            return DateTime.Now.Year - this.idade;
        }

        public bool IsOfLegalAge()
        {
            return idade >= 18;
        }

        public bool FillMilitaryReserveNumber(string numeroReservista) 
        {
            //verifica se nao tem direito a numero de reservista
            if (!IsOfLegalAge() || sexo != 'm')
                return false;

            //tendo direito seta o valor 
            this.numeroReservista = numeroReservista; 
            
            //retorna sucesso
            return true;
        }

        public bool FillDriversLicense(string carteiraMotorista)
        {
            //verifica se nao tem direito a carteira de motorista
            if(!IsOfLegalAge())
                return false;
            
            //seta o valor da carteira
            this.carteiraMotorista = carteiraMotorista;
                
            //retorna sucesso    
            return true;
        }

        public bool DefineAddress(Endereco endereco)
        {
            if (!IsOfLegalAge() && endereco.GetTipo() == "Comercial")
                return false;
            
            this.endereco.Add(endereco);
            
            return true;
        }

        public bool FindByName(string nome)
        {
            return this.nome == nome;
        }

        public bool ModifyName(string name)
        {
            if(String.IsNullOrWhiteSpace(name))
                return false;

            nome = name;
            return true;
        }

        public bool ModifyAge(int age)
        {

            idade = age;
            /*
                * Se a idade corrigida for menor de 18,
                * remove carteira de motorista e certificado de
                * reservista.
                * Não é necessário verificar se estão preenchidas,
                * visto que, no final, será vazio de qualquer forma.
                */
            if(!IsOfLegalAge())
            {
                carteiraMotorista = numeroReservista = "";
                foreach(var end in endereco)
                {
                    if (end.GetTipo() == "Comercial")
                        endereco.Remove(end);
                }

                return false;
            }

            return true;
        }

        public bool ModifySex(string sex)
        {
            sexo = sex.ToCharArray()[0];

            /* Se o sexo alterado do cliente for feminino,
             * perde o "direito" (convenhamos, é obrigação estatal) de
             * possuir certificado de reservista.
             * retorna falso pra indicar que teve essa alteração
             */
            if(sexo == 'f')
            {
                numeroReservista = "";
                return false;
            }

            /* Caso tenha sido alterado pra masculino, 
             * não houve conflitos de regras.
             * retorna true pra indicar isto.
             */
            return true;
        }

        public string ExportDataAsCSV()
        {
            string result = "";
            result += nome + ",";
            result += idade.ToString() + ",";
            result += sexo.ToString() + ",";
            result += carteiraMotorista + ",";
            result += numeroReservista + ",";

            /*
             * esse bloco adicionaria todos os endereços do cliente
             * na string formatada em CSV.
             * Porém, como o cliente pode ter mais de um endereço, e
             * arquivos em CSV não são escaláveis dessa forma,
             * resolvi deixar comentado.
            foreach(var end in endereco)
            {
                result += end.ExportDataAsCSV();
            }
            */
            return result;
        }

   }
}