using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public float highScore;
    public float currentScore;
    public Text highScoreText;
    public Text currentScoreText;
    public Scorebar scoreBar;

	// Use this for initialization
	void Start () {
        highScore = PlayerPrefs.GetFloat("HighScore");
        currentScore = scoreBar.score;

        if(currentScore > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", currentScore);
            highScore = currentScore;
        }

        currentScoreText.text = currentScore.ToString();
        highScoreText.text = highScore.ToString();
    }
	
    public void Restart()
    {
        SceneManager.LoadScene("mobascene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
