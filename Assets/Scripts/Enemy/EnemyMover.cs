using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Start()
    {
        TryMoveNext();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        TryMoveNext();
    }

    private void TryMoveNext()
    {
        if (transform.position == _target)
            _target = Random.insideUnitCircle * _radius;
    }
}
