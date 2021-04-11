using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    public event UnityAction Dying;

    public void Die()
    {
        Dying?.Invoke();
        Destroy(gameObject);
    }
}
