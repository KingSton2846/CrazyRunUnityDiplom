using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]

public class TouchMovedController : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Transform _camera;
    [SerializeField] private Rigidbody _ball;
    [SerializeField] private float _powerJump;
    [SerializeField] private float _speed;
    [SerializeField] private float _smooth;

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

        Vector3 forward = _camera.forward;
        Vector3 right = _camera.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        
        Vector3 movement = forward * directionY + right * directionX;

        _ball.AddForce(movement * Time.deltaTime * _speed);
        if(Input.touchCount > 0 )
        {
            Vector3 direction = this.transform.rotation.eulerAngles;
            direction.y += directionX * 75f;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(direction), _smooth);
        }
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
