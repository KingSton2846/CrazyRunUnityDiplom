using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _playPanel;
    [SerializeField] private GameObject _pausePanel;

    // Запуск панели паузы
    public void OnPausaPanel()
    {
        _pausePanel.SetActive(true);

        _startPanel.SetActive(false);
        _winPanel.SetActive(false);
        _losePanel.SetActive(false);
        _playPanel.SetActive(false);
    }

    // Запуск панели игры
    public void OnPlayPanel()
    {
        _pausePanel.SetActive(false);
        _startPanel.SetActive(false);
        _winPanel.SetActive(false);
        _losePanel.SetActive(false);

        _playPanel.SetActive(true);
    }

    // Запуск стартовой панели
    public void OnStartPanel()
    {
        _startPanel.SetActive(true);

        _pausePanel.SetActive(false);
        _winPanel.SetActive(false);
        _losePanel.SetActive(false);
        _playPanel.SetActive(false);
    }

    // Запуск панели победы
    public void OnWinPanel()
    {
        _winPanel.SetActive(true);
        
        _pausePanel.SetActive(false);
        _startPanel.SetActive(false);
        _losePanel.SetActive(false);
        _playPanel.SetActive(false);
    }

    // Запуск панели поражения
    public void OnLosePanel()
    {
        _losePanel.SetActive(true);
        
        _pausePanel.SetActive(false);
        _startPanel.SetActive(false);
        _winPanel.SetActive(false);
        _playPanel.SetActive(false);
    }
}

