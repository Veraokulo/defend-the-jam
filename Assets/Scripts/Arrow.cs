using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : MonoBehaviour
{
    private const int Damage = 1;
    private const float Speed = 5f;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;
        
        var damageable = collision.GetComponent<IDamageable>();
        damageable?.TakeDamage(Damage);

        Destroy(gameObject);
    }
}