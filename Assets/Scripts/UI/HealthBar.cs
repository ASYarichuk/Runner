using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartPrefab;

    private List<Heart> _hearts = new();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_hearts.Count < value)
        {
            int createHealth = value - _hearts.Count;

            for (int i = 0; i < createHealth; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value)
        {
            int deleteHealth = _hearts.Count - value;

            for (int i = 0; i < deleteHealth; i++)
            {
                DestoyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void DestoyHeart(Heart heart)
    {
        heart.ToEmpty();
        _hearts.Remove(heart);
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartPrefab, transform);
        _hearts.Add(newHeart);
        newHeart.ToFill();
    }
}
