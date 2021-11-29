using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange: MonoBehaviour
{
    [SerializeField] private string sceneName = "";
    [SerializeField] private bool activated = true;

    public void OnButtonPressed()
    {
        LevelData levelData;
        if ((levelData = GetComponent<LevelData>()) != null)
        {
            if (levelData.Unlocked == true)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        if (activated == true)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void SetActivate(bool activated)
    {
        this.activated = activated;
    }
}
