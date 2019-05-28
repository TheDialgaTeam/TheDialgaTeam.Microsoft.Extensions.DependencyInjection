namespace TheDialgaTeam.Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Interface for services that require initialization.
    /// </summary>
    public interface IInitializable
    {
        void Initialize();
    }
}