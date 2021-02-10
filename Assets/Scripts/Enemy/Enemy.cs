using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    public UnityAction Died;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Die();
        }
    }

    private void Die()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}
