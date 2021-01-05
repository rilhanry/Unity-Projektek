using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //basic movements
    public float movementSpeed = 20f;
    public float jumpForce = 400f;
    public float horizontalMove;
    public bool jump = false;
    Rigidbody2D rb;

    //stats
    public string playerClass = "player";
    public int playerHP;
    public int playerStrength;
    public int playerIntelligent;
    public int playerAgility;
    public int playerDamage;

    //prefabs
    public GameObject sword_prefab;
    public GameObject staff_prefab;
    public ShootController fireBall_prefab;
    public ShootController grenade_prefab;

    //firepoint
    public Transform firePoint;

    public List<GameObject> weapons = new List<GameObject>();

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void WarriorClass()
    {
        if (!GetComponent<BaseWarrior>())
        {
            if (GetComponent<BaseWizard>() || GetComponent<BaseRanger>())
            {
                Destroy(GetComponent<BaseRanger>());
                Destroy(GetComponent<BaseWizard>());
            }
            var klassz = gameObject.AddComponent<BaseWarrior>();
            playerClass = klassz.ClassName;
            playerHP = klassz.Health;
            playerStrength = klassz.Strength;
            playerIntelligent = klassz.Intelligent;
            playerAgility = klassz.Agility;
            playerDamage = klassz.Damage;
        
            firePoint.localEulerAngles = new Vector3(0, 0, 0);  

            if (weapons.Count == 1)
            {
                Destroy(weapons[0]);
                weapons.Remove(weapons[0]);
            }
            if (weapons.Count < 1)
            {
                weapons.Add(Instantiate(sword_prefab, transform, false));
                weapons[0].transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
                weapons[0].gameObject.SetActive(true);
            }
        }
    }
    public void RangerClass()
    {
        if (!GetComponent<BaseRanger>())
        {
            if (GetComponent<BaseWizard>() || GetComponent<BaseWarrior>())
            {
                Destroy(GetComponent<BaseWarrior>());
                Destroy(GetComponent<BaseWizard>());
            }
            var klassz = gameObject.AddComponent<BaseRanger>();
            playerClass = klassz.ClassName;
            playerHP = klassz.Health;
            playerStrength = klassz.Strength;
            playerIntelligent = klassz.Intelligent;
            playerAgility = klassz.Agility;
            playerDamage = klassz.Damage;

            firePoint.localEulerAngles = new Vector3(0, 0, 45);

            if (weapons.Count == 1)
            {
                Destroy(weapons[0]);
                weapons.Remove(weapons[0]);
            }

        }
    }
    public void WizardClass()
    {
        if (!GetComponent<BaseWizard>())
        {
            if (GetComponent<BaseRanger>() || GetComponent<BaseWarrior>())
            {
                Destroy(GetComponent<BaseWarrior>());
                Destroy(GetComponent<BaseRanger>());
            }
            var klassz = gameObject.AddComponent<BaseWizard>();
            playerClass = klassz.ClassName;
            playerHP = klassz.Health;
            playerStrength = klassz.Strength;
            playerIntelligent = klassz.Intelligent;
            playerAgility = klassz.Agility;
            playerDamage = klassz.Damage;

            firePoint.localEulerAngles = new Vector3(0, 0, 0);

            if (weapons.Count == 1)
            {
                Destroy(weapons[0]);
                weapons.Remove(weapons[0]);
            }
            if (weapons.Count < 1)
            {
                weapons.Add(Instantiate(staff_prefab, transform, false));
                weapons[0].transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
                weapons[0].gameObject.SetActive(true);
            }
        }
    }
    private void Update()
    {
        //moving direction
        horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;

        //rotating
        if (horizontalMove < 0f) transform.localEulerAngles = new Vector3(0, 180, 0);
        if (horizontalMove > 0f) transform.localEulerAngles = new Vector3(0, 0, 0);

        //jumping
        if (Input.GetButtonDown("Jump")) jump = true;

        //attack
        if (Input.GetButtonDown("Fire1"))
        {
            if (GetComponent<BaseWarrior>()) GetComponent<BaseWarrior>().Hit();
            else if (GetComponent<BaseWizard>()) GetComponent<BaseWizard>().Hit(fireBall_prefab);
            else if (GetComponent<BaseRanger>()) GetComponent<BaseRanger>().Hit(grenade_prefab);
        }
    }
    private void FixedUpdate()
    {
        //we create our moving function
        Moving(horizontalMove, jump);
    }
    void Moving(float movement, bool canjump)
    {
        rb.velocity = new Vector2(movement * movementSpeed * Time.fixedDeltaTime, rb.velocity.y);

        if (canjump && GetComponent<CircleCollider2D>().IsTouchingLayers())
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = !canjump;
        }
    }
}
