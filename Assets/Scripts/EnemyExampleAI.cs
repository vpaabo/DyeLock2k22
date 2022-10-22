using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyExampleAI : MonoBehaviour
{
    public GameObject movementTarget;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.isActiveAndEnabled)
        {
            navMeshAgent.destination = movementTarget.transform.position;
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "PlayerProjectile" || c.gameObject.tag == "Player")
        {
            Debug.Log("Enemy hit!");
            GetComponent<Rigidbody>().isKinematic = false; // Also checked to false in projectile hit code, enables external forces to affect the enemy
            navMeshAgent.enabled = false;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "PlayerProjectile" || other.tag == "Player")
        {
            Debug.Log("Enemy hit!");
            GetComponent<Rigidbody>().isKinematic = false; // Also checked to false in projectile hit code, enables external forces to affect the enemy
            navMeshAgent.enabled = false;
        }
    }
}
