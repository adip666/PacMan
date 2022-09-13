using PacMan.Seeds;

namespace PacMan.Core
{
    public interface IGameManager
    {
         void RegisterSeed(Seed seed);
         void UnRegisterSeed(Seed seed);

         int CurrentLevel { get; }
    }
}