using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    private float startTime = 3f;
    private int enemyCount = 0;
    private int maxEnemies = 5;
    [SerializeField] private TextMeshProUGUI enemyCountText;
    [SerializeField] private TextMeshProUGUI startText;
    [SerializeField] private TextMeshProUGUI startCountdownText;
    [SerializeField] private TextMeshProUGUI endText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        endText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime >= 0) {
            StartCountdown();
        }

        if(enemyCount > 0) ShowEnemyCount();
        if(enemyCount >= maxEnemies) EndGame();
    }

    public void IncreaseEnemyCount() {
        enemyCount++;
    }

    public void StartCountdown() {
        startTime -= Time.deltaTime;
        startCountdownText.text = startTime.ToString("0");
        if(startTime <= 0) startCountdownText.gameObject.SetActive(false);
    }

    public void ShowEnemyCount() {
        startText.gameObject.SetActive(false);
        enemyCountText.text = "Enemies: \n" + enemyCount.ToString();
        
    }

    public void EndGame() {
        enemyCount = 0;
        enemyCountText.gameObject.SetActive(false);
        SceneManager.LoadScene("EndScene");
    }
}
