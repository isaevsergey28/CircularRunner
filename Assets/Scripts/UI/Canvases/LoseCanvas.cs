using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseCanvas : ScreenView
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;
    
    public override void Init()
    {
        _restartButton.onClick.AddListener(RestartGame);
        _mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    public override void OnShow()
    {
        
    }

    public override void OnHide()
    {

    }
    
    private void RestartGame()
    {
        StartCoroutine(LoadSceneAsync(SceneManager.GetActiveScene().buildIndex));
    }
    
    private void LoadMainMenu()
    {
        StartCoroutine(LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1));
    }
    
    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!loadOperation.isDone)
        {
            yield return null;
        }
    }
}
