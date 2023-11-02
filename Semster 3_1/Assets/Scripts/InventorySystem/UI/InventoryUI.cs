using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private RectTransform entryParent;
    [SerializeField] private InventoryUIEntry entryPrefab;

    private List<InventoryUIEntry> entries = new List<InventoryUIEntry>();
    
    private void Start()
    {
        PlayerManager.playerInventory.OnWeaponRegistered += OnWeaponRegistered;
        PlayerManager.playerInventory.OnWeaponDeregistered += OnWeaponDeregistered;
        PlayerManager.playerInventory.OnNewWeaponEquipped += OnNewWeaponEquipped;

        List<Weapon> weapons = PlayerManager.playerInventory.weapons;
        for (int index = 0; index < weapons.Count; index++)
        {
            OnWeaponRegistered(weapons[index]);
        }
        OnNewWeaponEquipped(PlayerManager.playerInventory.GetActiveWeapon());
    }

    private void OnDestroy()
    {
        if (PlayerManager.playerInventory == null)
            return;
        PlayerManager.playerInventory.OnWeaponRegistered -= OnWeaponRegistered;
        PlayerManager.playerInventory.OnWeaponDeregistered -= OnWeaponDeregistered;
        PlayerManager.playerInventory.OnNewWeaponEquipped -= OnNewWeaponEquipped;
    }

    private void OnWeaponRegistered(Weapon weapon)
    {
        InventoryUIEntry newEntry = Instantiate(entryPrefab, entryParent);
        newEntry.Initialize(weapon);
        entries.Add(newEntry);
    }

    private void OnWeaponDeregistered(Weapon weapon)
    {
        for (int index = 0; index < entries.Count; index++)
        {
            if (entries[index].weapon == weapon)
            {
                Destroy(entries[index].gameObject);
                entries.RemoveAt(index);
                return;
            }
        }
    }

    private void OnNewWeaponEquipped(Weapon weapon)
    {
        for (int index = 0; index < entries.Count; index++)
        {
            entries[index].UpdateSelectionMarker(weapon);
        }
    }
}
