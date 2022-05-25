namespace Asteroids.Core.Services.NASA;

public record NasaResponseModel
{
    public string AsteroidName { get; init; } = default!;
    public decimal Diameter { get; init; }
    public decimal Speed { get; init; }
    public DateTime ApproachDate { get; init; }
    public string PlanetName { get; init; } = default!;
}
