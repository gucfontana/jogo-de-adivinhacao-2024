namespace Adivinhacao.ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        decimal totalDePontos = 1000;

        var numeroSecreto = ObterNumeroSecreto();

        ApresentarMenu();

        var dificuldade = EscolherDificuldade();

        var totalDeTentativas = ObterTotalDeTentativas(dificuldade);

        for (var tentativa = 1; tentativa <= totalDeTentativas; tentativa++)
        {
            ApresentarMenu();

            Console.WriteLine($"\nTentativa {tentativa} de {totalDeTentativas}");

            var numeroDigitado = ObterNumeroDigitado();

            var jogadorAcertou = AvaliarChute(numeroSecreto, numeroDigitado);

            if (jogadorAcertou) break;

            totalDePontos = CalcularNovaPontuacao(totalDePontos, numeroSecreto, numeroDigitado);

            if (tentativa >= totalDeTentativas)
                Console.WriteLine("Que azar, tente novamente!");

            Console.ReadLine();
        }

        Console.ReadLine();
    }

    private static int ObterNumeroSecreto()
    {
        var aleatorio = new Random();
        var numeroSecreto = aleatorio.Next(1, 21);

        return numeroSecreto;
    }

    private static decimal CalcularNovaPontuacao(decimal totalDePontos, int numeroSecreto, int numeroDigitado)
    {
        decimal pontosPerdidos = Math.Abs((numeroDigitado - numeroSecreto) / 2);
        totalDePontos -= pontosPerdidos;

        Console.WriteLine($"Você fez {totalDePontos} pontos!");

        return totalDePontos;
    }

    private static bool AvaliarChute(int numeroSecreto, int numeroDigitado)
    {
        if (numeroDigitado == numeroSecreto)
        {
            Console.WriteLine("\nVocê acertou! O número secreto era: " + numeroSecreto);
            return true;
        }

        if (numeroDigitado > numeroSecreto)
        {
            Console.WriteLine("\nO número digitado foi maior que o número secreto.");
        }
        else if (numeroDigitado < numeroSecreto)
        {
            Console.WriteLine("\nO número digitado foi menor que o número secreto.");
        }

        return false;
    }

    private static int ObterNumeroDigitado()
    {
        Console.WriteLine("\nDigite um número entre 1 e 20:");
        var numeroDigitado = Convert.ToInt32(Console.ReadLine());
        return numeroDigitado;
    }

    private static int ObterTotalDeTentativas(int dificuldade)
    {
        var totalDeTentativas = 0;

        switch (dificuldade)
        {
            case 1:
                totalDeTentativas = 15;
                break;

            case 2:
                totalDeTentativas = 10;
                break;

            case 3:
                totalDeTentativas = 5;
                break;
        }

        return totalDeTentativas;
    }

    private static int EscolherDificuldade()
    {
        Console.WriteLine("\nEscolha a dificuldade que irá jogar: ");
        Console.WriteLine("(1) Fácil\t(2) Médio\t(3) Difícil");

        var dificuldade = Convert.ToInt32(Console.ReadLine());

        return dificuldade;
    }

    private static void ApresentarMenu()
    {
        Console.Clear();

        Console.WriteLine("***********************");
        Console.WriteLine("* Jogo de Adivinhação *");
        Console.WriteLine("***********************");
    }
}