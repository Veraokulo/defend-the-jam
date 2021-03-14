using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public abstract class Hero : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;

    protected Rigidbody2D Rigidbody;
    protected Animator Animator;
    protected AudioSource AudioSource;
    protected IPlayerInput PlayerInput;
    protected static readonly int Speed = Animator.StringToHash("Speed");

    public virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();
        PlayerInput = GetComponent<PlayerInput>();
    }
}
