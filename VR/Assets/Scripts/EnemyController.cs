using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float healthPoint = 50f;
    private float damagePoint = 10f;
    private float speed = 5f;

    private Animator anim;
    private PlayerController player;
    private Vector3 offset = new Vector3(0, 1.5f, -2.5f);
    private Vector3 playerPos;

    public float Health { get { return healthPoint; } set { healthPoint = value; } }
    public float Damage { get { return damagePoint; } set { damagePoint = value; } }
    public float MovementSpeed { get { return speed; } set { speed = value; } }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
        playerPos = player.transform.position - offset;
    }

    private bool PlayerNearby(float value) {
        return Vector3.Distance(transform.position, player.transform.position) <= value;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * MovementSpeed * transform.forward;
        anim.SetBool("move", true);

        if (PlayerNearby(10f)) {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, MovementSpeed * Time.deltaTime);
            transform.LookAt(playerPos);
            if (PlayerNearby(5f)) {
                StartCoroutine(AttackPlayer());
            }
        }
    }

    IEnumerator AttackPlayer() {
        anim.SetBool("attack", true);
        yield return new WaitForSeconds(1);
        Destroy(    , 1);
    }
}
