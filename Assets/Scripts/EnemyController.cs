using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;

    public LayerMask groundLayer, playerlayer;

    Rigidbody enemy;
    public Vector3 walkpoint;

    bool walkpointset = false;

    public float walkPointRange;

    public bool playerInSightRange, playerInAttackRange;

    public float sightRange,attackRange;

    public GameObject projectile;

    public GameObject ProjectilePos;

    public float timeBetweenAttacks;

    bool alreadyAttacked;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerlayer);
        playerInSightRange = Physics.CheckSphere(transform.position, attackRange, playerlayer);

        if (playerInSightRange && playerInAttackRange) Attack();
    }

    public void Attack()
    {
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, ProjectilePos.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f,ForceMode.Impulse);
            rb.AddForce(transform.forward * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    public void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
