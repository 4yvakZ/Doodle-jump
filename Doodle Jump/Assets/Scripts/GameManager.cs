using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    public int Highscore { get; set; }

    private const string fileName = "/savefile.json";

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    [System.Serializable]
    struct SaveData
    {
        public int highscore;

        public SaveData(int highscore)
        {
            this.highscore = highscore;
        }
    }

    public void LoadDataFromFile()
    {
        string path = Application.persistentDataPath + fileName;
        if (File.Exists(path))
        {
            SaveData data = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
            Highscore = data.highscore;
        }
        else
        {
            Highscore = 0;
        }
    }

    public void SaveDataToFile()
    {
        SaveData data =  new SaveData(Highscore);

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + fileName, json);
    }
}
