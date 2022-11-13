using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public Vector3 direction;
    public Collider shooter;
    public float speed;
    public int castCostRed;
    public int castCostGreen;
    public int castCostBlue;
    public int damageRed;
    public int damageGreen;
    public int damageBlue;

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

    public Dictionary<string, int> getDamage()
    {
        Dictionary<string, int> damage = new Dictionary<string, int>();
        damage["red"] = damageRed;
        damage["green"] = damageGreen;
        damage["blue"] = damageBlue;
        return damage;
    }
}
