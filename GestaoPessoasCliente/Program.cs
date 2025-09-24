using GestaoPessoasCliente.ApiClients;
using GestaoPessoasCliente.Utils;
using System.ComponentModel.Design;

Client cliente = new Client("https://localhost:7011", new HttpClient());
WorkerUtilities utilities = new WorkerUtilities();
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
                    workersString = workersString + utilities.workerToString(worker) + "\n";
                }
                utilities.consoleClear(workersString);
            }
            catch (Exception ex)
            {
                utilities.ManageException(ex);
            }
            break;

        case "2":

            try
            {
                Console.Write("Digite o id do trabalhador: ");
                int workerId = Convert.ToInt32(Console.ReadLine());
                utilities.consoleClear(utilities.workerToString(await cliente.WorkerAsync(workerId)));
            }
            catch (Exception ex)
            {
                utilities.ManageException(ex);
            }
            break;

        case "3":
            try
            {
                var newWorker = utilities.InputWorker();
                utilities.consoleClear(utilities.workerToString(await cliente.AddWorkerAsync(newWorker)));
            }
            catch (Exception ex)
            {
                utilities.ManageException(ex);
            }
            break;

        case "4":
            try
            {
                var updatedWorker = utilities.InputWorker();
                utilities.consoleClear(utilities.workerToString(await cliente.UpdateWorkerAsync(updatedWorker)));
            }
            catch (Exception ex)
            {
                utilities.ManageException(ex);
            }
            break;
        case "5":
            try
            {
                Console.Write("Digite o id do trabalhador a ser removido: ");
                int removeWorkerId = Convert.ToInt32(Console.ReadLine());
                await cliente.DeleteWorkerAsync(removeWorkerId);
                utilities.consoleClear("Trabalhador removido com sucesso.");
            }
            catch (Exception ex)
            {
                utilities.ManageException(ex);
            }
            break;
        case "0":
            break;
        default:
            utilities.consoleClear("Opção inválida. Tente novamente.");
            break;

    }
    choice = Console.ReadLine();
}