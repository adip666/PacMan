using PacMan.Seeds;

namespace PacMan.Core
{
    public interface IGameManager
    {
         void RegisterSeed(Seed seed);
         void UnRegisterSeed(Seed seed);

         void RestartGame();

         int CurrentLevel { get; }
    }
}