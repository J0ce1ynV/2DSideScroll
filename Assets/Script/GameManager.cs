using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    #region GameManager

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameManagerCheck()
    {
        Debug.Log("working");
    }

    #endregion

    #region Game Management
    public bool isPaused;
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    #endregion

    #region LevelManagement
    public int levelCurrent;
    
    public void CheckSaveFile()
    {
        if (File.Exists(Application.dataPath + "level.json"))
        {
            LoadLevel();
        }
        else SaveLevel();
    }

    private void SaveLevel()
    {
        LevelData leveldata = new LevelData();
        leveldata.level = levelCurrent;
        string json = JsonUtility.ToJson(leveldata);
        File.WriteAllText(Application.dataPath+"/level.json", json);
    }

    private void LoadLevel()
    {
        string json;
        json = File.ReadAllText(Application.dataPath + "/level.json");
        LevelData levelData = JsonUtility.FromJson<LevelData>(json);
        levelCurrent = levelData.level;
    }
    #endregion
}
