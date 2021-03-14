using System.Linq;
using UnityEngine;

public class HomingArrow : MonoBehaviour
{
    private GameObject _currentTarget;
    private Rigidbody2D _rb;
    private const int Damage = 1;
    private const float Speed = 5f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;

        var damageable = collision.GetComponent<IDamageable>();
        damageable?.TakeDamage(Damage);

        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (_currentTarget == null || !_currentTarget.activeSelf)
        {
            if (Enemy.AllEnabledEnemies.Count > 0)
            {
                _currentTarget = Enemy.AllEnabledEnemies
                    .OrderBy(e => (e.transform.position - transform.position).sqrMagnitude).First().gameObject;
            }
        }

        if (_currentTarget != null && _currentTarget.activeSelf)
        {
            var direction = (_currentTarget.transform.position - transform.position).normalized;
            var rotateAmount = Vector3.Cross(direction, transform.up).z;
            _rb.angularVelocity = -rotateAmount * 500f;
            _rb.velocity = transform.up * Speed;
        }
    }
}