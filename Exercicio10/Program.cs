internal class Program
{
    public class numeroAleatorio
    {
       public int numeroSelecionado;

        public numeroAleatorio()
        {
            Random random = new Random();
            numeroSelecionado = random.Next(1, 51);
        }

        public bool checkNumero(int tentativa)
        {
            if (tentativa > numeroSelecionado)
            {
                Console.WriteLine("Tente um número menor\n");
                return true;
            }
            else if (tentativa < numeroSelecionado)
            {
                Console.WriteLine("Tente um número maior\n");
                return true;
            }
            else
            {
                Console.WriteLine($"Você acertou o número era: {numeroSelecionado}");
                return false;
            }
        }
    }

    private static void Main(string[] args)
    {
        bool jogoRodando = true;
        int tentativas = 5;
        int tentativa = 0;

        numeroAleatorio numero = new numeroAleatorio();

        while (jogoRodando)
        {
            //Checa número de tentativas
            if (tentativas <= 0)
            {
                Console.WriteLine($"\nSuas tentativas acabaram. O número era {numero.numeroSelecionado}.");
                jogoRodando = false;
            }
            else
            {
                Console.WriteLine($"Tente adivinhar o número. Você tem {tentativas} tentativas.");

                //Verificva uma tentativa válida
                bool tentativaValida = false;
                while (!tentativaValida)
                {
                    Console.WriteLine($"Chute:");
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out tentativa))
                    {
                        tentativaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("\nNúmero Inválido! Tente novamente.\n");
                    }
                }

                //Verifica se a tentativa é maior, menor ou está certa
                jogoRodando = numero.checkNumero(tentativa);
                tentativas--;
            }            
        }
    }
}