using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLightningBolt : Spell
{

    
    // IN PARENT CLASS

    /*void Start()
    {
        Physics.IgnoreCollision(shooter, GetComponent<Collider>());
    }*/
    /*void Update()
    {
        if (maxTime <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        transform.position += speed * direction * Time.deltaTime;
        maxTime -= Time.deltaTime;
    }*/

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag != "PlayerProjectile" && c.gameObject.tag != "Player")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
