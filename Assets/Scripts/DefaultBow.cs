using UnityEngine;
using UnityEngine.Serialization;

public class DefaultBow : BowBase
{
    public override void Shoot(Vector2 direction)
    {
        if (arrowSupply > 0)
        {
            arrowSupply--;
            Instantiate(arrow, transform.position,
                Quaternion.Euler(new Vector3(0, 0, (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg)-90)));
        }
        else
        {
            print("Out of ammo");
        }
    }
}