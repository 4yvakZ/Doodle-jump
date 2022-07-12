using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro highscreText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadDataFromFile();
        highscreText.text = "Highscore: " + GameManager.Instance.Highscore;
    }
}
