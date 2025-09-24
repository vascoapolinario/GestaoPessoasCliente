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
                Console.Clear();
                var workers = await cliente.WorkersAsync();
                foreach (var worker in workers)
                {
                    Console.WriteLine(worker);
                }
            }
            catch (Exception ex)
            {
                utilities.ClearAndShowMessage($"Erro ao listar trabalhadores: {ex.Message}");
            }
            break;

        case "2":
            Console.Write("Digite o id do trabalhador: ");
            int workerId = Convert.ToInt32(Console.ReadLine());

            try
            {
                utilities.ClearAndShowMessage((await cliente.WorkerAsync(workerId)).ToDetailedString());
            }
            catch (Exception ex)
            {
                utilities.ClearAndShowMessage($"Erro ao obter trabalhador: {ex.Message}");
            }
            break;

        case "3":
            var newWorker = utilities.InputWorker();
            try
            {
                utilities.ClearAndShowMessage((await cliente.AddWorkerAsync(newWorker)).ToDetailedString());
            }
            catch (Exception ex)
            {
                utilities.ClearAndShowMessage($"Erro ao adicionar trabalhador: {ex.Message}");
            }
            break;

        case "4":
            Worker? updatedWorker = utilities.InputWorker();
            try
            {
                utilities.ClearAndShowMessage((await cliente.UpdateWorkerAsync(updatedWorker)).ToDetailedString());
            }
            catch (Exception ex)
            {
                utilities.ClearAndShowMessage($"Erro ao atualizar trabalhador: {ex.Message}");
            }
            break;
        case "5":
            Console.Write("Digite o id do trabalhador a ser removido: ");
            int removeWorkerId = Convert.ToInt32(Console.ReadLine());
            try
            {
                await cliente.DeleteWorkerAsync(removeWorkerId);
                utilities.ClearAndShowMessage("Trabalhador removido com sucesso.");
            }
            catch (Exception ex)
            {
                utilities.ClearAndShowMessage($"Erro ao remover trabalhador: {ex.Message}");
            }
            break;
        case "0":
            break;
        default:
            utilities.ClearAndShowMessage("Opção inválida. Tente novamente.");
            break;

    }
    utilities.ShowMenu();
    choice = Console.ReadLine();
}