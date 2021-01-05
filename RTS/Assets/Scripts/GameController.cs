using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    private int gold;
    public int Gold { get { return gold; } set { gold = value; } }
    public Text goldText;

    private AudioSource myAudio;
    public bool audioIsPlay = false;
    public bool audioChanged = false;

    private void Awake()
    {
        Gold = 500;
        myAudio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        StartCoroutine(GetMoney());
    }
    private void Update()
    {
        if (audioIsPlay && audioChanged)
        {
            myAudio.Play();
            audioChanged = false;
        }
        if (!audioIsPlay && audioChanged)
        {
            myAudio.Stop();
            audioChanged = false;
        }
        goldText.text = "Gold: " + Gold.ToString();
    }
    IEnumerator GetMoney()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            Gold += 100;
        }
    }
}
