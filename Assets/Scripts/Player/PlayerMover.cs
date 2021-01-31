using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _timer;
    [SerializeField] private float _time;

    private Vector3 _direction;
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
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            _direction = new Vector3(-1, 1);
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            _direction = new Vector3(1, 1);
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            _direction = new Vector3(-1, -1);
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            _direction = new Vector3(1, -1);
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))
            _direction = new Vector3(0, 0);
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            _direction = new Vector3(0, 0);
        else if (Input.GetKey(KeyCode.W))
            _direction = new Vector3(0, 1);
        else if (Input.GetKey(KeyCode.S))
            _direction = new Vector3(0, -1);
        else if (Input.GetKey(KeyCode.A))
            _direction = new Vector3(-1, 0);
        else if (Input.GetKey(KeyCode.D))
            _direction = new Vector3(1, 0);
        else
            _direction = new Vector3(0, 0);

        return _direction;
    }

}
