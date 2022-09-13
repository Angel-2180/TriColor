using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score score;
    public int PlayerScore = 0;
    private bool canGetScore = true;

    public TextMeshProUGUI scoreDisplay;


    private void Awake() 
    {
        if(score == null)
        {
            score = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TimedScore());
        scoreDisplay.text = PlayerScore.ToString();
    }

    IEnumerator TimedScore()
    {
        if(canGetScore)
        {
            PlayerScore += 10;
            canGetScore = false;
            yield return new WaitForSeconds(1);
            canGetScore = true;
        }
    }
}
