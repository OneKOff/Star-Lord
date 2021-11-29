using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelData : MonoBehaviour
{
    [SerializeField] private int id;
    public int ID
    {
        get { return id; }
        private set { id = value; }
    }
    [SerializeField] private bool unlocked = false;
    public bool Unlocked
    {
        get { return unlocked; }
        private set { unlocked = value; }
    }
    [SerializeField] private bool completed = false;
    public bool Completed
    {
        get { return completed; }
        private set { completed = value; }
    }
    [SerializeField] private List<LevelData> nextLevels = new List<LevelData>();

    private void Awake()
    {
        bool flag = false;
        foreach (LevelData levelData in MapData.levelsData)
        {
            if (levelData.id == id)
            {
                flag = true;
                unlocked = levelData.unlocked;
                completed = levelData.completed;
                break;
            }
        }
        if (flag == false)
        {
            MapData.levelsData.Add(this);
        }

        if (unlocked == false) {
            GetComponent<Image>().sprite = GetComponent<ButtonImages>().lockedLevelImage.sprite;
        }
        else if (unlocked == true)
        {
            if (completed == false)
            {
                GetComponent<Image>().sprite = GetComponent<ButtonImages>().unlockedLevelImage.sprite;
            }
            else
            {
                GetComponent<Image>().sprite = GetComponent<ButtonImages>().completedLevelImage.sprite;
            }
        }
    }

    public void PlayLevel()
    {
        MapData.setCurrentLevelId(id);
        Debug.Log("Started level " + id);
    }
    public static void UnlockLevel(LevelData levelData)
    {
        levelData.unlocked = true;
        //levelData.GetComponent<SceneChange>().SetActivate(true);
    }
    public static void CompleteLevel(int levelId)
    {
        LevelData level = null;
        foreach (LevelData levelData in MapData.levelsData)
        {
            if (levelData.id == levelId)
            {
                levelData.completed = true;
                level = levelData;
                break;
            }
        }
        foreach (LevelData levelData in level.nextLevels)
        {
            UnlockLevel(levelData);
        }
    }
}
