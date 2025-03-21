internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Digite seu nome:");
        string nome = Console.ReadLine();

        char[] letras = nome.ToCharArray();

        for (int i = 0; i < letras.Length; i++)
        {
            if (char.IsLetter(letras[i]))
            {
                if (letras[i] == 'z' || letras[i] == 'Z' || letras[i] == 'y' || letras[i] == 'Y')
                {
                    letras[i] -= (char)24;
                }
                else
                {
                    letras[i] = (char)(letras[i] + 2);
                }
            }
        }

        String novoNome = new string(letras);

        Console.WriteLine("");
        Console.WriteLine("Seu nome codificado é: " + novoNome + "!");

    }
}
