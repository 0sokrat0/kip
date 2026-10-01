using System.Net.Http.Json;
using TodoClient;

Console.OutputEncoding = System.Text.Encoding.UTF8;
using var client = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com/") };

Console.Write("ID пользователя: ");
var userId = ReadNumber();

while (true)
{
    Console.WriteLine("\n1. Показать задачи пользователя");
    Console.WriteLine("2. Найти задачу по ID");
    Console.WriteLine("3. Создать задачу");
    Console.WriteLine("4. Изменить статус задачи");
    Console.WriteLine("5. Удалить задачу");
    Console.WriteLine("0. Выход");
    Console.Write("Выберите действие: ");

    try
    {
        switch (Console.ReadLine())
        {
            case "1":
                var todos = await client.GetFromJsonAsync<List<Todo>>($"todos?userId={userId}") ?? [];
                foreach (var todo in todos) Print(todo);
                break;

            case "2":
                Console.Write("ID задачи: ");
                Print(await client.GetFromJsonAsync<Todo>($"todos/{ReadNumber()}") ?? throw new HttpRequestException());
                break;

            case "3":
                Console.Write("Название: ");
                var newTodo = new Todo { UserId = userId, Title = Console.ReadLine() ?? "", Completed = false };
                using (var response = await client.PostAsJsonAsync("todos", newTodo))
                    Console.WriteLine(response.IsSuccessStatusCode ? "Задача создана" : $"Ошибка: {(int)response.StatusCode}");
                break;

            case "4":
                Console.Write("ID задачи: ");
                var id = ReadNumber();
                Console.Write("Выполнена (true/false): ");
                var completed = bool.Parse(Console.ReadLine() ?? "false");
                using (var response = await client.PatchAsJsonAsync($"todos/{id}", new { completed }))
                    Console.WriteLine(response.IsSuccessStatusCode ? "Статус изменён" : $"Ошибка: {(int)response.StatusCode}");
                break;

            case "5":
                Console.Write("ID задачи: ");
                using (var response = await client.DeleteAsync($"todos/{ReadNumber()}"))
                    Console.WriteLine(response.IsSuccessStatusCode ? "Задача удалена" : $"Ошибка: {(int)response.StatusCode}");
                break;

            case "0": return;
        }
    }
    catch (HttpRequestException)
    {
        Console.WriteLine("Ошибка запроса");
    }
}

static int ReadNumber()
{
    while (!int.TryParse(Console.ReadLine(), out var number))
    {
        Console.Write("Введите число: ");
    }

    return number;
}

static void Print(Todo todo) =>
    Console.WriteLine($"{todo.Id}. {todo.Title} — {(todo.Completed ? "выполнена" : "не выполнена")}");
