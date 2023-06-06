using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHp;
    private float _currentHp;

    [SerializeField] UnityEvent Die;
    [SerializeField] private UnityEvent<float> HealthTaken;

    public float HP
    {
        get => _currentHp;
        set
        {
            _currentHp = value;

            if (_currentHp <= 0)
            {
                Die?.Invoke();
            }
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(HP);
    }

    public void Start()
    {
        HP = _maxHp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Object>(out var entity))
        {
            HealthTaken?.Invoke(entity.HP);
        }
    }

    public void GetDamage(float damage)
    {
        HP -= damage;
    }

    public void AddHealth(float hp)
    {
        HP += hp;
    }
}
