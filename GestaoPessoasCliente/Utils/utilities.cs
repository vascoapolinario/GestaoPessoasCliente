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
        internal void ClearAndShowMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }

        internal void ShowMenu()
        {
            Console.WriteLine("\nGestão de Trabalhadores - Cliente");
            Console.WriteLine("1 - Listar Trabalhadores\n2 - Obter Trabalhador por ID\n3 - Adicionar Trabalhador\n4 - Atualizar Trabalhador\n5 - Remover Trabalhador\n0 - Sair");
            Console.Write("Escolha uma opção: ");
        }

        internal string ToDetailedString(Worker worker)
        {
            return $"| ID: {worker.Id} | Nome: {worker.Name} | Data de Nascimento: {worker.BirthDate} | Cargo: {worker.JobTitle} | Email: {worker.Email} |";
        }
    }
}