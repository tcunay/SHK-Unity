using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _oneBoostTime;

    private const string _horizontalAxisName = "Horizontal";
    private const string _verticalAxisName = "Vertical";

    private int _speedFactor = 1;

    private void Update()
    {
        Move(GetDirection());
    }

    public void Boost()
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
        float directionX = Input.GetAxis(_horizontalAxisName);
        float directionY = Input.GetAxis(_verticalAxisName);

        return new Vector3(directionX, directionY);
    }
}
