using GestaoPessoasCliente.ApiClients;
using System;

namespace GestaoPessoasCliente.Utils
{
    public class WorkerUtilities
    {
        public Worker InputWorker()
        {
            Console.WriteLine("Digite os detalhes do trabalhador:");
            Console.Write("Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Data de Nascimento (yyyy-MM-dd): ");
            DateOnly birthDate = DateOnly.Parse(Console.ReadLine());
            Console.Write("Cargo: ");
            string jobTitle = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            var newWorker = new Worker
            {
                Id = id,
                Name = name,
                BirthDate = birthDate,
                JobTitle = jobTitle,
                Email = email
            };
            return newWorker;
        }

        public string workerToString(Worker worker)
        {
            Console.WriteLine(worker);
            return $"ID: {worker.Id}, Nome: {worker.Name}, Data de Nascimento: {worker.BirthDate}, Cargo: {worker.JobTitle}, Email: {worker.Email}";
        }

        public string WorkersToString(IEnumerable<Worker> workers)
        {
            string result = "";
            foreach (var worker in workers)
            {
                result += workerToString(worker) + "\n";
            }
            return result;
        }

        public void consoleClear(string Reply)
        {
            Console.Clear();
            if (Reply != "")
                Console.WriteLine("Resultado: \n" + Reply + "\n");
            Console.WriteLine("Gestão de Trabalhadores - Cliente");
            Console.WriteLine("1 - Listar Trabalhadores\n2 - Obter Trabalhador por ID\n3 - Adicionar Trabalhador\n4 - Atualizar Trabalhador\n5 - Remover Trabalhador\n0 - Sair");
            Console.Write("Escolha uma opção: ");
        }

        internal void ManageException(Exception ex)
        {
            if (ex is ApiException apiEx)
            {
                switch (apiEx.StatusCode)
                {
                    case 400:
                        Console.WriteLine("Requisição inválida.");
                        break;
                    case 404:
                        Console.WriteLine("O Recurso procurado não foi encontrado");
                        break;
                    case 500:
                        Console.WriteLine("Erro interno do servidor.");
                        break;
                    default:
                        Console.WriteLine($"Erro detetado na API");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Ocorreu um erro inesperado");
            }
        }
    }
}