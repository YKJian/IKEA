using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

// здоровье, смерть, получение урона
public class Health : MonoBehaviour
{
    [SerializeField] private GameObject _deathScreen;

    [SerializeField] private float _maxHp;
    private float _currentHp;

    [SerializeField] UnityEvent Die;
    [SerializeField] private UnityEvent<float> DamageGot;

    [SerializeField] private UnityEvent<float> HpChanged;

    public float HP
    {
        get => _currentHp;
        set
        {
            _currentHp = value;
            HpChanged?.Invoke(_currentHp);

            if (_currentHp <= 0)
            {
                Die?.Invoke();
                if (TryGetComponent<Player>(out var player))
                {
                    _deathScreen.SetActive(true);
                }
            }
        }
    }

    public void Start()
    {
        HP = _maxHp;
    }

    /*private void FixedUpdate()
    {
        Debug.Log(HP);
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Attacker>(out var attacker))
        {
            DamageGot?.Invoke(attacker.Damage);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Attacker>(out var attacker))
        {
            DamageGot?.Invoke(attacker.Damage);
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
