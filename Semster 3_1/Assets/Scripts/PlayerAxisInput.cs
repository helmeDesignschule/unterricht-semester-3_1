using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAxisInput : MonoBehaviour
{
    [SerializeField] private PhysicsPawn pawn;
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private Bullet bulletPrefab;

    private Vector2 moveDirection;

    private void Awake()
    {
        PlayerManager.playerPawn = pawn;
    }

    private void Update()
    {
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
