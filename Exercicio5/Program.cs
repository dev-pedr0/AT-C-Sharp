using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        DateTime dataFormatura = new DateTime(2027, 7, 01);
        DateTime hoje = DateTime.Today;

        bool dataErrada = true;

        while (dataErrada)
        {
            Console.WriteLine("Digite a data de hoje no formato dd/mm/yyyy");
            string entradaUsuario = Console.ReadLine();
            DateTime dataUsuario;

            if (DateTime.TryParseExact(entradaUsuario, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataUsuario) && dataUsuario <= hoje)
            {          
                TimeSpan diferencaTotal = dataFormatura - dataUsuario;
                int diferencaAnos = dataFormatura.Year - dataUsuario.Year;
                int diferencaMeses = dataFormatura.Month - dataUsuario.Month;
                int diferencaDias = dataFormatura.Day - dataUsuario.Day;

                if (diferencaTotal.Days < 0)
                {
                    Console.WriteLine("Parabéns! Você já deveria estar formado!");
                    dataErrada = false;
                }
                else if (diferencaTotal.Days == 0)
                {
                    Console.WriteLine("Hoje é o dia da formatura! Não se atrase!");
                    dataErrada = false;
                }
                else
                {
                    //Verifica entre os dois anos quantos anos são bissextos e para cada ano bissexto é adicionado mais um dia na diferença
                    for (int year = dataUsuario.Year; year <= dataFormatura.Year; year++)
                    {
                        if (DateTime.IsLeapYear(year))
                        {
                            diferencaDias++;
                        }
                    }

                    if (diferencaMeses < 0)
                    {
                        diferencaAnos--;
                        diferencaMeses += 12;
                    }

                    if (diferencaDias < 0)
                    {
                        diferencaMeses--;
                        //Como o valor dos dias é maior na data de aniversário é preciso voltar 1 mês
                        DateTime lastMonth = dataFormatura.AddMonths(-1);
                        //Verifico quantos dias (30 ou 31) o último mês tem e subtraio do valor negativo de dias
                        diferencaDias += DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month);
                    }

                    string mensagem = "Faltam ";
                    if (diferencaAnos > 0) mensagem += $"{diferencaAnos} anos, ";
                    if (diferencaMeses > 0) mensagem += $"{diferencaMeses} meses, ";
                    if (diferencaDias > 0) mensagem += $"{diferencaDias} dias";

                    // Removendo a vírgula final, se houver
                    mensagem = mensagem.TrimEnd(',', ' ') + " para a formatura.";

                    Console.WriteLine("\n" + mensagem);

                    if ((diferencaAnos == 0 && diferencaMeses < 6) || (diferencaAnos == 0 && diferencaMeses == 6 && diferencaDias == 0))
                    {
                        Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
                    }

                    dataErrada = false;
                }      
            }
            else if (dataUsuario > hoje)
            {
                Console.WriteLine("\nErro: A data informada não pode ser no futuro! Tente novamente.");
            }
            else
            {
                Console.WriteLine("\nFormato de data inválido. Tente novamente.");
            }
        }
    }
}