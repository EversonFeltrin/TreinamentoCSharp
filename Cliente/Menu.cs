using System;

public class Menu
{
    public string LerString()
    {
        return Console.ReadLine();
    }

    public decimal LerDecimal()
    {
        string PalavraRecebida = Console.ReadLine();
        decimal PalavraConvertida = Convert.ToDecimal(PalavraRecebida);
        return PalavraConvertida;
    }

    public int LerInt()
    {
        string PalavraRecebida = Console.ReadLine();
        int PalavraConvertida = Convert.ToInt32(PalavraRecebida);
        return PalavraConvertida;
    }

    public DateTime LerData()
    {
        return DateTime.Now;
    }
    public void Escrever(string PalavraRecebida)
    {
        Console.WriteLine(PalavraRecebida);
    }

    public void LimparTela()
    {
        Console.Clear();
    }
}