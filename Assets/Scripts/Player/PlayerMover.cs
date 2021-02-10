using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _timer;
    [SerializeField] private float _time;

    private float _currentTime;

    private void Update()
    {
        ReduceSpeed();
        Move(GetDirection());
    }

    public void ReduceSpeed()
    {
        if (_timer)
        {
            _currentTime += Time.deltaTime;

            if(_currentTime >= _time)
            {
                _timer = false;
                _speed /= 2;
                _currentTime = 0;
            }
        }
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private Vector3 GetDirection()
    {
        float directionHor = Input.GetAxis("Horizontal");
        float directionVert = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(directionHor, directionVert);

        return direction;
    }

}
