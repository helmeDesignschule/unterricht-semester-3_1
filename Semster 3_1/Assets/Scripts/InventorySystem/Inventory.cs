using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Weapon> weapons;
    public PhysicsPawn pawn;

    public void RegisterNewWeapon(Weapon weapon)
    {
        if (weapons.Contains(weapon))
            return;
        
        weapons.Add(weapon);
        weapon.Initialize(pawn);
    }

    public void DeregisterWeapon(Weapon weapon)
    {
        if (!weapons.Contains(weapon))
            return;
        
        weapons.Remove(weapon);
    }

    public Weapon GetActiveWeapon()
    {
        if (weapons.Count == 0)
            return null;

        return weapons[0];
    }
}
