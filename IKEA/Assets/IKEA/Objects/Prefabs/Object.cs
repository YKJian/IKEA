using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private ObjectSO _objectSO;

    public float HP => _objectSO.healing;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Health>(out var a))
        {
            Destroy(gameObject);
        }
    }
}
