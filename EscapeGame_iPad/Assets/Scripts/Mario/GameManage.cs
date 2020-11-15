using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{

    [SerializeField] GameObject GameOverTextObj;
    [SerializeField] GameObject GameClearTextObj;
    [SerializeField] Text scoreText;
    
    //SE
    [SerializeField] AudioClip gameOverSE;
    [SerializeField] AudioClip damage;
    //[SerializeField] Text scoreText;
    AudioSource audioSource;

    const int MAX_SCORE = 0;
    int score = 100;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReduceScore(int val)
    {
        score -= val;
        if (score <= MAX_SCORE)
        {
            score = MAX_SCORE;
            GameOver();
        }
        scoreText.text = score.ToString();
        audioSource.PlayOneShot(damage);
    }

    public void GameOver()
    {
        GameOverTextObj.SetActive(true);
        audioSource.PlayOneShot(gameOverSE);
        Invoke("RestartThisScene", 1f);

    }
    public void GameClear()
    {
        GameClearTextObj.SetActive(true);
        
    }

    void RestartThisScene()
    {
        Scene ThisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(ThisScene.name);
    }
}