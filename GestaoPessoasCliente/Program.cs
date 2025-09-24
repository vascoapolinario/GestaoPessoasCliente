using GestaoPessoasCliente.ApiClients;
using GestaoPessoasCliente.Utils;
using System.ComponentModel.Design;

Client cliente = new Client("https://localhost:7011", new HttpClient());
Console.WriteLine("Gestão de Trabalhadores - Cliente");
Console.WriteLine("1 - Listar Trabalhadores\n2 - Obter Trabalhador por ID\n3 - Adicionar Trabalhador\n4 - Atualizar Trabalhador\n5 - Remover Trabalhador\n0 - Sair");
Console.Write("Escolha uma opção: ");

string? choice = Console.ReadLine();
while (choice != "0")
{
    switch (choice)
    {
        case "1":
            try
            {
                var workers = await cliente.WorkersAsync();
                String workersString = "";
                foreach (var worker in workers)
                {
                    workersString = workersString + WorkerUtilities.workerToString(worker) + "\n";
                }
                WorkerUtilities.consoleClear(workersString);
            }
            catch (Exception ex)
            {
                WorkerUtilities.consoleClear($"Erro ao listar trabalhadores: {ex.Message}");
            }
            break;

        case "2":
            Console.Write("Digite o id do trabalhador: ");
            int workerId = Convert.ToInt32(Console.ReadLine());

            try
            {
                WorkerUtilities.consoleClear(WorkerUtilities.workerToString(await cliente.WorkerAsync(workerId)));
            }
            catch (Exception ex)
            {
                WorkerUtilities.consoleClear($"Erro ao obter trabalhador: {ex.Message}");
            }
            break;

        case "3":
            var newWorker = WorkerUtilities.InputWorker();
            try
            {
                WorkerUtilities.consoleClear(WorkerUtilities.workerToString(await cliente.AddWorkerAsync(newWorker)));
            }
            catch (Exception ex)
            {
                WorkerUtilities.consoleClear($"Erro ao adicionar trabalhador: {ex.Message}");
            }
            break;

        case "4":
            var updatedWorker = WorkerUtilities.InputWorker();
            try
            {
                WorkerUtilities.consoleClear(WorkerUtilities.workerToString(await cliente.UpdateWorkerAsync(updatedWorker)));
            }
            catch (Exception ex)
            {
                WorkerUtilities.consoleClear($"Erro ao atualizar trabalhador: {ex.Message}");
            }
            break;
        case "5":
            Console.Write("Digite o id do trabalhador a ser removido: ");
            int removeWorkerId = Convert.ToInt32(Console.ReadLine());
            try
            {
                await cliente.DeleteWorkerAsync(removeWorkerId);
                WorkerUtilities.consoleClear("Trabalhador removido com sucesso.");
            }
            catch (Exception ex)
            {
                WorkerUtilities.consoleClear($"Erro ao remover trabalhador: {ex.Message}");
            }
            break;
        case "0":
            break;
        default:
            WorkerUtilities.consoleClear("Opção inválida. Tente novamente.");
            break;

    }
    choice = Console.ReadLine();
}