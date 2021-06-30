using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Start()
    {
        MoveNext();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (IsRiched() == true)
            MoveNext();
        else
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    private bool IsRiched()
    {
        return transform.position == _target;
    }

    private void MoveNext()
    {
        _target = Random.insideUnitCircle * _radius;
    }
}
