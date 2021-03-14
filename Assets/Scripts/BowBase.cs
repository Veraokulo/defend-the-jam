using UnityEngine;
using UnityEngine.Serialization;

public abstract class BowBase : MonoBehaviour
{
    public GameObject arrow;
    public int arrowSupply = 20;
    public abstract void Shoot(Vector2 direction);
}