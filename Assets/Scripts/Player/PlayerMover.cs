using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _time;

    private Player _player;
    private int _speedFactor = 1;
    private float _currentTime = 0;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.EnemyKilled += BoostSpeed;
    }
    private void OnDisable()
    {
        _player.EnemyKilled -= BoostSpeed;
    }

    private void Update()
    {
        ReduceSpeed();
        Move(GetDirection());
    }

    public void BoostSpeed()
    {
        _speedFactor++;
    }

    public void ReduceSpeed()
    {
        if (_speedFactor > 1)
        {
            _currentTime += Time.deltaTime;

            if(_currentTime >= _time)
            {
                _speedFactor--;
                _currentTime = 0;
            }
        }
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * _speed * _speedFactor * Time.deltaTime);
    }

    private Vector3 GetDirection()
    {
        float directionX = Input.GetAxis("Horizontal");
        float directionY = Input.GetAxis("Vertical");

        return new Vector3(directionX, directionY);
    }
}
