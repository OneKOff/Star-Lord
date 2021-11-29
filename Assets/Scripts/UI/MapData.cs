using System.Collections.Generic;

public static class MapData
{
    public static List<LevelData> levelsData = new List<LevelData>();
    public static int currentLevelId { get; private set; }

    public static void setCurrentLevelId(int id)
    {
        currentLevelId = id;
    }
}
