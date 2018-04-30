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
    public CooldownTimer[] cd;
    public WasdMovement movement;

    // Use this for initialization
    void Start () {
        highScore = PlayerPrefs.GetFloat("HighScore");
        currentScore = scoreBar.score;

        movement.enableSwordAttack = false;
        for(int i = 0; i < cd.Length; i++)
        {
            cd[i].canUse = false;
        }

        if(currentScore > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", currentScore);
            highScore = currentScore;
        }

        currentScoreText.text = currentScore.ToString();
        highScoreText.text = highScore.ToString();

        Cursor.visible = true;
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
