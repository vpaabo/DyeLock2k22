using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FogWall : MonoBehaviour
{
    public float cooldown = 0.1f;
    private float current;

    private void Awake()
    {
        current = 0;
    }

    private void Update()
    {
        current -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (current <= 0)
            {
                Events.UseResources(5, 5, 5);
                Debug.Log("Drained by fog");
                current = cooldown;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (current <= 0)
            {
                Events.UseResources(5, 5, 5);
                Debug.Log("Drained by fog");
                current = cooldown;
            }
        }
    }
}
