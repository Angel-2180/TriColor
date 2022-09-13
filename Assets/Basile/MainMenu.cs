using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu current;

    public TextMeshProUGUI scoreDisplay;

    private void Awake()
    {
        current = this;
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReplayGame ()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame ()
    {
        Debug.Log("Je quitte");
        Application.Quit();
    }

    public void UpdateScore()
    {
        scoreDisplay.text = $"Your score : {Score.score.PlayerScore}";
    }
}
