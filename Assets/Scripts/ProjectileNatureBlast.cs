using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileNatureBlast : Spell
{
    void Start()
    {
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag != "PlayerProjectile" && other.tag != "Player")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                if (other.tag == "Enemy")
                {
                    rb.isKinematic = false; // Enables enemy to be affected by external forces
                }

                rb.AddForce(direction * 50);
            }
        }
    }
}
