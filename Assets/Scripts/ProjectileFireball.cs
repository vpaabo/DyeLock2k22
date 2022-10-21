using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 1.5f);
                }
            }

            GameObject.Destroy(gameObject);
        }
    }
}
