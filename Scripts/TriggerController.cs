using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private bool _isWin = false;
    private bool _isDeath = false;

    public bool IsWin => _isWin;
    public bool IsDeath => _isDeath;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            _isWin = true;
        }

        if (other.gameObject.CompareTag("Death"))
        {
            _isDeath = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            _isWin = false;
        }
    }
}
