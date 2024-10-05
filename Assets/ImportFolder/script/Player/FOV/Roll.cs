using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Roll : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    private float desiredAngle;
    public void AimWeapon(Vector2 pointPos)
    {
        Aim(pointPos, weapon.transform);
    }
    public void AimCharactor(Vector2 pointPos)
    {
        Aim(pointPos, transform);
    }
    private void Aim(Vector2 pointPos, Transform transform)
    {
        Vector2 aimDir = (Vector3)pointPos - transform.position;
        desiredAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(desiredAngle - 90, Vector3.forward);
    }
}
