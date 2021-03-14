using System;
using UnityEngine;

public class PlayerInput: MonoBehaviour, IPlayerInput
{
    public Vector2 Movement => new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")).normalized;
    public event Action<Vector2> OnAttack;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            OnAttack?.Invoke((Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position).normalized);
        }
    }
}