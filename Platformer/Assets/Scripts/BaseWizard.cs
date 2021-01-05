using UnityEngine;

public class BaseWizard : BaseClassScript
{
    private GameObject firepoint;
    public BaseWizard()
    {
        ClassName = "Wizard";
        Health = 9;
        Strength = 2;
        Intelligent = 5;
        Agility = 3;
        Damage = Intelligent * 5;
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
