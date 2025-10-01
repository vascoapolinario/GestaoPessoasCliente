using GestaoPessoasCliente.ApiClients;
using GestaoPessoasCliente.Utils;

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
                WorkerUtilities.ManageException(ex);
            }
            break;

        case "2":
            try
            {
                Console.Write("Digite o id do trabalhador: ");
                int workerId = WorkerUtilities.ReadValidInt("Digite o id do trabalhador: ");
                WorkerUtilities.consoleClear(WorkerUtilities.workerToString(await cliente.WorkerAsync(workerId)));
            }
            catch (Exception ex)
            {
                WorkerUtilities.ManageException(ex);
            }
            break;

        case "3":
            try
            {
                var newWorker = WorkerUtilities.InputWorker(true);
                WorkerUtilities.consoleClear(WorkerUtilities.workerToString(await cliente.AddWorkerAsync(newWorker)));
            }
            catch (Exception ex)
            {
                WorkerUtilities.ManageException(ex);
            }
            break;

        case "4":
            try
            {
                var updatedWorker = WorkerUtilities.InputWorker(false);
                WorkerUtilities.consoleClear(WorkerUtilities.workerToString(await cliente.UpdateWorkerAsync(updatedWorker)));
            }
            catch (Exception ex)
            {
                WorkerUtilities.ManageException(ex);
            }
            break;
        case "5":
            try
            {
                Console.Write("Digite o id do trabalhador a ser removido: ");
                int removeWorkerId = WorkerUtilities.ReadValidInt("Digite o id do trabalhador a ser removido: ");
                await cliente.DeleteWorkerAsync(removeWorkerId);
                WorkerUtilities.consoleClear("Trabalhador removido com sucesso.");
            }
            catch (Exception ex)
            {
                WorkerUtilities.ManageException(ex);
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