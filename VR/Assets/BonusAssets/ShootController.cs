using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float bulletSpeed;
    private Rigidbody2D rb;
    private PlayerController player;
    private bool flying = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
    }
    private void FixedUpdate()
    {
        if (player.playerClass == "Wizard")
            rb.velocity = transform.right * bulletSpeed;

        if (player.playerClass == "Ranger")
        {
            if (flying)
            {
                rb.velocity = transform.right * bulletSpeed;
                flying = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.playerClass == "Ranger")
        {
            flying = false;
            if (!flying) GetComponent<CircleCollider2D>().isTrigger = false;
        }
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            ScoreController.kills++;
        }

        Destroy(gameObject, 2f);
    }
}
