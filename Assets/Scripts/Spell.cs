using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public Vector3 direction;
    public Collider shooter;
    public float speed;

    protected float maxTime = 10;

    void Start()
    {
        Physics.IgnoreCollision(shooter, GetComponent<Collider>());
    }

    void Update()
    {
        if (maxTime <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        transform.position += speed * direction * Time.deltaTime;
        maxTime -= Time.deltaTime;
    }
}
