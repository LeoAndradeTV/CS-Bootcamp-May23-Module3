using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    [Header("State Machine")]
    public EnemyIdleState idleState = new EnemyIdleState();
    public EnemyFollowState followState = new EnemyFollowState();
    public EnemyAttackState attackState = new EnemyAttackState();
    public EnemyState currentState;

    [Header("Reference Variables")]
    public Transform[] targetPoints;
    public Transform enemyEyes;
    public float playerCheckDistance;
    public float checkRadius = 0.4f;

    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = idleState;
        currentState.OnStateEnter(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnStateUpdate(this);
    }

    public void ChangeState(EnemyState newState)
    {
        currentState.OnStateExit(this);
        currentState = newState;
        currentState.OnStateEnter(this);
    }
}
