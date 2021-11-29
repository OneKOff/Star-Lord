using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            CompleteLevel();
        }
    }

    public void CompleteLevel()
    {
        LevelData.CompleteLevel(MapData.currentLevelId);

        foreach (LevelData level in MapData.levelsData)
        {
            Debug.Log("Level " + level.ID + ", Unlocked: " + level.Unlocked + ", Completed: " + level.Completed);
        }

        SceneManager.LoadScene("GameMap");
    }
}
