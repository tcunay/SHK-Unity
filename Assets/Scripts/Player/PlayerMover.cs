using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _oneBoostTime;

    private Player _player;
    private int _speedFactor = 1;

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
        Move(GetDirection());
    }

    private void Boost()
    {
        StartCoroutine(BoostSpeed());
    }

    private IEnumerator BoostSpeed()
    {
        _speedFactor++;
        yield return new WaitForSeconds(_oneBoostTime);
        _speedFactor--;
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
