using UnityEngine;

public class MeleeHitController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            ScoreController.kills++;
        }
    }
}
