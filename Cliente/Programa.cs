using System;
using System.Collections.Generic;
using System.IO;

namespace cliente
{
public class Programa
{

    private List<Cliente> clientes = new List<Cliente>();

    private Menu menu = new Menu();
    //private bool emExecucao = 1;
    public void Executar()
    {
        int opcao = 0;
        while(opcao != 6)
        {
            menu.LimparTela();
            ExibeMenu();
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
                    Editar();
                    break;

                case 4:
                    Remover();
                    break;

                case 5:
                    //Exportar Informações
                    Exportar();
                    break;
                    
                case 6:
                    menu.Escrever("Saindo");
                    //Sair
                    break;

                default:
                    break;                
            }
            menu.Escrever("Pressione enter para continuar");
            menu.LerString();
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
                + "5-CNH\n6-Endereco\n");
                var opcao = menu.LerInt();

                switch(opcao)
                {
                    case 1:
                        menu.Escrever("Digite o nome");
                        if(cliente.ModifyName(menu.LerString()))
                            menu.Escrever("Nome alterado com sucesso");
                        else
                            menu.Escrever("Nome não pode ser vazio");
                        break;

                    case 2:
                        menu.Escrever("Digite a idade");
                        if(cliente.ModifyAge(menu.LerInt()))
                            menu.Escrever("Idade alterada sem conflitos");
                        else
                            menu.Escrever("Removido Carteira de motorista e/ou reservista");
                        break;

                    case 3:
                        menu.Escrever("Digite o sexo");
                        if(cliente.ModifySex(menu.LerString()))
                            menu.Escrever("Sexo alterado sem problema");
                        else
                            menu.Escrever("Cliente não pode mais ter carteira de reservista\n");
                        break;

                    case 4:
                        menu.Escrever("Digite o número de reservista");
                        if(cliente.FillMilitaryReserveNumber(menu.LerString()))
                            menu.Escrever("Sucesso");
                        else
                            menu.Escrever("Cliente menor de idade ou do sexo feminino");
                        break;

                    case 5:
                        menu.Escrever("Digite o número da carteira de motorista");
                        if(cliente.FillDriversLicense(menu.LerString()))
                            menu.Escrever("Sucesso");
                        else
                            menu.Escrever("Cliente menor de idade");
                        break;

                    case 6:
                        menu.Escrever("Não implementado");
                        break;
                    
                }
            }
        }
    }
    public void Remover()
    {
        menu.Escrever("Qual cliente deseja remover?");
        var nomeCliente = menu.LerString();
        foreach(var cliente in clientes)
        {
            /*
             * Procura o cliente pelo nome
             * Caso encontre, remove da lista de clientes
             * Retorna para evitar remoção múltipla.
             */
            if(cliente.FindByName(nomeCliente))
            {
                clientes.Remove(cliente);
                return;
            }
                
        }
    }
    public void Exportar()
    {
        var file = new StreamWriter("export.csv");
        file.WriteLine("nome,idade,sexo,CNH,reservista");
        foreach(var c in clientes)
            file.WriteLine(c.ExportDataAsCSV());

        file.Close();
    }
}
}