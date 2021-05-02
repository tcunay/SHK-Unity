using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour, IBooster
{
    public event UnityAction Dying;

    public void Die()
    {
        Dying?.Invoke();
        Destroy(gameObject);
    }
}
