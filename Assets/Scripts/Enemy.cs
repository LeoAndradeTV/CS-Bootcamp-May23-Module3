using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] targetPoints;
    [SerializeField] private Transform enemyEyes;
    [SerializeField] private float playerCheckDistance;
    [SerializeField] private float checkRadius = 0.4f;

    private NavMeshAgent agent;
    private int currentTargetPoint;

    private bool isIdle = true;
    private bool isPlayerFound;
    private bool isCloseToPlayer;

    private Transform playerTransform;


    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.destination = targetPoints[currentTargetPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIdle)
        {
            Idle();
        } else if (isPlayerFound)
        {
            if (isCloseToPlayer)
            {
                AttackPlayer();
            } else
            {
                FollowPlayer();
            }
        }
    }

    private void Idle()
    {
        if (agent.remainingDistance < 0.1f)
        {
            currentTargetPoint++;
            if (currentTargetPoint >= targetPoints.Length)
            {
                currentTargetPoint = 0;
            }
            agent.destination = targetPoints[currentTargetPoint].position;
        }

        if (Physics.SphereCast(enemyEyes.position, checkRadius, transform.forward, out RaycastHit hit, playerCheckDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player found!");
                isIdle = false;
                isPlayerFound = true;

                // Set player to follow
                playerTransform = hit.transform;
                agent.destination = playerTransform.position;
            }
        }
    }

    private void FollowPlayer()
    {
        if (playerTransform != null)
        {
            if (Vector3.Distance(transform.position, playerTransform.position) > 10)
            {
                isPlayerFound = false;
                isIdle = true;
            }

            if (Vector3.Distance(transform.position, playerTransform.position) < 2)
            {
                isCloseToPlayer = true;
            } else
            {
                isCloseToPlayer = false;
            }

            agent.destination = playerTransform.position;
        } else
        {
            isPlayerFound = false;
            isIdle = true;
            isCloseToPlayer = false;
        }
    }

    private void AttackPlayer()
    {
        Debug.Log("Attacking Player!");
        if (Vector3.Distance(transform.position, playerTransform.position) > 2)
        {
            isCloseToPlayer = false;
        }
    }
}
