namespace TheDialgaTeam.Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Interface for services that require late initialization.
    /// </summary>
    public interface ILateInitializable
    {
        void LateInitialize();
    }
}