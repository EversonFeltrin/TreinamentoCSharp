using System;
using System.Collections.Generic;

namespace cliente
{
public class Programa
{

    private List<Cliente> clientes = new List<Cliente>();

    private Menu menu = new Menu();
    //private bool emExecucao = 1;
    public void Executar()
    {
        // algum loop
        int opcao = 0;
        while(opcao != 6)
        {
            ExibeMenu();
            var menu = new Menu();
            opcao = menu.LerInt();
            
            switch (opcao)
            {
                case 1:
                    //Listar Clientes
                    Listar();

                break;
                case 2:
                    //Cadastrar Clientes
                    Cadastrar();
                break;
                case 3:
                    //Editar Cliente

                break;
                case 4:
                    //Remover Clientes

                break;
                case 5:
                    //Exportar Informações

                break;
                case 6:
                    menu.Escrever("Saindo");
                    //Sair
                    break;
                default:
                    break;                
            }
        }
            
    }

    private void ExibeMenu()
    {
        menu.Escrever("---------- Menu -----------");
        menu.Escrever("|[1] Listar Clientes      |");
        menu.Escrever("|[2] Cadastrar Clientes   |");
        menu.Escrever("|[3] Editar Cliente       |");
        menu.Escrever("|[4] Remover Cliente      |");
        menu.Escrever("|[5] Exportar Informações |");
        menu.Escrever("|[6] Sair                 |");
        menu.Escrever("---------------------------");
    }
    public void Listar()
    {
        foreach(var cliente in clientes)
        {
            menu.Escrever(cliente.GetClientData());
        }
    }
    public void Cadastrar()
    {    
        //CreatePerson
        menu.Escrever("Digite o nome");
        var nome = menu.LerString();

        menu.Escrever("Digite a idade");
        var idade = menu.LerInt();

        menu.Escrever("Digite o sexo");
        var sexo = Convert.ToChar(menu.LerString());
        
        var cliente = new Cliente(nome, idade, sexo);

        menu.Escrever("Gostaria de cadastrar CNH? (sim/nao)");
        var resposta = menu.LerString();

        if (resposta == "sim")
        {
            menu.Escrever("Informe CNH: ");
            if(!cliente.FillDriversLicense(menu.LerString()))
            {
                menu.Escrever("Não pode cadastrar, cliente menor de idade");
            }
        }

        menu.Escrever("Gostaria de cadastrar certificado de reservista? (sim/nao)");
        resposta = menu.LerString();

        if (resposta == "sim")
        {
            menu.Escrever("Informe CNH: ");
            if(!cliente.FillMilitaryReserveNumber(menu.LerString()))
            {
                menu.Escrever("Não pode cadastrar, cliente menor de idade ou mulher");
            }
        }

      
        //RegisterAddress    
        menu.Escrever("Gostaria de cadastrar endereço?");
        var textoResposta = menu.LerString();
        //tentar fazer assim 
        //var textoResposta = LerString<bool>("Deseja cadastrar endereço?(sim/nao)");
        while(textoResposta == "sim")
        {    
            menu.Escrever("Digite o nome da rua");
            var nomeRua = menu.LerString();

            menu.Escrever("Digite o numero");
            var numero = menu.LerInt();

            menu.Escrever("Digite o CEP");
            var cep = menu.LerString();

            menu.Escrever("Digite a cidade");
            var cidade = menu.LerString();

            menu.Escrever("Digite a sigla do estado");
            var estado = menu.LerString();

            menu.Escrever("Digite o tipo de endereco. (Comercial/Residencial)");
            var tipo = menu.LerString();

            var endereco = new Endereco(nomeRua, cep, numero, cidade, estado, tipo);
            if(cliente.DefineAddress(endereco))     
                menu.Escrever("Endereço cadastrado com sucesso!");
            else
                menu.Escrever("Impossivel cadastrar endereço comerical para menores de idade.");

            menu.Escrever("Deseja cadastrar endereço?(sim/nao)");
            textoResposta = menu.LerString();
        }
        //no final:
        clientes.Add(cliente);
    }
    public void Editar()
    {
        menu.Escrever("Informe nome para alteração:");
        var nomeEditar = menu.LerString();

        foreach (var cliente in clientes)
        {
            if (cliente.FindByName(nomeEditar))
            {
                menu.Escrever(cliente.GetClientData());
                menu.Escrever("Qual informação deseja alterar:\n" 
                + "1 - Nome\n2-Idade\n3-Sexo\n4-Numero de Reservista\n"
                + "5-CNH\nEndereco\n");
                var opcao = menu.LerInt();

                switch(opcao)
                {
                    case 1:
                        break;
                }
            }
        }
    }
    public void Remover()
    {

    }
    public void Exportar()
    {

    }
}
}