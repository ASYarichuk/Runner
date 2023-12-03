using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _gameOverScreen;

    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _quitButton;

    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(RestartGame);
        _quitButton.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(RestartGame);
        _quitButton.onClick.RemoveListener(QuitGame);
    }

    private void Start()
    {
        _gameOverScreen.alpha = 0;
    }

    private void OnDied()
    {
        _gameOverScreen.alpha = 1;
        Time.timeScale = 0;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0); 
        Time.timeScale = 1;
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
