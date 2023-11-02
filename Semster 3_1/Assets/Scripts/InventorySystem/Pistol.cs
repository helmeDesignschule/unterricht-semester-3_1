using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : AmmoBasedWeapon
{
    [Header("Pistol")] 
    [SerializeField] 
    private Bullet bulletPrefab;
    
    protected override void ShootProjectiles()
    {
        Bullet newBullet = Instantiate(bulletPrefab, owner.GetPosition(), Quaternion.identity);
        newBullet.LaunchInDirection(owner, owner.GetLookDirection());
    }
}
