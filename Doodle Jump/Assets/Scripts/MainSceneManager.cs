using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] private TMP_Text highscreText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadDataFromFile();
        highscreText.text = "Highscore: " + GameManager.Instance.Highscore;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
