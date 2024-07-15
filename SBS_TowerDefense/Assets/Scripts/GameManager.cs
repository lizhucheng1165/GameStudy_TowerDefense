using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool playerWon;
    private float startTime = 3f;
    
    [SerializeField] private TextMeshProUGUI enemyCountText;
    [SerializeField] private TextMeshProUGUI startCountdownText;
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private TextMeshProUGUI waveCountText;
    void Start()
    {
        startCountdownText.gameObject.SetActive(true);
        endText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime >= 0) {
            StartCountdown();
        }

        ShowEnemyCount();
    }

    

    public void StartCountdown() {
        startTime -= Time.deltaTime;
        startCountdownText.text = startTime.ToString("0");
        if(startTime <= 0) startCountdownText.gameObject.SetActive(false);
    }

    public void ShowEnemyCount() {
        enemyCountText.text = "Enemies: \n" + WaveManager.enemyCount.ToString();
    }

    public static void EndGame(bool won)
    {
        playerWon = won;
        SceneManager.LoadScene("EndScene");
    }
}
