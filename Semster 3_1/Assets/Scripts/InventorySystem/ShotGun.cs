using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : AmmoBasedWeapon
{
    [Header("ShotGun")]
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int bulletsPerShot = 12;
    [Range(0, 1)]
    [SerializeField] private float spread = .25f;
    
    protected override void ShootProjectiles()
    {
        for (int index = 0; index < bulletsPerShot; index++)
        {
            Vector2 bulletDirection = Random.insideUnitCircle;
            bulletDirection.Normalize();

            Vector2 targetDirection = owner.GetLookDirection();
            bulletDirection = Vector3.Slerp(bulletDirection, targetDirection, 1.0f - spread);

            Bullet newBullet = Instantiate(bulletPrefab, owner.GetPosition(), Quaternion.identity);
            newBullet.LaunchInDirection(owner, bulletDirection);
        }
    }
}
