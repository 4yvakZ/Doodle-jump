using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] private TMP_Text highscoreText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Transform doodleTransform;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadDataFromFile();
        highscoreText.text = "Highscore: " + GameManager.Instance.Highscore;
    }

    void Update()
    {
        if (Mathf.FloorToInt(doodleTransform.position.y) > score)
        {
            score = Mathf.FloorToInt(doodleTransform.position.y);
            scoreText.text = "Score: " + score;
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
