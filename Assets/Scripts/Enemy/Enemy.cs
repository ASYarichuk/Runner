using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private int _damage = 1;

    private void Start()
    {
        _spawner = GetComponentInParent<Spawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_damage);
        }

        gameObject.SetActive(false);
        _spawner.AddNewSummon(GetComponent<GameObject>());
    }
}
