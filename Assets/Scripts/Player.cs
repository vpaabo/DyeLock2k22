using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Camera playerCam;
    

    public List<Spell> spells; // = new List<Spell>()

    public ProjectileFireball prefabFireball;
    public ProjectileLightningBolt prefabLightningBolt;

    private Spell SelectedSpell;
    private int SpellCounter = 0;

    private int resourceRed = 0;
    private int resourceGreen = 0;
    private int resourceBlue = 0;

    public float shotIntervalMax = 0.5f;
    private float shotIntervalCurrent;

    private void Awake()
    {
        Events.OnSpellSelected += OnSpellSelected;
    }

    private void OnDestroy()
    {
        Events.OnSpellSelected -= OnSpellSelected;
    }

    void Start()
    {
        shotIntervalCurrent = -1;
        SelectedSpell = spells[SpellCounter];
    }

    
    void Update()
    {

        if (Input.mouseScrollDelta != Vector2.zero)
        {
            print(Input.mouseScrollDelta);

            int nextSpell= (int) Input.mouseScrollDelta.y;
            if (nextSpell >= 0)
            {
                SpellCounter = (SpellCounter + nextSpell) % spells.Count;
            } else
            {
                SpellCounter = (SpellCounter + Mathf.Abs(nextSpell-1)) % spells.Count;
            }
            
            Events.SelectSpell(SpellCounter);

            print("selected spell" + SpellCounter + SelectedSpell.gameObject.name);
        }
        if (Input.GetMouseButton(0) && shotIntervalCurrent <= 0)
        {
            shootSpell();
            shotIntervalCurrent = shotIntervalMax;
        }
        /*else if (Input.GetMouseButton(1) && shotIntervalCurrent <= 0)
        {
            shootLightningBolt();
            shotIntervalCurrent = shotIntervalMax;
        } */
        else
        {
            shotIntervalCurrent -= Time.deltaTime;
        }
    }

    void OnSpellSelected(int n)
    {
        SelectedSpell = spells[SpellCounter];
    }
    void shootSpell()
    {
        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 direction = Vector3.Normalize(ray.GetPoint(1) - playerCam.transform.position);
        Spell spell = GameObject.Instantiate<Spell>(SelectedSpell, playerCam.transform.position - new Vector3(0, 0.25f, 0) + direction, transform.rotation);
        spell.direction = direction;
        spell.speed = SelectedSpell.speed;
        spell.shooter = gameObject.GetComponentInChildren<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit by enemy!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        ProjectileLightningBolt bolt = GameObject.Instantiate<ProjectileLightningBolt>(prefabLightningBolt, playerCam.transform.position - new Vector3(0, 0.25f, 0) + direction, transform.rotation);
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
