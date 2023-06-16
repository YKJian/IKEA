using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// хиллиться может только гг
public class Healingable : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> HealthTaken;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Object>(out var entity))
        {
            HealthTaken?.Invoke(entity.HP);
        }
    }
}
