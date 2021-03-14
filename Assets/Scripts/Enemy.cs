using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IFreezable, IFlammable
{
    public static List<Enemy> AllEnabledEnemies = new List<Enemy>();
    private Rigidbody2D _rb;
    public float speed = 3f;
    public AudioClip dieClip;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var direction = (Jam.Instance.gameObject.transform.position - transform.position).normalized;
        _rb.velocity = (direction * speed);

        var scale = transform.localScale;
        if (_rb.velocity.x < 0)
        {
            scale.x = -1;
        }
        else if (_rb.velocity.x > 0)
        {
            scale.x = 1;
        }

        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != Jam.Instance.gameObject) return;
        
        Destroy(gameObject);
        Jam.Instance.TakeDamage(1);
    }

    public void TakeDamage(int damage)
    {
        GameManager.Instance.AddScore(1);
        AudioSource.PlayClipAtPoint(dieClip, transform.position);
        Destroy(gameObject);
    }

    public void Freeze(float freezePower, float duration)
    {
        StartCoroutine(FreezeCoroutine(freezePower, duration));
    }

    private IEnumerator FreezeCoroutine(float freezePower, float duration)
    {
        speed *= freezePower;
        yield return new WaitForSeconds(duration);
        speed /= freezePower;
    }

    public void Ignite(int damage, float duration)
    {
        StartCoroutine(IgniteCoroutine(damage, duration));
    }

    private IEnumerator IgniteCoroutine(int damage, float duration)
    {
        var damageDone = 0;
        var delayBetweenTicks = duration / damage;
        while (damageDone != damage)
        {
            TakeDamage(1);
            damageDone++;
            yield return new WaitForSeconds(delayBetweenTicks);
        }
    }

    private void OnEnable()
    {
        AllEnabledEnemies.Add(this);
    }

    private void OnDisable()
    {
        AllEnabledEnemies.Remove(this);
    }
}