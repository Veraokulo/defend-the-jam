using UnityEngine;

public class RangeHero : Hero
{
    private BowBase _bow;
    private IPlayerInput _playerInput;
    
    
    public override void Awake()
    {
        base.Awake();
        _playerInput = GetComponent<IPlayerInput>();
        _bow = GetComponent<BowBase>();
    }

    private void Start()
    {
        _playerInput.OnAttack += _bow.Shoot;
    }

    private void FixedUpdate()
    {
        Move(_playerInput.Movement);
    }

    private void Move(Vector2 playerInputMovement)
    {
        Rigidbody.velocity = playerInputMovement * speed;
        
        Animator.SetFloat(Speed, Rigidbody.velocity.magnitude);
        var scale = transform.localScale;
        if (Rigidbody.velocity.x < 0)
        {
            scale.x = -1;
        }
        else if (Rigidbody.velocity.x > 0)
        {
            scale.x = 1;
        }
        transform.localScale = scale;
    }
}