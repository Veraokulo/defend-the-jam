using UnityEngine;

public class MultishotBow : BowBase
{
    [SerializeField] private int arrowsPerShot = 3;
    [SerializeField] private float windowAngle = 90f;

    public override void Shoot(Vector2 direction)
    {
        if (arrowSupply >= arrowsPerShot)
        {
            arrowSupply -= arrowsPerShot;
            var firstArrowAngleDeviation = windowAngle / 2;
            var zRotation = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - firstArrowAngleDeviation - 90;
            for (var arrowIndex = 0; arrowIndex < arrowsPerShot; ++arrowIndex)
            {
                var rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
                Instantiate(arrow, transform.position, rotation);
                zRotation += windowAngle / arrowsPerShot;
            }
        }
        else
        {
            print("Out of ammo");
        }
    }
}