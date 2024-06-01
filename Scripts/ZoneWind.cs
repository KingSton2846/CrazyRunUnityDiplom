using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneWind : MonoBehaviour
{
    [SerializeField] private float _pushForce = 10f; // Сила толчка
    [SerializeField] private float _timer = 3f;
    [SerializeField] private ParticleSystem[] _windPartical;
    private BoxCollider _boxcollider;

    void Start()
    {
        _boxcollider = GetComponent<BoxCollider>();
        StartCoroutine(ActivateObjectWithDelay(_timer));
    }

    private void OnTriggerStay(Collider other)
    {
        // Проверяем, если другой объект имеет Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Применяем силу толчка к объекту вперед
            rb.AddForce(transform.forward * _pushForce, ForceMode.Force);
        }
    }

    IEnumerator ActivateObjectWithDelay(float timer)
    {
        while (true)
        {
            foreach (var obj in _windPartical)
            {
                obj.Stop();
            }
            //_windPartical.Stop();
            _boxcollider.enabled = false;

            yield return new WaitForSeconds(timer);

            foreach (var obj in _windPartical)
            {
                obj.Play();
            }
            _boxcollider.enabled = true;

            yield return new WaitForSeconds(timer);
        }
    }
}
