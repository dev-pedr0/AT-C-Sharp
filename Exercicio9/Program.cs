using static Program;
using System.IO;

internal class Program
{
    //Definição da classe produto
    public class Produto
    {
        //Definição das variáeis de produtos
        protected string Nome;
        protected int QuantidadeEstoque;
        protected double PrecoUnitario;

        //Método construtor da classe produto       
        public Produto(string nome, int quantidadeEstoque, double precoUnitario)
        {
            this.Nome = nome;
            this.QuantidadeEstoque = quantidadeEstoque;
            this.PrecoUnitario = precoUnitario;
        }

        //Método para mostrar as informações do produto
        public void ExibirInformacoes()
        {
            Console.WriteLine($"Produto: {this.Nome} | Quantidade: {this.QuantidadeEstoque} | Preço: R$ {this.PrecoUnitario.ToString("F2")}");
        }

        //Parte 2: salva produto em arquivo
        public void SalvarProduto(string nomeArquivo)
        {
            using (StreamWriter writer = new StreamWriter(nomeArquivo, true))
            {
                writer.WriteLine($"{this.Nome}, {this.QuantidadeEstoque}, {this.PrecoUnitario}");
                writer.WriteLine();
            }
        }
    }
    
    private static void Main(string[] args)
    {
        //Array para guardar os produtos
        Produto[] arrayProdutos = new Produto[5];

        //Parte 2: nome do arquivo que vai salvar os dados
        string nomeArquivo = "Produtos.txt";

        //Boolean que define a continuação ou o fechamento do sistema
        bool loopOpcoes = true;

        Console.WriteLine("Sistema de Controle de Estoque\n");

        //Loop maior que mantém o programa aberto ou fecha ele
        while (loopOpcoes)
        {
            //Escolhas mostradas ao usuário
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. Inserir Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Sair");
            Console.WriteLine("---------------------------------");
            string? input = Console.ReadLine();
            int opcao;

            //COndicional para realizar a ação selecionada do usuário
            if (int.TryParse(input, out opcao))
            {
                //opção de Inserir produto
                if (opcao == 1)
                {
                    //Verificação do índice vazio no array de produtos
                    int indiceVazio = -1;
                    for (int i = 0; i < arrayProdutos.Length; i++)
                    {
                        if (arrayProdutos[i] == null)
                        {
                            indiceVazio = i;
                            break;
                        }
                    }

                    //Condicional que indica se um item vai ser criado ou se o array está cheio
                    if (indiceVazio != -1)
                    {
                        //Variaveis para criar um produto
                        string nome = "";
                        int quantidadeEstoque = 0;
                        double precoUnitario = 0.0;

                        //Loop para definir o nome do produto sem que ele esteja vazio
                        bool nomeValido = false;
                        while (!nomeValido)
                        {
                            Console.WriteLine("\nDigite o nome do produto:");
                            nome = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(nome))
                            {
                                Console.WriteLine("\nNome vazio. Digite novamente.");
                            }
                            else
                            {
                                nomeValido = true;
                            }
                        }

                        //Loop para definir a quantidade do produto com valores válidos
                        bool quantidadeValida = false;
                        while (!quantidadeValida)
                        {
                            Console.WriteLine("\nDigite a quantidade do produto:");
                            string quantidadeInput = Console.ReadLine();
                            if (int.TryParse(quantidadeInput, out quantidadeEstoque))
                            {
                                quantidadeValida = true;
                            }
                            else
                            {
                                Console.WriteLine("\nQuantidade Inválida. Digite novamente.");
                            }
                        }

                        //Loop para definir o valor do produto com números válidos
                        bool precoValida = false;
                        while (!precoValida)
                        {
                            Console.WriteLine("\nDigite o preço do produto:");
                            string precoInput = Console.ReadLine();
                            if (double.TryParse(precoInput, out precoUnitario))
                            {
                                precoUnitario = Math.Round(precoUnitario, 2);
                                precoValida = true;
                            }
                            else
                            {
                                Console.WriteLine("\nPreço Inválido. Digite novamente.");
                            }
                        }
                        
                        //Criando produto e adicionando ao array
                        Produto produto = new(nome, quantidadeEstoque, precoUnitario);
                        arrayProdutos[indiceVazio] = produto;

                        //Parte 2: salva produto em arquivo txt
                        produto.SalvarProduto(nomeArquivo);
                    }
                    else
                    {
                        Console.WriteLine("\nA lista de produtos está cheia!\n");
                    }
                }
                
                //Opção de visualizar produtos
                else if (opcao == 2)
                {
                    //Execução da função de exibir produto em todos os produtos do array
                    foreach (Produto produto in arrayProdutos)
                    {
                        //Verifica se não tem produtos naquele espaço do array
                        if (produto != null)
                        {
                            produto.ExibirInformacoes();
                        }
                    }

                    //Parte 2: lê o texto do arquivo e mostra o texto
                    Console.WriteLine("\nConteúdo do arquivo:");
                    string[] linhas = File.ReadAllLines(nomeArquivo);
                    foreach (string linha in linhas)
                    {
                        Console.WriteLine(linha);
                    }
                }
                else if (opcao == 3)
                {
                    //É possível adicionar essa linha para deletar o artquivo após o uso do programa para fins de teste
                    /*if (File.Exists(nomeArquivo))
                    {
                        File.Delete(nomeArquivo);
                        Console.WriteLine("Arquivo deletado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Arquivo não encontrado.");
                    }
                    */
                    Console.WriteLine("\nSaindo do Programa...\n");
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