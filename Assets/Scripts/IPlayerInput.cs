using System;
using UnityEngine;

public interface IPlayerInput
{
    Vector2 Movement { get; }
    event Action<Vector2> OnAttack;
}