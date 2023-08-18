using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score;
    public GameObject metalMedal;
    public GameObject goldMedal;
    public GameObject newHighScoreImage;
    public GameObject Menu;
    public GameObject PointsUI;

    public AudioClip scoreSound;

    public Text highScoreText;
    public Text scoreText;
    public Text scoreTextGameOver;

    void Start()
    {
        Menu.SetActive(true);
        Time.timeScale = 0;
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    private void OnEnable()
    {
        Actions.OnPointTouch += AddPoint;
    }

    private void OnDisable()
    {
        Actions.OnPointTouch -= AddPoint;
    }

    public void AddPoint(Points pointRef)
    {
        SoundManager.instance.PLaySound(scoreSound);
        Score++;
        scoreText.text = Score.ToString();
        scoreTextGameOver.text = Score.ToString();

        UpdateHighScore();
    }

    void UpdateHighScore()
    {
        if (Score > PlayerPrefs.GetInt("HighScore")) 
        {
            PlayerPrefs.SetInt("HighScore", Score);
            UpdateHighScoreText();
            goldMedal.SetActive(true);
            newHighScoreImage.SetActive(true);
            metalMedal.SetActive(false);

        }
        else
        {
            newHighScoreImage.SetActive(false);
            goldMedal.SetActive(false);
            metalMedal.SetActive(true);
        }
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = Score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void StartButtom()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
        PointsUI.SetActive(true);
    }

}
