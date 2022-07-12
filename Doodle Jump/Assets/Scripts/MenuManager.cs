using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text highscreText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadDataFromFile();
        highscreText.text = "Highscore: " + GameManager.Instance.Highscore;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
