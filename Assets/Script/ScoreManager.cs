using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Score
{
    public static float score;
}

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    void Update()
    {
        scoreText.text = "Score : " + Score.score.ToString();
    }
}
