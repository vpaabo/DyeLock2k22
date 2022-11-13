using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProjectileFireball : Spell
{
    
    public ParticleSystem explosionFX;

    
    private float radius = 3.0f;
    private float power = 150f;

    
    void OnCollisionEnter (Collision c)
    {
        if (c.gameObject.tag != "PlayerProjectile" && c.gameObject.tag != "Player")
        {
            Vector3 explosionPos = transform.position;
            GameObject.Instantiate<ParticleSystem>(explosionFX, explosionPos, transform.rotation);
            Physics.IgnoreCollision(shooter, GetComponent<Collider>(), false);

            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.attachedRigidbody;

                if (rb != null)
                {
                    if (hit.gameObject.tag == "Enemy")
                    {
                        rb.gameObject.GetComponent<Enemy>().takeDamage(damageRed, damageGreen, damageBlue);
                        // Leftovers from when shots were instakill
                        //rb.isKinematic = false; // Enables enemy to be affected by external forces
                        //hit.gameObject.GetComponent<NavMeshAgent>().enabled = false; // Disables enemy movement AI if in explosion sphere
                    }

                    if (hit.gameObject.tag == "Player")
                    {
                        Events.AddForceToPlayer(hit.transform.position - explosionPos, power / 1000);
                    } else
                    {
                        rb.AddExplosionForce(power, explosionPos, radius, 1.5f);
                    }
                    
                }
            }

            GameObject.Destroy(gameObject);
        }
    }
}
