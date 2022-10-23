using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyExampleAI : MonoBehaviour
{
    public GameObject movementTarget;
    private NavMeshAgent navMeshAgent;
    [Tooltip("The object containing the model. Used in despawn scaling.")]
    public GameObject model;
    private float despawnTimer = 3;
    private float despawnMod = 0;


    private void Awake()
    {
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.isActiveAndEnabled)
        {
            navMeshAgent.destination = movementTarget.transform.position;
        } else
        {
            if (despawnTimer <= 0)
            {
                model.transform.localScale -= despawnMod * new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
                despawnMod += Time.deltaTime;
                if (model.transform.localScale.x <= 0.05f)
                {
                    GameObject.Destroy(gameObject);
                }
            } else
            {
                despawnTimer -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "PlayerProjectile" || c.gameObject.tag == "Player")
        {
            DisableEnemy();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "PlayerProjectile" || other.tag == "Player")
        {
            DisableEnemy();
            
        }
    }

    private void DisableEnemy()
    {
        GetComponentInChildren<Rigidbody>().isKinematic = false; // Also checked to false in projectile hit code, enables external forces to affect the enemy
        navMeshAgent.enabled = false;
        gameObject.tag = "Untagged";
    }
}
