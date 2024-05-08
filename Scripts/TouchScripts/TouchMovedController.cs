using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]

public class TouchMovedController : MonoBehaviour
{
    [SerializeField] Joystick _joystick;
    [SerializeField] private Rigidbody _ball;
    [SerializeField] private float _powerJump;
    [SerializeField] private float _speed;

    private void Start()
    {
        _ball = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMoved();
        if(_powerJump != 0)
        {
            JumpBall();
        }
    }

    // Вращение платформы
    private void PlayerMoved()
    {
        float directionX = _joystick.Horizontal;
        float directionY = _joystick.Vertical;

        Vector3 movement = new Vector3(directionX, 0f, directionY);

        _ball.AddForce(movement * Time.deltaTime * _speed);
    }

    //Прыжок мяча по двойному нажатию по экрану
    private void JumpBall()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Input.touches[0].tapCount == 2)
            {
                _ball.AddForce(Vector3.up * _powerJump, ForceMode.Impulse);
            }
        }
    }
}
