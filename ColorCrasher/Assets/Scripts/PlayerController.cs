using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static float speed = 8f;

    private float prev_speed;
    private float addSpeed;

    private float screenWidth;

    public int coinGet;
    private int goalCoin;
    private static int max_coin;

    public Text cointext;
    public Text maxcointext;
    public Text speedtext;
    public Text endtext;

    private void Start()
    {
        screenWidth = Screen.width;

        addSpeed = 0f;

        coinGet = 0;
        goalCoin = 10;

        maxcointext.text = "High Coins: " + max_coin;
        cointext.text = "Coins: " + coinGet;
        speedtext.text = "Speed: " + Mathf.Round(speed);
    }

    private void Update()
    {
        //Gépi irányítás
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -1.5f && speed > 0)
            transform.position -= Vector3.right * 1f;
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 1.5f && speed > 0)
            transform.position += Vector3.right * 1f;
        //Mobilos irányítás
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).position.x < screenWidth / 2f && Input.GetTouch(i).phase == TouchPhase.Ended && transform.position.x > -1.5f && speed > 0)
                transform.position -= Vector3.right * 1f;
            if (Input.GetTouch(i).position.x > screenWidth / 2f && Input.GetTouch(i).phase == TouchPhase.Ended && transform.position.x < 1.5f && speed > 0)
                transform.position += Vector3.right * 1f;
        }
        maxcointext.text = "High Coins: " + max_coin;
        cointext.text = "Coins: " + coinGet;
        speedtext.text = "Speed: " + Mathf.Round(speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<Transform>().tag == "obs")
        {
            Destroy(other.gameObject);

            if (GetComponent<Renderer>().material.color != other.GetComponent<Renderer>().material.color)
            {
                if (speed > 8) speed /= 1.5f;

                prev_speed = speed;
                StartCoroutine(gameEnd());
            }
        }
        if (other.gameObject.tag == "cointag")
        {
            coinGet += 2;
            if (max_coin < coinGet) max_coin = coinGet;

            ObjectPools.Instance.ReturnToPool(other.GetComponent<CoinRotate>());

            if (coinGet >= goalCoin)
            {
                goalCoin += (coinGet / 2);
                addSpeed += 2f;
                speed += (addSpeed / 2);
            }
        }
    }
    IEnumerator gameEnd()
    {
        endtext.gameObject.SetActive(true);

        speed = 0;
        yield return new WaitForSeconds(3);
        speed = prev_speed;
        yield return new WaitForSeconds(0.05f);
        SceneManager.LoadScene("SampleScene");
    }
}
