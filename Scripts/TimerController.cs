using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField] private Text _textTimer;
    [SerializeField] private float _timerValue = 30f;
    
    private bool _isLose = false;

    public bool IsLose => _isLose;

    public void TimerProcess()
    {
        _timerValue -= Time.deltaTime;
        int roundedValue = Mathf.RoundToInt( _timerValue );
        if ( _timerValue > 0)
        {
            _textTimer.text = roundedValue.ToString();
        }
        else
        {
            _textTimer.text = "0";
            _isLose = true;
        }
    }
}
