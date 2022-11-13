using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePickup : MonoBehaviour
{
    public int resourceRed = 0;
    public int resourceGreen = 0;
    public int resourceBlue = 0;

    public ParticleSystem fx;
    private float despawnMod = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale -= despawnMod * new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
        despawnMod += 0.05f *Time.deltaTime;
        if (gameObject.transform.localScale.x <= 0.05f)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Resources picked up!");
            Events.AddResources(resourceRed, resourceGreen, resourceBlue);
            GameObject.Destroy(gameObject);
        }
    }
}
