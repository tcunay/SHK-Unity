using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class Player : MonoBehaviour
{
    public event UnityAction BoosterRaised;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Booster booster))
        {
            BoosterRaised?.Invoke();
        }

        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
        }
    }
}
