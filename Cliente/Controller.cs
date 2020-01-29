using System;

namespace cliente
{
    public class Controller
    {

        Cliente cliente;

        public void CreateClient()
        {
        
            //CreatePerson
            CreatePerson();

            //RegisterAddress    
            var textoResposta = LerString("Deseja cadastrar endereço?(sim/nao)");
            //tentar fazer assim 
            //var textoResposta = LerString<bool>("Deseja cadastrar endereço?(sim/nao)");
            while(textoResposta == "sim")
            {    
                if(RegisterAddress())            
                    Console.WriteLine("Endereço cadastrado com sucesso!");
                else
                    Console.WriteLine("Impossivel cadastrar endereço comerical para menores de idade.");

                textoResposta = LerString("Deseja cadastrar endereço?(sim/nao)");
            }

            Console.WriteLine(cliente.GetClientData());
        }

        void CreatePerson()
        {
            Console.WriteLine("Digite o nome");
            var nome = Console.ReadLine();

            Console.WriteLine("Digite a idade");
            var textoIdade = Console.ReadLine();
            var idade = Convert.ToInt32(textoIdade);

            Console.WriteLine("Digite o sexo");
            var textoSexo = Console.ReadLine();
            var sexo = Convert.ToChar(textoSexo);

            

        

            cliente = new Cliente(nome, idade, sexo);
        }
        
        int LerInt(string mensagem)
        {
            return Convert.ToInt32(LerString(mensagem));
        }

        string LerString(string mensagem)
        {
            Console.WriteLine(mensagem);
            return Console.ReadLine();
        }

        bool RegisterAddress()
        {
            var nomeRua = LerString("Digite o nome da rua");

            var numero = LerInt("Digite o numero");
            
            var cep = LerString("Digite o CEP");

            var cidade = LerString("Digite a cidade");

            var estado = LerString("Digite a sigla do estado");

            var tipo = LerString("Digite o tipo de endereco. (Comercial/Residencial)");
            
            return cliente.DefineAddress(new Endereco(nomeRua, cep, numero, cidade, estado, tipo));            
        }
    }
}