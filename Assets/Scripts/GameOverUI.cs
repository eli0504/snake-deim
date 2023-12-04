using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    // Singleton
    public static GameOverUI Instance { get; private set; }
  
    [SerializeField] private TextMeshProUGUI messsageText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private Button levelTwoButtonGameOver;
    [SerializeField] private Button levelOneButtonGameOver;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Instance");
        }

        Instance = this;
        
        Hide();

        levelTwoButtonGameOver.onClick.AddListener(() => { Loader.Load(Loader.Scene.Level2); });
        levelOneButtonGameOver.onClick.AddListener(() => { Loader.Load(Loader.Scene.Level1); });
    }

    public void Show(bool hasNewHighScore)
    {
        UpdateScoreAndHighScore(hasNewHighScore);
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void UpdateScoreAndHighScore(bool hasNewHighScore)
    {
        scoreText.text = Score.GetScore().ToString();
        highScoreText.text = Score.GetHighScore().ToString();
        messsageText.text = hasNewHighScore ? "CONGRATULATIONS" : "DON'T WORRY, NEXT TIME";

        // if (hasNewHighScore)
        // {
        //     messsageText.text = "CONGRATULATIONS";
        // }
        // else
        // {
        //     messsageText.text = "DON'T WORRY, NEXT TIME";
        // }
    }

    public void GameOverLevels()
    {
        gameOverPanel.SetActive(true);
    }
}
