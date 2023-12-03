using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 3;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Awake()
    {
        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(int value)
    {
        _health -= value;
        HealthChanged?.Invoke(_health);

        if(_health <= 0)
        {
            Die();
        }
    }

    public void Heal(int value)
    {
        _health += value;
        HealthChanged?.Invoke(_health);
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
