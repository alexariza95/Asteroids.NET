namespace Asteroids.Core.Services.NASA;

public record NasaRequestModel
{
    public bool IsPotentiallyHazardous { get; init; }
    public decimal MaxEstimatedDiameter { get; init; }
    public decimal MinEstimatedDiameter { get; init; }
    public string PlanetName { get; init; } = default!;
}