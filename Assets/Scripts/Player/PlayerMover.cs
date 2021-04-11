using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _oneBoostTime;

    private Player _player;
    private int _speedFactor = 1;
    private int _timeFactor = 0;
    private float _currentTime = 0;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.BoosterRaised += Boost;
    }

    private void OnDisable()
    {
        _player.BoosterRaised -= Boost;
    }

    private void Update()
    {
        TryReduceSpeed();
        Move(GetDirection());
    }

    private void Boost()
    {
        _speedFactor++;
        _timeFactor++;
    }
    private void UnBoost()
    {
        _speedFactor--;
        _timeFactor--;
    }

    public void TryReduceSpeed()
    {
        if (_timeFactor <= 0) return;

        _currentTime += Time.deltaTime;
        if (_currentTime >= _oneBoostTime)
        {
            UnBoost();
            _currentTime = 0;
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
