namespace BuildAnalyzer.Core;

/// <summary>
/// Выполняет расчёты характеристик игровой сборки.
/// </summary>
public static class BuildCalculator
{
    /// <summary>
    /// Рассчитывает все характеристики сборки.
    /// </summary>
    /// <param name="build">Сборка персонажа для анализа.</param>
    /// <returns>Результат расчёта.</returns>
    public static BuildAnalysis Analyze(CharacterBuild build)
    {
        ArgumentNullException.ThrowIfNull(build);

        var totalAttack = CalculateTotalAttack(build);
        var criticalDamage = CalculateCriticalDamage(build);
        var averageDamage = CalculateAverageDamage(build);
        var rating = DetermineRating(averageDamage);

        return new BuildAnalysis(totalAttack, criticalDamage, averageDamage, rating);
    }

    /// <summary>
    /// Рассчитывает итоговую атаку как сумму базовой атаки и атаки оружия.
    /// </summary>
    /// <param name="build">Сборка персонажа.</param>
    /// <returns>Итоговая атака.</returns>
    public static decimal CalculateTotalAttack(CharacterBuild build)
    {
        ArgumentNullException.ThrowIfNull(build);
        return build.BaseAttack + build.WeaponAttack;
    }

    /// <summary>
    /// Рассчитывает урон при критическом ударе.
    /// </summary>
    /// <param name="build">Сборка персонажа.</param>
    /// <returns>Урон при критическом ударе.</returns>
    public static decimal CalculateCriticalDamage(CharacterBuild build)
    {
        ArgumentNullException.ThrowIfNull(build);
        return CalculateTotalAttack(build) * (1 + build.CriticalDamagePercent / 100m);
    }

    /// <summary>
    /// Рассчитывает средний ожидаемый урон с учётом шанса критического удара.
    /// </summary>
    /// <param name="build">Сборка персонажа.</param>
    /// <returns>Средний ожидаемый урон.</returns>
    public static decimal CalculateAverageDamage(CharacterBuild build)
    {
        ArgumentNullException.ThrowIfNull(build);
        return CalculateTotalAttack(build) *
               (1 + build.CriticalChancePercent / 100m * build.CriticalDamagePercent / 100m);
    }

    /// <summary>
    /// Определяет рейтинг сборки по среднему ожидаемому урону.
    /// </summary>
    /// <param name="averageDamage">Средний ожидаемый урон.</param>
    /// <returns>Рейтинг сборки.</returns>
    public static BuildRating DetermineRating(decimal averageDamage)
    {
        return averageDamage switch
        {
            < 1500m => BuildRating.Weak,
            < 2500m => BuildRating.Normal,
            < 3500m => BuildRating.Good,
            _ => BuildRating.Excellent
        };
    }
}
