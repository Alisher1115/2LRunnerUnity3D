using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    private Transform root;
    
    [SerializeField]
    private Text currentScoreText, bestScoreText;

    [SerializeField]
    private Button restartBtn, quitBtn;

    public void Init(float currentScore, float bestScore){
        root.gameObject.SetActive(true);
        currentScoreText.text = "Your score: " + currentScore;
        bestScoreText.text = "Best score: " + bestScore;
    }
    // Start is called before the first frame update

    void Start()
    {
        restartBtn.onClick.AddListener(Restart);
        quitBtn.onClick.AddListener(Quit);
        root.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart () {
        Debug.Log("Restart");
    }

    private void OnDestroy() {
        restartBtn.onClick.RemoveAllListeners(); 
        quitBtn.onClick.RemoveAllListeners(); 
    }

    public void Quit () {
        Debug.Log("Quit");
    }
}
