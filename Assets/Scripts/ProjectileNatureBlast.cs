using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

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
                    // Leftovers from when shots were instakill
                    //rb.isKinematic = false; // Enables enemy to be affected by external forces
                    other.gameObject.GetComponent<Enemy>().takeDamage(damageRed, damageGreen, damageBlue);
                }

                rb.AddForce(direction * 50);
            }
        }
    }
}
