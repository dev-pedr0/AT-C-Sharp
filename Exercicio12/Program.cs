using System.Text.RegularExpressions;
using static Program;
internal class Program
{
    //Criação da classe contato
    public class Contato
    {
        //Criação das variáveis
        public string Nome;
        public string Telefone;
        public string Email;

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
                writer.WriteLine($"Nome: {this.Nome} | Telefone: {this.Telefone} | Email: {this.Email}");
                writer.WriteLine();
            }
        }
    }

    //Criação de classe que formata como o contato é visualizado
    public class ContatoFormatter
    {
        char formato;
        protected List<Contato> contatos = new List<Contato>();

        public ContatoFormatter(char formato)
        {
            this.formato = formato;
        }

        public virtual void ExibirContatos(string nomeArquivo)
        {
            {
                //Verifica se o qrquivo existe
                if (!File.Exists(nomeArquivo))
                {
                    Console.WriteLine("Arquivo de contatos não encontrado.");
                    return;
                }

                //Lê as linhas do arquivo
                string[] linhas = File.ReadAllLines(nomeArquivo);
                contatos.Clear();

                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split('|');

                    if (partes.Length == 3)
                    {
                        string nome = partes[0].Replace("Nome: ", "").Trim();
                        string telefone = partes[1].Replace(" Telefone: ", "").Trim();
                        string email = partes[2].Replace(" Email: ", "").Trim();

                        //Adiciona contato a lista para ser mostrado
                        contatos.Add(new Contato(nome, telefone, email));
                    }
                }
            }
        }
    }

    //Criação de sub-classes
    public class MarkdownFormatter: ContatoFormatter
    {
        public MarkdownFormatter(char formato)
            :base('M')
        {
        }

        public override void ExibirContatos(string nomeArquivo)
        {
            base.ExibirContatos(nomeArquivo);

            Console.WriteLine("\n## Lista de Contatos\n");
            foreach (Contato contato in contatos)
            {
                Console.WriteLine($"- **Nome:** {contato.Nome}\n- 📞 Telefone: {contato.Telefone}\n- 📧 Email: {contato.Email}\n");
            }

        }
    }

    public class TabelaFormatter : ContatoFormatter
    {
        public TabelaFormatter(char formato)
            : base('T')
        {
        }

        public override void ExibirContatos(string nomeArquivo)
        {
            base.ExibirContatos(nomeArquivo);

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("\n| Nome | Telefone | Email |\n");
            Console.WriteLine("----------------------------------------\n");
            foreach (Contato contato in contatos)
            {
                Console.WriteLine($"| {contato.Nome} | {contato.Telefone} | {contato.Email}");
            }
            Console.WriteLine("\n----------------------------------------\n");
        }
    }

    public class RawTextFormatter : ContatoFormatter
    {
        public RawTextFormatter(char formato)
            : base('P')
        {
        }

        public override void ExibirContatos(string nomeArquivo)
        {
            base.ExibirContatos(nomeArquivo);

            Console.WriteLine("\n| Nome | Telefone | Email |\n");
            foreach (Contato contato in contatos)
            {
                Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
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
                    Console.WriteLine("\nComo você quer exibir os conatos?");
                    Console.WriteLine("M - Markdown");
                    Console.WriteLine("T - Tabela");
                    Console.WriteLine("P - Texto Puro");
                    Console.WriteLine("Escolha uma opção:");

                    string visual = "";
                    bool visualizarValido = false;
                    while(!visualizarValido)
                    {
                        visual = Console.ReadLine();

                        if (visual == "M" || visual == "T" || visual == "P")
                        {
                            visualizarValido = true;
                        }
                        else
                        {
                            Console.WriteLine("\nEscolha Inválida. Digite novamente.");
                        }
                    }

                    if (visual == "M")
                    {
                        MarkdownFormatter formato = new('M');
                        formato.ExibirContatos(nomeArquivo);
                    }
                    else if (visual == "T")
                    {
                        TabelaFormatter formato = new('T');
                        formato.ExibirContatos(nomeArquivo);
                    }
                    else
                    {
                        RawTextFormatter formato = new('T');
                        formato.ExibirContatos(nomeArquivo);
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