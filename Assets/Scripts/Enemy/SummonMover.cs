using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        transform.position += -Vector3.right * _speed * Time.deltaTime;
    }
}
