using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLightningBolt : MonoBehaviour
{
    public Vector3 direction;
    public Collider shooter;
    public float speed;

    private float maxTime = 10;

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

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag != "PlayerProjectile" && c.gameObject.tag != "Player")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
