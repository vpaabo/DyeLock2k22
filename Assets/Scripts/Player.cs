using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera playerCam;
    public ProjectileFireball prefabFireball;
    public ProjectileLightningBolt prefabLightningBolt;
    
    private int resourceRed = 0;
    private int resourceGreen = 0;
    private int resourceBlue = 0;

    public float shotIntervalMax = 0.5f;
    private float shotIntervalCurrent;
    
    // Start is called before the first frame update
    void Start()
    {
        shotIntervalCurrent = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && shotIntervalCurrent <= 0)
        {
            shootFireball();
            shotIntervalCurrent = shotIntervalMax;
        } else if (Input.GetMouseButton(1) && shotIntervalCurrent <= 0)
        {
            shootLightningBolt();
            shotIntervalCurrent = shotIntervalMax;
        } else
        {
            shotIntervalCurrent -= Time.deltaTime;
        }
    }

    void shootFireball()
    {
        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 direction = Vector3.Normalize(ray.GetPoint(1) - playerCam.transform.position);
        ProjectileFireball fireball = GameObject.Instantiate<ProjectileFireball>(prefabFireball, playerCam.transform.position - new Vector3(0, 0.25f, 0) + direction, transform.rotation);
        fireball.direction = direction;
        fireball.speed = 20;
        fireball.shooter = gameObject.GetComponentInChildren<Collider>();
    }

    void shootLightningBolt()
    {
        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 direction = Vector3.Normalize(ray.GetPoint(1) - playerCam.transform.position);
        ProjectileLightningBolt bolt = GameObject.Instantiate<ProjectileLightningBolt>(prefabLightningBolt, playerCam.transform.position - new Vector3(0, 0.25f, 0), transform.rotation);
        bolt.direction = direction;
        bolt.speed = 50;
        bolt.shooter = gameObject.GetComponentInChildren<Collider>();
    }

    public int getResourceRed()
    {
        return resourceRed;
    }
    public int getResourceGreen()
    {
        return resourceGreen;
    }
    public int getResourceBlue()
    {
        return resourceBlue;
    }
    public void setResourceRed(int amount)
    {
        resourceRed = amount;
    }
    public void setResourceGreen(int amount)
    {
        resourceGreen = amount;
    }
    public void setResourceBlue(int amount)
    {
        resourceBlue = amount;
    }
}
