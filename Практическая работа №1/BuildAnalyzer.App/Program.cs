using System.Globalization;
using BuildAnalyzer.Core;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var characterName = ReadRequiredText("Введите имя персонажа: ");
var baseAttack = ReadNonNegativeDecimal("Введите базовую атаку: ");
var weaponAttack = ReadNonNegativeDecimal("Введите атаку оружия: ");
var criticalChance = ReadDecimalInRange("Введите шанс критического удара (0–100%): ", 0m, 100m);
var criticalDamage = ReadNonNegativeDecimal("Введите критический урон (%): ");

var build = new CharacterBuild(characterName, baseAttack, weaponAttack, criticalChance, criticalDamage);
var analysis = BuildCalculator.Analyze(build);

Console.WriteLine();
Console.WriteLine($"Персонаж: {build.CharacterName}");
Console.WriteLine($"Итоговая атака: {analysis.TotalAttack:F2}");
Console.WriteLine($"Средний урон: {analysis.AverageDamage:F2}");
Console.WriteLine($"Шанс критического удара: {build.CriticalChancePercent:F2}%");
Console.WriteLine($"Критический урон: {analysis.CriticalDamage:F2} ({build.CriticalDamagePercent:F2}%)");
Console.WriteLine($"Итоговый рейтинг сборки: {GetRatingName(analysis.Rating)}");

static string ReadRequiredText(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        var value = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        Console.WriteLine("Имя не может быть пустым. Повторите ввод.");
    }
}

static decimal ReadNonNegativeDecimal(string prompt) => ReadDecimalInRange(prompt, 0m, decimal.MaxValue);

static decimal ReadDecimalInRange(string prompt, decimal minimum, decimal maximum)
{
    while (true)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out var value) &&
            value >= minimum && value <= maximum)
        {
            return value;
        }

        Console.WriteLine($"Введите число от {minimum} до {maximum}.");
    }
}

static string GetRatingName(BuildRating rating) => rating switch
{
    BuildRating.Weak => "Слабая",
    BuildRating.Normal => "Нормальная",
    BuildRating.Good => "Хорошая",
    BuildRating.Excellent => "Отличная",
    _ => throw new ArgumentOutOfRangeException(nameof(rating), rating, null)
};
