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
                WorkerUtilities.ClearAndShowMessage($"Erro ao listar trabalhadores: {ex.Message}");
            }
            break;

        case "2":
            int workerId = WorkerUtilities.ReadValidInt("Digite o id do trabalhador: ");

            try
            {
                WorkerUtilities.ClearAndShowMessage(WorkerUtilities.ToDetailedString(await cliente.WorkerAsync(workerId)));
            }
            catch (Exception ex)
            {
                WorkerUtilities.ClearAndShowMessage($"Erro ao obter trabalhador: {ex.Message}");
            }
            break;

        case "3":
            var newWorker = WorkerUtilities.InputWorker(true);
            try
            {
                WorkerUtilities.ClearAndShowMessage(WorkerUtilities.ToDetailedString(await cliente.AddWorkerAsync(newWorker)));
            }
            catch (Exception ex)
            {
                WorkerUtilities.ClearAndShowMessage($"Erro ao adicionar trabalhador: {ex.Message}");
            }
            break;

        case "4":
            Worker? updatedWorker = WorkerUtilities.InputWorker(false);
            try
            {
                WorkerUtilities.ClearAndShowMessage(WorkerUtilities.ToDetailedString(await cliente.UpdateWorkerAsync(updatedWorker)));
            }
            catch (Exception ex)
            {
                WorkerUtilities.ClearAndShowMessage($"Erro ao atualizar trabalhador: {ex.Message}");
            }
            break;
        case "5":
            int removeWorkerId = WorkerUtilities.ReadValidInt("Digite o id do trabalhador a ser removido: ");
            try
            {
                await cliente.DeleteWorkerAsync(removeWorkerId);
                WorkerUtilities.ClearAndShowMessage("Trabalhador removido com sucesso.");
            }
            catch (Exception ex)
            {
                WorkerUtilities.ClearAndShowMessage($"Erro ao remover trabalhador: {ex.Message}");
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