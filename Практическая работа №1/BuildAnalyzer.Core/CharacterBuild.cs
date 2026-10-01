namespace BuildAnalyzer.Core;

/// <summary>
/// Описывает характеристики игровой сборки персонажа.
/// </summary>
public sealed class CharacterBuild
{
    /// <summary>
    /// Создаёт сборку с заданными характеристиками.
    /// </summary>
    /// <param name="characterName">Имя персонажа.</param>
    /// <param name="baseAttack">Базовая атака персонажа.</param>
    /// <param name="weaponAttack">Атака оружия.</param>
    /// <param name="criticalChancePercent">Шанс критического удара в процентах.</param>
    /// <param name="criticalDamagePercent">Критический урон в процентах.</param>
    /// <exception cref="ArgumentException">Возникает, когда имя не задано.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Возникает при недопустимых значениях характеристик.</exception>
    public CharacterBuild(
        string characterName,
        decimal baseAttack,
        decimal weaponAttack,
        decimal criticalChancePercent,
        decimal criticalDamagePercent)
    {
        if (string.IsNullOrWhiteSpace(characterName))
        {
            throw new ArgumentException("Имя персонажа не может быть пустым.", nameof(characterName));
        }

        if (baseAttack < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(baseAttack), "Базовая атака не может быть отрицательной.");
        }

        if (weaponAttack < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(weaponAttack), "Атака оружия не может быть отрицательной.");
        }

        if (criticalChancePercent is < 0 or > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(criticalChancePercent), "Шанс критического удара должен быть от 0 до 100 процентов.");
        }

        if (criticalDamagePercent < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(criticalDamagePercent), "Критический урон не может быть отрицательным.");
        }

        CharacterName = characterName.Trim();
        BaseAttack = baseAttack;
        WeaponAttack = weaponAttack;
        CriticalChancePercent = criticalChancePercent;
        CriticalDamagePercent = criticalDamagePercent;
    }

    /// <summary>
    /// Получает имя персонажа.
    /// </summary>
    public string CharacterName { get; }

    /// <summary>
    /// Получает базовую атаку персонажа.
    /// </summary>
    public decimal BaseAttack { get; }

    /// <summary>
    /// Получает атаку оружия.
    /// </summary>
    public decimal WeaponAttack { get; }

    /// <summary>
    /// Получает шанс критического удара в процентах.
    /// </summary>
    public decimal CriticalChancePercent { get; }

    /// <summary>
    /// Получает критический урон в процентах.
    /// </summary>
    public decimal CriticalDamagePercent { get; }
}
