using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Player player;

    [SerializeField]
    private GameOverPanel gameOverPanel;

    [SerializeField]
    private GameWinPanel gameWinPanel;

    // Start is called before the first frame update
    void Start()
    {
        player.onGameOver += GameOver;
        player.onGameWin += GameWin;
    }

    [SerializeField]
    private float score;
    // Update is called once per frame
    void Update()
    {
        score = player.transform.position.z;
        scoreText.text = player.transform.position.z.ToString("0");
    }

    private void GameOver(){
        float bestScore = PlayerPrefs.GetFloat("Score");
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("Score", score);
        }      
        gameOverPanel.Init(score, bestScore);
    }

    private void GameWin(){
        float bestScore = PlayerPrefs.GetFloat("Score");
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("Score", score);
        }      
        gameWinPanel.Init(score, bestScore);
    }
}
