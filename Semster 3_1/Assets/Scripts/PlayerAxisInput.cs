using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxisInput : MonoBehaviour
{
    [SerializeField] private PhysicsPawn pawn;
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private Bullet bulletPrefab;

    private Vector2 moveDirection;

    private void Awake()
    {
        GameState.SetState(GameState.State.InGame);
        PlayerManager.playerPawn = pawn;
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

        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    private void FixedUpdate()
    {
        pawn.MoveByForce(moveDirection * moveSpeed);
    }

    private void ShootBullet()
    {
        Bullet newBullet = Instantiate(bulletPrefab, pawn.GetPosition(), Quaternion.identity);

        Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        newBullet.Launch(pawn, targetPosition);
    }
}
