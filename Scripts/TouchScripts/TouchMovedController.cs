using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]

public class TouchMovedController : MonoBehaviour
{
    [SerializeField] TouchCheckInput _touchCheckInput;
    [SerializeField] private Rigidbody _ball;
    [SerializeField] private float _powerJump;
    [SerializeField] private float _speedRotation = 2f;
    [SerializeField] private float _limitRotation = 10f;

    private Transform _transformPlatform;
    private Rigidbody _platformaRotation;

    private void Start()
    {
        _platformaRotation = GetComponent<Rigidbody>();
        _transformPlatform = GetComponent<Transform>();
    }

    private void Update()
    {
        RotationPlatform();
        //_transformPlatform.position = Vector3.zero;
        //BalancePlatform();
        if(_ball != null && _powerJump != 0)
        {
            JumpBall();
        }
    }

    // Поддержание платформы в равновесии
    private void BalancePlatform()
    {
        Vector3 rotationPlatform = _transformPlatform.eulerAngles;
        float negatifLimit = 360 - _limitRotation;
        
        //Проверка вращения лиита по оси x

        if (rotationPlatform.x > _limitRotation && rotationPlatform.x < 180) 
        {
            rotationPlatform.x = _limitRotation;
            
        }
        if (rotationPlatform.x < negatifLimit && rotationPlatform.x > 180) 
        {
            rotationPlatform.x = -_limitRotation;
        }

        //Проверка вращения лимита по оси z

        if (rotationPlatform.z > _limitRotation && rotationPlatform.z < 180) 
        {
            rotationPlatform.z = _limitRotation;
        }
        if (rotationPlatform.z < negatifLimit && rotationPlatform.z > 180) 
        {
            rotationPlatform.z = -_limitRotation;
        }

        _transformPlatform.rotation = Quaternion.Lerp(_transformPlatform.rotation, Quaternion.Euler(rotationPlatform), 2f);
        _transformPlatform.position = Vector3.zero;
        _transformPlatform.rotation = Quaternion.Lerp(_transformPlatform.rotation, Quaternion.Euler(_transformPlatform.eulerAngles.x, 0f, _transformPlatform.eulerAngles.z), 2f);
    }

    // Вращение платформы
    private void RotationPlatform()
    {
        if (_touchCheckInput.IsThereTouchOnScreen() == true)
        {
            
            Vector2 tempDeltaPosition = _touchCheckInput.GetTouchDeltaPosition();
            _platformaRotation.AddTorque(tempDeltaPosition.y * _speedRotation, 0f, -tempDeltaPosition.x * _speedRotation);

            Vector3 movement = new Vector3(tempDeltaPosition.x, 0f, tempDeltaPosition.y);
            _ball.AddForce(movement * Time.deltaTime * _speedRotation);
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
