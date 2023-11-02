using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class PlayerAxisInput : MonoBehaviour
{
    [SerializeField] private PhysicsPawn pawn;
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private Inventory inventory;
    
    private Vector2 moveDirection;

    private void Awake()
    {
        GameState.SetState(GameState.State.InGame);
        PlayerManager.playerPawn = pawn;
        PlayerManager.playerInventory = inventory;
        inventory.pawn = pawn;
        Debug.Log("Player was initialized");
    }

    private void Update()
    {
        if (pawn == null)
        {
            GameState.SetState(GameState.State.GameOver);
            enabled = false;
            return;
        }
        
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");
        moveDirection.Normalize();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pawnToMouse = mousePosition - pawn.GetPosition();
        pawn.SetLookDirection(pawnToMouse);

        Weapon equippedWeapon = inventory.GetActiveWeapon();
        if (equippedWeapon != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                equippedWeapon.StartAttacking();
            }

            if (Input.GetMouseButtonUp(0))
            {
                equippedWeapon.StopAttacking();
            }
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            inventory.SwitchToNextWeapon();
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            inventory.SwitchToPreviousWeapon();
        }
    }

    private void FixedUpdate()
    {
        pawn.MoveByForce(moveDirection * moveSpeed);
    }
}
