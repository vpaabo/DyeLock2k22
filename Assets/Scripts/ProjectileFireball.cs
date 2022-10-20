using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFireball : MonoBehaviour
{
    public Vector3 direction;
    public Collider shooter;
    public float speed;
    private float maxTime = 10;

    private float radius = 3.0f;
    private float power = 150f;
    
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(shooter, GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (maxTime <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        transform.position += speed * direction * Time.deltaTime;
        maxTime -= Time.deltaTime;
    }

    void OnCollisionEnter (Collision c)
    {
        if (c.gameObject.tag != "PlayerProjectile" && c.gameObject.tag != "Player")
        {
            Vector3 explosionPos = transform.position;
            
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
