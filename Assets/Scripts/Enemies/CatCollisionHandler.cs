using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CatMover))]
public class CatCollisionHandler : MonoBehaviour
{
    private CatMover _mover;

    private void Start()
    {
        _mover = GetComponent<CatMover>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wall wall))
        {
            _mover.ChangeDirection();
        }
    }
}
