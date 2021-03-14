using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class IceArrow : MonoBehaviour
{
    private const float Speed = 5f;
    [SerializeField] private const float FreezePower = 0.5f;
    [SerializeField] private const float FreezeDuration = 1f;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;

        var freezable = collision.GetComponent<IFreezable>();
        freezable?.Freeze(FreezePower, FreezeDuration);

        Destroy(gameObject);
    }
}