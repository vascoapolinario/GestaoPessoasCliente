using GestaoPessoasCliente.ApiClients;
using GestaoPessoasCliente.Utils;

Client cliente = new Client("https://localhost:7011", new HttpClient());
WorkerUtilities utilities = new WorkerUtilities();
utilities.ShowMenu();

string? choice = Console.ReadLine();

while (choice != "0")
{
    switch (choice)
    {
        case "1":
            try
            {
                Console.Clear();
                var workers = await cliente.WorkersAsync();
                foreach (var worker in workers)
                {
                    Console.WriteLine(worker);
                }
            }
            catch (Exception ex)
            {
                WorkerUtilities.ManageException(ex);
            }
            break;

        case "2":
            try
            {
                int workerId = WorkerUtilities.ReadValidInt("Digite o id do trabalhador: ");
                WorkerUtilities.ClearAndShowMessage(WorkerUtilities.ToDetailedString(await cliente.WorkerAsync(workerId)));
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
                WorkerUtilities.ClearAndShowMessage(WorkerUtilities.ToDetailedString(await cliente.AddWorkerAsync(newWorker)));
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
                WorkerUtilities.ClearAndShowMessage(WorkerUtilities.ToDetailedString(await cliente.UpdateWorkerAsync(updatedWorker)));
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
                WorkerUtilities.ClearAndShowMessage("Trabalhador removido com sucesso.");
            }
            catch (Exception ex)
            {
                WorkerUtilities.ManageException(ex);
            }
            break;
        case "0":
            break;
        default:
            WorkerUtilities.ClearAndShowMessage("Opção inválida. Tente novamente.");
            break;

    }
    WorkerUtilities.ShowMenu();
    choice = Console.ReadLine();
}