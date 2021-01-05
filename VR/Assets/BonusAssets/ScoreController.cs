using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    public static int kills = 0;

    private void Awake()
    {
        kills = 0;
    }
    private void Update()
    {
        GetComponent<Text>().text = "Kills: " + kills;
    }
}
