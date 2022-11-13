using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyExampleAI : Enemy
{
    public GameObject movementTarget;
    private NavMeshAgent navMeshAgent;
    [Tooltip("The object containing the model. Used in despawn scaling.")]
    public GameObject model;
    public ResourcePickup resourcePickupPrefab;
    private float despawnTimer = 3;
    private float despawnMod = 0;

    private bool hasDroppedPickup = false;
    
    public float attackCooldown = 0.5f;
    private float attackCurrent = 0.0f;

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
            if (attackCurrent > 0) attackCurrent -= Time.deltaTime;
        } else 
        {
            DisableEnemy();
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
        if (c.gameObject.tag == "PlayerProjectile")
        {
            // NB! Damage is dealt in projectile scripts so physics would work properly
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "PlayerProjectile")
        {
            // NB! Damage is dealt in projectile scripts so physics would work properly
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackCurrent <= 0)
            {
                Debug.Log("Attacking player!");
                Events.UseResources(damageRed, damageGreen, damageBlue);
                attackCurrent = attackCooldown;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackCurrent <= 0)
            {
                Debug.Log("Attacking player!");
                Events.UseResources(damageRed, damageGreen, damageBlue);
                attackCurrent = attackCooldown;
            }
        }
    }

    private void DisableEnemy()
    {
        GetComponentInChildren<Rigidbody>().isKinematic = false; // Also checked to false in projectile hit code, enables external forces to affect the enemy
        navMeshAgent.enabled = false;
        gameObject.tag = "Untagged";
    }

    override public void takeDamage(int red, int green, int blue)
    {
        healthRed -= red;
        healthGreen -= green;
        healthBlue -= blue;
        if (healthRed <= 0 && healthGreen <= 0 && healthBlue <= 0)
        {
            DisableEnemy();
            if (!hasDroppedPickup)
            {
                spawnPickup();
                hasDroppedPickup = true;
            }
        }
    }

    public void spawnPickup()
    {
        ResourcePickup res;
        res = GameObject.Instantiate<ResourcePickup>(resourcePickupPrefab,
            model.transform.position + new Vector3(Random.Range(-1, 1), 0.5f * Random.Range(-1, 1), Random.Range(-1, 1)),
            model.transform.rotation);
        res.resourceRed = worthRed;
        res.fx.startColor = new Color(0.85f, 0.15f, 0.15f);

        res = GameObject.Instantiate<ResourcePickup>(resourcePickupPrefab,
            model.transform.position + new Vector3(Random.Range(-1, 1), 0.5f * Random.Range(-1, 1), Random.Range(-1, 1)),
            model.transform.rotation);
        res.resourceGreen = worthGreen;
        res.fx.startColor = new Color(0.15f, 0.85f, 0.15f);

        res = GameObject.Instantiate<ResourcePickup>(resourcePickupPrefab,
            model.transform.position + new Vector3(Random.Range(-1, 1), 0.5f * Random.Range(-1, 1), Random.Range(-1, 1)),
            model.transform.rotation);
        res.resourceBlue = worthBlue;
        res.fx.startColor = new Color(0.15f, 0.15f, 0.85f);
    }
}
