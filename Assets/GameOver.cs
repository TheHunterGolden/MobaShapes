using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public int highScore;
    public int currentScore;
    public Text highScoreText;
    public Text currentScoreText;

	// Use this for initialization
	void Start () {
        highScore = PlayerPrefs.GetInt("HighScore");
        currentScore = 0;

        if(currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
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
