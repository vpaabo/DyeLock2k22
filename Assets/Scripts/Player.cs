using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Camera playerCam;

    public List<Spell> spells; // = new List<Spell>()
    public Dictionary<string, bool> upgrades;

    private Spell SelectedSpell;
    private int SpellCounter = 0;

    private int resourceCap = 100;
    private int resourceRed;
    private int resourceGreen;
    private int resourceBlue;

    public float shotIntervalMax = 0.5f;
    private float shotIntervalCurrent;
    private int shotBurst = 0;
    private float shotIntervalBurst;

    private CharacterController characterController;
    private Rigidbody rb;
    private Vector3 forceDirection;
    private float forceAmount;
    private bool forceIsAffected;

    private void Awake()
    {
        Events.OnSpellSelected += OnSpellSelected;
        Events.OnAddForceToPlayer += OnAddForceToPlayer;
        Events.OnSetUpgrade += OnSetUpgrade;
        Events.OnAddResources += OnAddResources;
        Events.OnUseResources += OnUseResources;
        Events.OnSetResources += OnSetResources;

        resourceRed = resourceCap;
        resourceGreen = resourceCap;
        resourceBlue = resourceCap;

        // TODO: Temporary solution to give all upgrades.
        // Need to find solution in the future so 'upgrades' dictionary is instantiated with proper boolean values
        upgrades = new Dictionary<string, bool>();
        
        foreach (string name in Enum.GetNames(typeof(Constants.SpellUpgrades)))
        {
            upgrades[name] = true;
        }
    }

    private void OnDestroy()
    {
        Events.OnSpellSelected -= OnSpellSelected;
        Events.OnAddForceToPlayer -= OnAddForceToPlayer;
        Events.OnSetUpgrade -= OnSetUpgrade;
        Events.OnAddResources -= OnAddResources;
        Events.OnUseResources -= OnUseResources;
        Events.OnSetResources -= OnSetResources;
    }

    void Start()
    {
        shotIntervalCurrent = -1;
        SelectedSpell = spells[SpellCounter];

        characterController = GetComponentInChildren<CharacterController>();
        rb = GetComponent<Rigidbody>();
        forceIsAffected = false;
    }

    
    void Update()
    {
        if (resourceRed <= 0 && resourceGreen <= 0 && resourceBlue <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //Debug.Log("R: " + resourceRed.ToString() + "\tG: " + resourceGreen.ToString() + "\tB: " + resourceBlue.ToString());

        if (Input.mouseScrollDelta != Vector2.zero && shotBurst == 0)
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

        if (shotBurst > 0 && shotIntervalBurst <= 0)
        {
            shootSpell();
            shotIntervalBurst = shotIntervalMax / shotBurst;
            shotBurst -= 1;
        } else if (Input.GetMouseButton(0) && shotIntervalCurrent <= 0)
        {
            if (SelectedSpell.castCostRed <= resourceRed &&
                SelectedSpell.castCostGreen <= resourceGreen &&
                SelectedSpell.castCostBlue <= resourceBlue)
            {
                shootSpell();
                shotIntervalCurrent = shotIntervalMax;

                resourceRed -= SelectedSpell.castCostRed;
                resourceGreen -= SelectedSpell.castCostGreen;
                resourceBlue -= SelectedSpell.castCostBlue;
                clampResources(); // This should not be necessary, but is here as failsafe
                
                // Red burst upgrade
                if (SelectedSpell is ProjectileFireball && shotBurst == 0)
                {
                    if (upgrades[Constants.SpellUpgrades.R_BURST_1.ToString()])
                    {
                        if (upgrades[Constants.SpellUpgrades.R_BURST_2.ToString()])
                        {
                            shotBurst = 2;
                        }
                        else
                        {
                            shotBurst = 1;
                        }
                    }
                    shotIntervalBurst = shotIntervalMax / shotBurst;
                    shotIntervalCurrent += 1;
                }
            }
        } else
        {
            shotIntervalCurrent -= Time.deltaTime;
            if (shotBurst > 0)
            {
                shotIntervalBurst -= Time.deltaTime;
            }
        }
        // TODO: Basis for script to affect player by external forces, currently janky
        if (forceIsAffected)
        {
            gameObject.transform.position += forceDirection * forceAmount;
            forceAmount -= 0.5f * Time.deltaTime;
            if (forceAmount <= 0)
            {
                forceIsAffected = false;
            }
        }
    }

    void OnAddForceToPlayer(Vector3 dir, float amount)
    {
        forceDirection = dir;
        forceAmount = amount;
        forceIsAffected = true;
    }

    void OnSetUpgrade(string name, bool value)
    {
        upgrades[name] = value;
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
        float speedValue = SelectedSpell.speed;
        // Blue speed upgrade
        if (SelectedSpell is ProjectileLightningBolt)
        {
            if (upgrades[Constants.SpellUpgrades.B_SPEED_1.ToString()])
            {
                speedValue += 10;
                if (upgrades[Constants.SpellUpgrades.B_SPEED_2.ToString()])
                {
                    speedValue += 10;
                }
            }
        }
        spell.speed = speedValue;
        spell.shooter = gameObject.GetComponentInChildren<Collider>();
        // Green boost upgrade
        if (SelectedSpell is ProjectileNatureBlast)
        {
            if (upgrades[Constants.SpellUpgrades.G_BOOST.ToString()] && !characterController.isGrounded)
            {
                Events.AddForceToPlayer(direction * -1, 0.25f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody?.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit by enemy!");
        }
    }

    /*void shootFireball()
    {
        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 direction = Vector3.Normalize(ray.GetPoint(1) - playerCam.transform.position);
        ProjectileFireball fireball = GameObject.Instantiate<ProjectileFireball>(prefabFireball, playerCam.transform.position - new Vector3(0, 0.25f, 0) + direction, transform.rotation);
        fireball.direction = direction;
        fireball.speed = 20;
        fireball.shooter = gameObject.GetComponentInChildren<Collider>();
    }*/

    /*void shootLightningBolt()
    {
        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 direction = Vector3.Normalize(ray.GetPoint(1) - playerCam.transform.position);
        ProjectileLightningBolt bolt = GameObject.Instantiate<ProjectileLightningBolt>(prefabLightningBolt, playerCam.transform.position - new Vector3(0, 0.25f, 0) + direction, transform.rotation);
        bolt.direction = direction;
        bolt.speed = 50;
        bolt.shooter = gameObject.GetComponentInChildren<Collider>();
    }*/

    void clampResources()
    {
        resourceRed = Mathf.Clamp(resourceRed, 0, resourceCap);
        resourceGreen = Mathf.Clamp(resourceGreen, 0, resourceCap);
        resourceBlue =Mathf.Clamp(resourceBlue, 0, resourceCap);
    }

    void OnAddResources(int red, int green, int blue)
    {
        resourceRed += red;
        resourceGreen += green;
        resourceBlue += blue;
        clampResources();
    }

    void OnUseResources(int red, int green, int blue)
    {
        resourceRed -= red;
        resourceGreen -= green;
        resourceBlue -= blue;
        clampResources();
    }

    void OnSetResources(int red, int green, int blue)
    {
        resourceRed = red;
        resourceGreen = green;
        resourceBlue = blue;
        clampResources();
    }
}
