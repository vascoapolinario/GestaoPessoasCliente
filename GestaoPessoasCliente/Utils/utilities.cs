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
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Data de Nascimento (yyyy-MM-dd): ");
            string birthDateAsString = Console.ReadLine() ?? string.Empty;
            DateOnly birthDate = DateOnly.Parse(birthDateAsString);
            Console.Write("Cargo: ");
            string jobTitle = Console.ReadLine() ?? string.Empty;
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? string.Empty;
            Console.Write("TimeZone: ");
            string timeZone = Console.ReadLine() ?? string.Empty;
            var newWorker = new Worker
            {
                Id = id,
                Name = name,
                BirthDate = birthDate,
                JobTitle = jobTitle,
                Email = email,
                TimeZone = timeZone
            };
            return newWorker;
        }
        internal static void ClearAndShowMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }

        internal static void ShowMenu()
        {
            Console.WriteLine("\nGestão de Trabalhadores - Cliente");
            Console.WriteLine("1 - Listar Trabalhadores\n2 - Obter Trabalhador por ID\n3 - Adicionar Trabalhador\n4 - Atualizar Trabalhador\n5 - Remover Trabalhador\n0 - Sair");
            Console.Write("Escolha uma opção: ");
        }

        internal static void ManageException(Exception ex)
        {
            if (ex is ApiException<ValidationProblemDetails> apiExValidation)
            {
                var errors = apiExValidation.Result.Errors;
                ClearAndShowMessage("Erro de dados inválidos:");
                foreach (var error in errors)
                {
                    Console.WriteLine($"\n{error.Key}: {string.Join(", ", error.Value)}");
                }
            }
            else if (ex is ApiException apiEx)
            {
                switch (apiEx.StatusCode)
                {
                    case 400:
                        ClearAndShowMessage("Requisição inválida.");
                        break;
                    case 404:
                        ClearAndShowMessage("O Recurso procurado não foi encontrado");
                        break;
                    case 500:
                        ClearAndShowMessage("Erro interno do servidor.");
                        break;
                    default:
                        ClearAndShowMessage("Erro detectado na API");
                        break;
                }
            }
            else
            {
                ClearAndShowMessage($"Ocorreu um erro inesperado\nDetalhes técnicos: {ex.Message}");
            }
        }

        internal static string ToDetailedString(Worker worker)
        {
            return $"| ID: {worker.Id} | Nome: {worker.Name} | Data de Nascimento: {worker.BirthDate} | Cargo: {worker.JobTitle} | Email: {worker.Email} | TimeZone: {worker.TimeZone}";
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