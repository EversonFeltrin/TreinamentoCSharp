using System;
using System.Collections.Generic;

namespace cliente{

    public class Cliente
        {
            // Atributos de um cliente
            public string nome{get; set;}
            public int idade;
            public char sexo;

            public string carteiraMotorista;
            public string numeroReservista;
            
            public List<Endereco> endereco;
            
            
            
            public Cliente()
            {
                Controller controller = new Controller();
                controller.CreateClient();
            }

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
                if (!IsOfLegalAge() && endereco.tipoEndereco == "Comercial")
                    return false;
                
                this.endereco.Add(endereco);
                
                return true;
            }

            public bool FindByName(string nome)
            {
                return this.nome == nome;
            }

    }
}