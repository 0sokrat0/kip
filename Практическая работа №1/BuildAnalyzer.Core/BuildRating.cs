namespace BuildAnalyzer.Core;

/// <summary>
/// Представляет оценку качества игровой сборки.
/// </summary>
public enum BuildRating
{
    /// <summary>Слабая сборка.</summary>
    Weak,

    /// <summary>Нормальная сборка.</summary>
    Normal,

    /// <summary>Хорошая сборка.</summary>
    Good,

    /// <summary>Отличная сборка.</summary>
    Excellent
}
