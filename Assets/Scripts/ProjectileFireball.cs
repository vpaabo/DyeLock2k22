using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFireball : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 30;
    private float maxTime = 10;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (maxTime <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        transform.position += speed * direction * Time.deltaTime;
        Debug.Log(transform.position);
        maxTime -= Time.deltaTime;
    }

    void OnCollisionEnter (Collision c)
    {
        if (c.gameObject.tag != "Bullet" && c.gameObject.tag != "Player")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
