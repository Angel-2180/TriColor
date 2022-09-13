using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public float Slowdown_Factor;
    public float Slowdown_Length;

    public GameObject GameOverScreen;
    private bool isslowdown;

    public static GameOver current;

    private void Awake()
    {
        current = this;
    }

    public void _GameOver()
    {
        StartSlowMotion();
    }

    private void Update()
    {
        if (isslowdown)
        {
            Time.timeScale = (1f / Slowdown_Length) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            if (Time.timeScale <= 1)
            {
                GameOverScreen.SetActive(true);
                MainMenu.current.UpdateScore();
            }
        }
    }

    private void StartSlowMotion()
    {
        Time.timeScale = Slowdown_Factor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        isslowdown = true;
    }
}