using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeHero : Hero
{
    private Animator animator;

    public override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    protected void Move(InputAction.CallbackContext ctx)
    {
        Rigidbody.velocity = ctx.ReadValue<Vector2>() * speed;
    }

    public void Fire(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            AudioSource.Play();
            animator.SetTrigger("Attack");
            var q = new List<Collider2D>();
            GetComponent<Collider2D>().GetContacts(q);
            foreach (var col in q)
            {
                if (col.gameObject.CompareTag("Enemy"))
                {
                    col.gameObject.GetComponent<Enemy>().TakeDamage(1);
                }
            }
        }
    }
}
