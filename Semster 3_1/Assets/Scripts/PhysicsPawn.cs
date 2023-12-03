using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PhysicsPawn : PawnBase
{
    [SerializeField] private PlayerAnimator animator;
    private Rigidbody2D rigidbody;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveByForce(Vector2 movement)
    {
        rigidbody.AddForce(movement, ForceMode2D.Force);
        animator.SetLookDirection(movement);
    }

    private void FixedUpdate()
    {
        animator.SetSpeed(rigidbody.velocity.magnitude);
    }
}
