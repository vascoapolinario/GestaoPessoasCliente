using GestaoPessoasCliente.ApiClients;

namespace GestaoPessoasCliente.Utils
{
    internal static class WorkerUtilities
    {
        internal static Worker InputWorker(bool NewWorker)
        {
            Console.WriteLine("Digite os detalhes do trabalhador:");
            int id = 0;
            if (!NewWorker)
            {
                Console.Write("Id: ");
                id = Convert.ToInt32(Console.ReadLine());
            }
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

        internal static string workerToString(Worker worker)
        {
            Console.WriteLine(worker);
            return $"ID: {worker.Id}, Nome: {worker.Name}, Data de Nascimento: {worker.BirthDate}, Cargo: {worker.JobTitle}, Email: {worker.Email}";
        }

        internal static string WorkersToString(IEnumerable<Worker> workers)
        {
            string result = "";
            foreach (var worker in workers)
            {
                result += workerToString(worker) + "\n";
            }
            return result;
        }

        internal static void consoleClear(string Reply)
        {
            Console.Clear();
            if (Reply != "")
                Console.WriteLine("Resultado: \n" + Reply + "\n");
            Console.WriteLine("Gestão de Trabalhadores - Cliente");
            Console.WriteLine("1 - Listar Trabalhadores\n2 - Obter Trabalhador por ID\n3 - Adicionar Trabalhador\n4 - Atualizar Trabalhador\n5 - Remover Trabalhador\n0 - Sair");
            Console.Write("Escolha uma opção: ");
        }

        internal static void ManageException(Exception ex)
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
                Console.WriteLine($"Ocorreu um erro inesperado\nDetalhes técnicos: {ex.Message}");
            }
        }

        internal static int ReadValidInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro.");
            }
        }
    }
}