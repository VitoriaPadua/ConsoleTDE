using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static cadastroCliente.cadastroCliente;


namespace cadastroCliente
{


    //CLASSE PRINCIPAL
    class Program
    {
        static Cadastro _cadastroCliente = new Cadastro();

        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Menu de Cadastro de Clientes  (@^-^@)/");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. Adicionar Cliente +");
                Console.WriteLine("2. Alterar Cliente #");
                Console.WriteLine("3. Consultar Cliente *");
                Console.WriteLine("4. Excluir Cliente -");
                Console.WriteLine("5. Sair X");
                Console.Write("Escolha apenas uma opção:) ");

                if (int.TryParse(Console.ReadLine(), out int opcao))
                {

                    switch (opcao)
                    {
                        case 1:
                            AdicionarCliente();
                            break;
                        case 2:
                            AlterarCliente();
                            break;
                        case 3:
                            ConsultarCliente();
                            break;
                        case 4:
                            ExcluirCliente();
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Opção inválida! Por favor, tente novamente.:)");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número.;)");
                }
            }
        }



        //CRUD

        //ADICIONAR CLIENTE
        static void AdicionarCliente()
        {
            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a idade do cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int idade))
            {
                Console.WriteLine("Idade inválida. Por favor, insira um número.");
                return;
            }

            Console.Write("Digite o email do cliente: ");
            string email = Console.ReadLine();

            Console.Write("Digite o CPF do cliente (11 números): ");
            string cpf = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit))
            {
                Console.WriteLine("CPF inválido. Por favor, insira um CPF válido com 11 números.:)");
                return;
            }
            Console.Write("Digite a cidade do cliente: ");
            string cidade = Console.ReadLine();

            Console.Write("Digite o estado do cliente: ");
            string estado = Console.ReadLine();


            Cliente cliente = new Cliente
            {
                Nome = nome,
                Idade = idade,
                Email = email,
                CPF = cpf,
                Cidade = cidade,
                Estado = estado
            };

            _cadastroCliente.AdicionarCadastro(cliente);
            Console.WriteLine($"Cliente cadastrado com sucesso! O ID gerado é: {cliente.Id}");

            Console.WriteLine("Pressione enter para continuar.");
            Console.ReadKey();
            Console.Clear();
        }

        static void ExibirClientesDisponíveis()
        {
            List<Cliente> clientes = _cadastroCliente.GetItens();

            if (clientes.Count > 0)
            {
                Console.WriteLine("Clientes Disponíveis:");
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum Cliente disponível.");
            }
        }



        //ALTERAR CLIENTE
        static void AlterarCliente()
        {
            List<Cliente> clientes = _cadastroCliente.GetItens(); 

            if (clientes.Count == 0)
            {
                Console.WriteLine("Não há clientes cadastrados para alterar.");
                return;

            }

            ExibirClientesDisponíveis(); 

            Console.Write("Digite o ID do cliente que você deseja alterar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Cliente clienteSelecionado = clientes.FirstOrDefault(c => c.Id == id);

                if (clienteSelecionado != null)
                {
                    Console.WriteLine($"Cliente encontrado: ID: {clienteSelecionado.Id}, Nome: {clienteSelecionado.Nome}, Idade: {clienteSelecionado.Idade}, Email: {clienteSelecionado.Email}, CPF: {clienteSelecionado.CPF}, Cidade: { clienteSelecionado.Cidade}, Estado: { clienteSelecionado.Estado}");
                    Console.WriteLine("Qual atributo você deseja fazer alteração?");
                    Console.WriteLine("1. Nome");
                    Console.WriteLine("2. Idade");
                    Console.WriteLine("3. Email");
                    Console.WriteLine("4. CPF");
                    Console.WriteLine("5. Cidade");
                    Console.WriteLine("6. Estado");
                    Console.WriteLine("7. Cancelar");

                    string opcao = Console.ReadLine();
                    switch (opcao)
                    {

                        //nome
                        case "1":
                            Console.Write("Digite o novo nome do cliente: ");
                            clienteSelecionado.Nome = Console.ReadLine();
                            Console.WriteLine("Nome alterado com sucesso!");
                            break;

                        case "2":
                            // Validação para a nova idade
                            while (true)
                            {
                                Console.Write("Digite a nova idade do cliente: ");
                                if (int.TryParse(Console.ReadLine(), out int idade) && idade > 0)
                                {
                                    clienteSelecionado.Idade = idade;
                                    Console.WriteLine("Idade alterada com sucesso!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Idade inválida! Tente novamente.");
                                }
                            }
                            break;

                            //email
                        case "3":
                            Console.Write("Digite o novo email do cliente: ");
                            clienteSelecionado.Email = Console.ReadLine();
                            Console.WriteLine("Email alterado com sucesso!");
                            break;

                            //CPF
                        case "4":
                            Console.Write("Digite o novo CPF do cliente: ");
                            clienteSelecionado.CPF = Console.ReadLine();
                            Console.WriteLine("CPF alterado com sucesso!");
                            break;

                            //Cidade
                        case "5":
                            Console.Write("Digite a nova cidade do cliente: ");
                            clienteSelecionado.Cidade = Console.ReadLine();
                            Console.WriteLine("Cidade alterada com sucesso!");
                            break;

                            //estado
                        case "6":
                            Console.Write("Digite o novo estado do cliente: ");
                            clienteSelecionado.Estado = Console.ReadLine();
                            Console.WriteLine("Estado alterado com sucesso!");
                            break;


                            //cancelamento
                        case "7":
                            Console.WriteLine("Alteração cancelada.");
                            break;


                            //errado
                        default:
                            Console.WriteLine("Opção inválida! Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, insira um número.");
            }

            Console.WriteLine("Pressione enter para continuar.");
            Console.ReadKey();
            Console.Clear();
        }



        //CONSULTAR CLIENTE
        static void ConsultarCliente()
        {
            ExibirClientesDisponíveis();

            Console.Write("Digite o ID do cliente que deseja consultar: ");
            if (int.TryParse(Console.ReadLine(), out int clienteId))
            {
                Cliente cliente = _cadastroCliente.GetItens().FirstOrDefault(c => c.Id == clienteId);
                if (cliente != null)
                {
                    // Exibe os detalhes do cliente consultado
                    Console.WriteLine("Detalhes do Cliente:");
                    Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Idade: {cliente.Idade}, Email: {cliente.Email}, CPF: {cliente.CPF}, Cidade: {cliente.Cidade}, Estado: {cliente.Estado}");
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado com esse ID.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, digite um número.:)");
            }

            Console.WriteLine("Pressione enter para continuar.");
            Console.ReadKey();
            Console.Clear();
        }



        //EXCLUIR CLIENTE
        static void ExcluirCliente()
        {
            ExibirClientesDisponíveis();

            Console.Write("Digite o ID do cliente para excluir: ");
            if (int.TryParse(Console.ReadLine(), out int clienteId))
            {
                _cadastroCliente.RemoverCadastro(clienteId);
                Console.WriteLine("Cliente foi  excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, digite um número.;)");
            }

            Console.WriteLine("Pressione enter para continuar.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}