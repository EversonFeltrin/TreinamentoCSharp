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
        decimal PalavraConvertida;
        try
        {
            PalavraConvertida = Convert.ToDecimal(PalavraRecebida);
        }
        catch
        {
            PalavraConvertida = 0M;
        }
        return PalavraConvertida;
    }

    public int LerInt()
    {
        string PalavraRecebida = Console.ReadLine();
        int PalavraConvertida;
        try
        {
            PalavraConvertida = Convert.ToInt32(PalavraRecebida);
        }
        catch
        {
            PalavraConvertida = 0;
        }
        return PalavraConvertida;
    }

    public DateTime LerData()
    {
        string leitura = Console.ReadLine();
        DateTime data;
        try
        {
            data = Convert.ToDateTime(leitura);
        }
        catch (System.Exception)
        {
            data = DateTime.Today;
        }
        return data;
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