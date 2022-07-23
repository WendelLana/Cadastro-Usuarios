using wendel_d3_avaliacao.Models;
using wendel_d3_avaliacao.Repositories;

namespace wendel_d3_avaliacao
{
    internal class Program
    {
        private const string path = "database/log.txt";
        static void Main(string[] args)
        {
            UserRepository _user = new();

            FileStream fileStream = File.OpenWrite(path);

            LogRepository _log = new(fileStream);

            string option;
            do
            {
                Console.WriteLine("\nEscolha uma das opções abaixo:");
                Console.WriteLine("1 - Acessar");
                Console.WriteLine("0 - Cancelar\n");

                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        User connectedUser;
                        do
                        {
                            string email, password;
                            Console.WriteLine("Digite o email do usuário:");
                            email = Console.ReadLine();
                            Console.WriteLine("Digite a senha do usuário:");
                            password = Console.ReadLine();

                            connectedUser = _user.Login(email, password);
                            if (connectedUser == null) Console.WriteLine("Email e/ou senha inválidos!");

                        } while (connectedUser == null);

                        _log.RegisterLogin(connectedUser);
                        Console.WriteLine($"Seja bem vindo, {connectedUser.Name}!");

                        string opt;
                        do
                        {
                            Console.WriteLine("\nEscolha uma das opções abaixo:");
                            Console.WriteLine("1 - Deslogar");
                            Console.WriteLine("2 - Cadastrar novo usuário");
                            Console.WriteLine("0 - Encerrar sistema\n");
                            
                            opt = Console.ReadLine();

                            switch(opt)
                            {
                                case "1":
                                    Console.WriteLine("Deslogado com sucesso!");
                                    _log.RegisterLogout(connectedUser);
                                    break;
                                case "2":
                                    string name, email, password;
                                    Console.WriteLine("Digite o nome do usuário:");
                                    name = Console.ReadLine();
                                    Console.WriteLine("Digite o email do usuário:");
                                    email = Console.ReadLine();
                                    Console.WriteLine("Digite a senha do usuário:");
                                    password = Console.ReadLine();

                                    User newUser = new()
                                    {
                                        Name = name,
                                        Email = email,
                                        Password = password
                                    };

                                    _user.Create(newUser);

                                    break;
                                case "0":
                                    option = "0";
                                    Console.WriteLine("Encerrando sistema...");
                                    break;
                                default:
                                    Console.WriteLine("Opção inválida!");
                                    break;    
                            }
                        } while (opt != "1" && opt != "0");
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (option != "0");

            fileStream.Close();
        }
    }
}