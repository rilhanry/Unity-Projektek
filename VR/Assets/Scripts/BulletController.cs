using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public static float bulletSpeed = 1000f;
    private static int bulletDamage = 100;
    public static int Damage { get { return bulletDamage; } set { bulletDamage = value; } }
    
    private void OnTriggerEnter(Collider other)
    {
        ObjectPools.Instance.ReturnToPool(this);      
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
