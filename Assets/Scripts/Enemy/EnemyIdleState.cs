using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private int currentTargetPoint = 0;

    public override void OnStateEnter(EnemyStateManager manager)
    {
        manager.agent.destination = manager.targetPoints[currentTargetPoint].position;
        Debug.Log("Enemy is Idling");
    }

    public override void OnStateExit(EnemyStateManager manager)
    {
        Debug.Log("No longer Idling");
    }

    public override void OnStateUpdate(EnemyStateManager manager)
    {
        // Idling Behavior
        if (manager.agent.remainingDistance < 0.1f)
        {
            currentTargetPoint++;
            if (currentTargetPoint >= manager.targetPoints.Length)
            {
                currentTargetPoint = 0;
            }
            manager.agent.destination = manager.targetPoints[currentTargetPoint].position;
        }

        // Exit condition
        if (Physics.SphereCast(manager.enemyEyes.position, manager.checkRadius, manager.transform.forward, out RaycastHit hit, manager.playerCheckDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player found!");
                manager.playerTransform = hit.transform;
                manager.agent.destination = manager.playerTransform.position;

                manager.ChangeState(manager.followState);
            }
        }
    }
}
