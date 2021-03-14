using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    public event UnityAction Died;

    public void Die()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}
