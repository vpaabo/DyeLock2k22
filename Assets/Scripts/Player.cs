using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera playerCam;
    public ProjectileFireball prefabFireball;
    
    private int resourceRed = 0;
    private int resourceGreen = 0;
    private int resourceBlue = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootFireball();
        }
    }

    void shootFireball()
    {
        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        ProjectileFireball fireball = GameObject.Instantiate<ProjectileFireball>(prefabFireball, playerCam.transform.position, transform.rotation);
        fireball.direction = Vector3.Normalize(ray.GetPoint(1) - playerCam.transform.position);
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
