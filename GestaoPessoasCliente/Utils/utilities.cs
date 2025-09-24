using GestaoPessoasCliente.ApiClients;
using System;

namespace GestaoPessoasCliente.Utils
{
    public class WorkerUtilities
    {
        public Worker InputWorker()
        {
            Console.WriteLine("Digite os detalhes do trabalhador:");
            int id = ReadValidInt("Id: ");
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
                Console.WriteLine("Resultado: \n"+ Reply + "\n");
            Console.WriteLine("Gestão de Trabalhadores - Cliente");
            Console.WriteLine("1 - Listar Trabalhadores\n2 - Obter Trabalhador por ID\n3 - Adicionar Trabalhador\n4 - Atualizar Trabalhador\n5 - Remover Trabalhador\n0 - Sair");
            Console.Write("Escolha uma opção: ");
        }

        internal int ReadValidInt(string prompt)
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