namespace PacMan.Keys
{
    public class Key
    {
        public const string GAME_SCENE_NAME = "Playground";
        public const string MAIN_MENU_SCENE_NAME = "MainMenu";
        public const string LEVEL_PREFS_NAME = "Level";
        public const string LIFE_PREFS_NAME = "Life";
    }

    public class Values
    {
        public const int PLAYER_LIFE = 3;
    }

    public class Tag
    {
        public const string WALL = "Wall";
        public const string ENEMY = "Enemy";
        public const string PLAYER = "Player";
        public const string SAFE_PLACES = "SafePlace";
    }

    public enum Levels
    {
        Level_1,
        Level_2
    }
}