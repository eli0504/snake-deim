using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public static MainMenuUI Instance { get; private set; }


    [SerializeField] private Button playButton;
    [SerializeField] private Button howToPlayButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private Button levelOneButton;
    [SerializeField] private Button levelTwoButton;

    [SerializeField] private Button quitHowToPlayPanelButton;

    [SerializeField] private GameObject howToPlayPanel;

    private void Awake()
    {
        // Singleton
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        Instance = this;


        playButton.onClick.AddListener(() => {Loader.Load(Loader.Scene.Level1);});
        howToPlayButton.onClick.AddListener(ShowHowToPlayPanel);
        quitButton.onClick.AddListener(Application.Quit);
        levelOneButton.onClick.AddListener(() => { Loader.Load(Loader.Scene.Level1); });
        levelTwoButton.onClick.AddListener(() => { Loader.Load(Loader.Scene.Level2); });

        quitHowToPlayPanelButton.onClick.AddListener(HideHowToPlayPanel);
        
        HideHowToPlayPanel();
        
        SoundManager.CreateSoundManagerGameObject();
    }

    private void ShowHowToPlayPanel()
    {
        howToPlayPanel.SetActive(true);
    }
    
    private void HideHowToPlayPanel()
    {
        howToPlayPanel.SetActive(false);
    }

}
