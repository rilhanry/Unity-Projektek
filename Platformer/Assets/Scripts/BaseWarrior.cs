using System.Collections;
using UnityEngine;

public class BaseWarrior : BaseClassScript
{
    private Animator anim;
    public BaseWarrior()
    {
        ClassName = "Warrior";
        Health = 10;
        Strength = 5;
        Intelligent = 2;
        Agility = 3;
        Damage = Strength * 5;
        Shooting = false;
    }
    public void Hit()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("attack", false);
        StartCoroutine(HitSword());
    }
    IEnumerator HitSword()
    {
        anim.SetBool("attack", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("attack", false);
    }
}
