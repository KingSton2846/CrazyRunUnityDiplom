using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private int _sceneCount;

    private void Awake()
    {
        _sceneCount = SceneManager.GetActiveScene().buildIndex;
    }

    // Запуск следующего уровня
    public void OnLoadNextScene()
    {
        SceneManager.LoadScene(_sceneCount + 1);
    }

    // Запуск конкретного уровня
    public void OnLoadCountScene(int countScene)
    {
        SceneManager.LoadScene(countScene);
    }

    // Запуск главного меню
    public void OnLoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    // Перезапуск уровня
    public void OnResertScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

    //Выход из игры
    public void ExitGame()
    {
        Application.Quit();
    }
}