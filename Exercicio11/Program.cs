using System.Text.RegularExpressions;
internal class Program
{
    //Criação da classe contato
    public class Contato
    {
        //Criação das variáveis
        string Nome;
        string Telefone;
        string Email;

        //Método contrutor do contato
        public Contato(string nome, string telefone, string email)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
        }

        //Método para salvar contato em arquivo
        public void SalvarContato(string nomeArquivo)
        {
            using (StreamWriter writer = new StreamWriter(nomeArquivo, true))
            {
                writer.WriteLine($"{this.Nome} | {this.Telefone} | {this.Email}");
                writer.WriteLine();
            }
        }
    }

    private static void Main(string[] args)
    {
        //Controla loop de opções
        bool loopOpcoes = true;

        //Regex para verificar inputs do usuário
        string nomeRegex = @"^[A-Za-zÀ-ÿ\s]+$";
        string telefoneRegex = "^(\\(\\d{2}\\)\\s?)?\\d{5}-\\d{4}$";
        string emailRegex = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

        //Nome do arquivo para salvar os contatos
        string nomeArquivo = "Contatos.txt";

        Console.WriteLine("Sistema de Controle de Estoque\n");

        //Loop maior que mantém o programa aberto ou fecha ele
        while (loopOpcoes)
        {
            //Escolhas mostradas ao usuário
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. Adicionar novo contato");
            Console.WriteLine("2. Listar contatos cadastrados");
            Console.WriteLine("3. Sair");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Escolha uma opção:");
            string? input = Console.ReadLine();
            int opcao;

            //COndicional para realizar a ação selecionada do usuário
            if (int.TryParse(input, out opcao))
            {
                //opção de adicionar contatos
                if (opcao == 1)
                {
                    //Variáveis para criar o contato
                    string nome = "";
                    string telefone = "";
                    string email = "";

                    //Input de nome
                    bool nomeValido = false;
                    while (!nomeValido)
                    {
                        Console.WriteLine("\nDigite o nome do contato:");
                        nome = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(nome))
                        {
                            Console.WriteLine("\nNome vazio. Digite novamente.");
                        }
                        else if (!Regex.IsMatch(nome, nomeRegex))
                        {
                            Console.WriteLine("\nNome Inválido. Digite novamente.");
                        }
                        else
                        {
                            nomeValido = true;
                        }
                    }

                    //Input do telefone
                    bool telefoneValido = false;
                    while (!telefoneValido)
                    {
                        Console.WriteLine("\nDigite o telefone do contato:");
                        telefone = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(telefone))
                        {
                            Console.WriteLine("\nTelefone vazio. Digite novamente.");
                        }
                        else if (!Regex.IsMatch(telefone, telefoneRegex))
                        {
                            Console.WriteLine("\nTelefone Inválido. Digite novamente.");
                        }
                        else
                        {
                            telefoneValido = true;
                        }
                    }

                    //Input do email
                    bool emailValido = false;
                    while (!emailValido)
                    {
                        Console.WriteLine("\nDigite o e-mail do contato:");
                        email = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(email))
                        {
                            Console.WriteLine("\nE-mail vazio. Digite novamente.");
                        }
                        else if (!Regex.IsMatch(email, emailRegex))
                        {
                            Console.WriteLine("\nE-mail Inválido. Digite novamente.");
                        }
                        else
                        {
                            emailValido = true;
                        }
                    }

                    //Cria contato
                    Contato contato = new(nome, telefone, email);

                    //Salva contato
                    contato.SalvarContato(nomeArquivo);
                }

                //Opção de visualizar contatos
                else if (opcao == 2)
                {
                    Console.WriteLine("\nContatos Cadastrados:\n");
                    string[] linhas = File.ReadAllLines(nomeArquivo);
                    foreach (string linha in linhas)
                    {
                        Console.WriteLine(linha);
                    }
                }

                //Opção de fechar o programa
                else if (opcao == 3)
                {
                    Console.WriteLine("\nEncerrando programa...\n");
                    loopOpcoes = false;
                }
                else
                {
                    Console.WriteLine("\nOpção Inválida. Tente novamente!\n");
                }
            }
            else
            {
                Console.WriteLine("\nOpção Inválida. Tente novamente!\n");
            }
        }
    }
}
