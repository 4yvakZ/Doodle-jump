using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{

    public static MainSceneManager Instance { get; private set; }

    [SerializeField] private Transform doodleTransform;

    [Header("UI Text")]
    [SerializeField] private TMP_Text highscoreText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text newHighscoreText;

    [Header("UI Buttons")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button pauseButton;
    private int score = 0;
    private bool isPaused = false;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadDataFromFile();
        highscoreText.text = "Highscore: " + GameManager.Instance.Highscore;
    }

    void Update()
    {

        if (doodleTransform != null && Mathf.FloorToInt(doodleTransform.position.y) > score)
        {
            score = Mathf.FloorToInt(doodleTransform.position.y);
            scoreText.text = "Score: " + score;
        }


        if (Application.platform == RuntimePlatform.Android)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    ResumeGame();
                    isPaused = false;
                    return;
                }

                SceneManager.LoadScene(0);
            }
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        highscoreText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        if (score > GameManager.Instance.Highscore)
        {
            GameManager.Instance.Highscore = score;
            GameManager.Instance.SaveDataToFile();
            newHighscoreText.gameObject.SetActive(true);
            newHighscoreText.text = "New Highscore: " + score;
        }
    }
}
