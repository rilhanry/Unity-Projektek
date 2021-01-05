using UnityEngine;

public class BaseRanger : BaseClassScript
{
    private GameObject firepoint;
    public BaseRanger()
    {
        ClassName = "Ranger";
        Health = 8;
        Strength = 3;
        Intelligent = 2;
        Agility = 5;
        Damage = Agility * 5;
        Shooting = true;
    }
    void Start()
    {
        firepoint = GameObject.Find("FirePoint");
    }
    public void Hit(ShootController prefab)
    {
        Instantiate(prefab, firepoint.transform.position, firepoint.transform.rotation);
    }
}
