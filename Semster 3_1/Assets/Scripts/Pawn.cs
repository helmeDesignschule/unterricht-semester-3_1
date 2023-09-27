using System;
using NavMeshPlus.Extensions;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AgentRotate2d))]
[RequireComponent(typeof(AgentOverride2d))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Pawn : PawnBase
{
    private NavMeshAgent agent;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveByDistance(Vector2 movement)
    {
        CancelMovement();
        rigidbody.AddForce(movement, ForceMode2D.Force);
    }

    public void MoveToPosition(Vector2 position)
    {
        agent.isStopped = false;
        agent.ResetPath();
        agent.SetDestination(position);
    }

    public void CancelMovement()
    {
        agent.isStopped = true;
    }

}
