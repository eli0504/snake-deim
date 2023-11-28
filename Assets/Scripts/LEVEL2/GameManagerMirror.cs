using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMirror : MonoBehaviour
{
    public static GameManagerMirror Instance { get; private set; }

    private LevelGridMirror levelGridMirror;
    private SnakeMirror snakeMirror;

    private bool isPaused;

    private void Awake()
    {
        // Singleton
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        Instance = this;
    }

    private void Start()
    {
        SoundManager.CreateSoundManagerGameObject();

        // Configuración de la cabeza de serpiente
        GameObject snakeHeadMirrorGameObject = new GameObject("Snake Head Mirror");
        SpriteRenderer snakeMirrorSpriteRenderer = snakeHeadMirrorGameObject.AddComponent<SpriteRenderer>();
        snakeMirrorSpriteRenderer.sprite = GameAssets.Instance.snakeHeadSprite;
        snakeMirror = snakeHeadMirrorGameObject.AddComponent<SnakeMirror>();

        // Configurar el LevelGrid
        levelGridMirror = new LevelGridMirror(20, 20);
        snakeMirror.Setup(levelGridMirror);
        levelGridMirror.Setup(snakeMirror);

        // Inicializo tema score
        Score.InitializeStaticScore();

        isPaused = false;
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     Loader.Load(Loader.Scene.Game);
        // }

        // Lógica de Pause con tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void SnakeDied()
    {
        GameOverUI.Instance.Show(Score.TrySetNewHighScore());
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseUI.Instance.Show();
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseUI.Instance.Hide();
        isPaused = false;
    }
}

