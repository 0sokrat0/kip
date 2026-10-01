namespace BuildAnalyzer.Core;

/// <summary>
/// Содержит результаты расчёта характеристик сборки.
/// </summary>
public sealed class BuildAnalysis
{
    /// <summary>
    /// Создаёт объект с результатами анализа.
    /// </summary>
    /// <param name="totalAttack">Итоговая атака.</param>
    /// <param name="criticalDamage">Урон при критическом ударе.</param>
    /// <param name="averageDamage">Средний ожидаемый урон.</param>
    /// <param name="rating">Рейтинг сборки.</param>
    public BuildAnalysis(decimal totalAttack, decimal criticalDamage, decimal averageDamage, BuildRating rating)
    {
        TotalAttack = totalAttack;
        CriticalDamage = criticalDamage;
        AverageDamage = averageDamage;
        Rating = rating;
    }

    /// <summary>Получает итоговую атаку.</summary>
    public decimal TotalAttack { get; }

    /// <summary>Получает урон при критическом ударе.</summary>
    public decimal CriticalDamage { get; }

    /// <summary>Получает средний ожидаемый урон.</summary>
    public decimal AverageDamage { get; }

    /// <summary>Получает рейтинг сборки.</summary>
    public BuildRating Rating { get; }
}
