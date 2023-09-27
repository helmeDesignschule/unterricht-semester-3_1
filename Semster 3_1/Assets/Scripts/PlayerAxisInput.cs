using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxisInput : MonoBehaviour
{
    [SerializeField] private Pawn pawn;
    [SerializeField] private float moveSpeed = 7;

    private Vector2 moveDirection;

    private void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");
        moveDirection.Normalize();
    }

    private void FixedUpdate()
    {
        pawn.MoveByDistance(moveDirection * moveSpeed);
    }
}
