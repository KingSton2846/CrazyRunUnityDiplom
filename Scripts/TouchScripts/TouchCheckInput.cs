using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCheckInput : MonoBehaviour
{

    // Возвращение delta позиции первого касания
    public Vector2 GetTouchDeltaPosition()
    {
        if(Input.touchCount > 0)
        {
            return Input.GetTouch(0).deltaPosition;
        }

        return Vector2.zero;
    }

    // Проверка на наличие касания
    public bool IsThereTouchOnScreen()
    {
        if (Input.touchCount > 0) return true;
        else return false;
    }
}
