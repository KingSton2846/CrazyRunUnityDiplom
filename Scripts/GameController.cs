using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TriggerController[] _triggerController;
    private PanelController _panelController;
    private TimerController _timerController;
    private bool _isPause = true;
    private bool _isStart = true;
    private bool _isWin = false;
    private bool _isDeath = false;


    private void Start()
    {
        _panelController = GetComponent<PanelController>();
        _timerController = GetComponent<TimerController>();
    }

    private void Update()
    {
        bool isLose = _timerController.IsLose;

        CheckIsWin();
        CheckIsDeath();

        //Управление панелью паузы
        if(_isPause == true)
        {
            _panelController.OnPausaPanel();
            Time.timeScale = 0f;
        }
        else
        {
            _panelController.OnPlayPanel();
            _timerController.TimerProcess();
        }

        //Управление панелью проигрыша
        if(isLose == true || _isDeath == true)
        {
            _panelController.OnLosePanel();
            _isPause = true;
        }

        //Управление панелью выиграша
        if(_isWin == true)
        {
            //SavingProgress(); //Временно не работает
            _panelController.OnWinPanel();
            _isPause = true;
        }

        //Запуск стартовой панели
        if(_isStart == true)
        {
            _panelController.OnStartPanel();
        }
    }

    public void OnPause()
    {
        _isPause = true;
    }
    
    public void OnResume()
    {
        Time.timeScale = 1.0f;
        _isPause = false;
        _isStart = false;
    }

    //Проверка на победу за все мячики
    private void CheckIsWin()
    {
        int lengthTriggerContoller = _triggerController.Length;
        int countIsWin = 0;
        for(int i = 0; i < lengthTriggerContoller; i++)
        {
            if(_triggerController[i].IsWin == true)
            {
                countIsWin++;
            }
        }

        if (countIsWin == lengthTriggerContoller) 
        { 
            _isWin = true;
        }
        else
        {
            _isWin = false;
        }
    }

    //Проверка смерти хотя бы одного мячика
    private void CheckIsDeath()
    {
        int lengthTriggerContoller = _triggerController.Length;
        int countIsDeath = 0;
        for (int i = 0; i < lengthTriggerContoller; i++)
        {
            if (_triggerController[i].IsDeath == true)
            {
                countIsDeath++;
            }
        }

        if (countIsDeath > 0)
        {
            _isDeath = true;
        }
        else
        {
            _isDeath = false;
        }
    }
    public void SavingProgress()
    {
        int coutScene = SceneManager.GetActiveScene().buildIndex;
        int levelProgress = PlayerPrefs.GetInt("LevelProgress");
        if( levelProgress == coutScene ) 
        {
            levelProgress++;
            PlayerPrefs.SetInt("LevelProgress", levelProgress);
        }
    }
}
