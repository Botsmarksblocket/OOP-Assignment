namespace OperationOOP.Core.Models;
public class Bonsai : Plant
{
    public BonsaiStyle Style { get; private set; }

    public Bonsai(string name, string species, int ageYears, PlantCareLevel careLevel, BonsaiStyle style)
         : base(name, species, ageYears, careLevel)
    {
        Style = style;
    }

    public enum BonsaiStyle
    {
        Chokkan,    // Formal Upright
        Moyogi,     // Informal Upright
        Shakan,     // Slanting
        Kengai,     // Cascade
        HanKengai   // Semi-cascade
    }
}