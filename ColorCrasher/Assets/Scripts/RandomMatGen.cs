using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMatGen : MonoBehaviour
{
    public GameObject[] other;
    private void Start()
    {
        List<Color> color = new List<Color> { Color.red, Color.blue, Color.cyan, Color.green };

        if (transform.name == "Player")
        {
            Color randomColor = color[Random.Range(0, color.Count)];
            GetComponent<Renderer>().material.color = randomColor;
        }
        if (transform.childCount != 0)
        {
            foreach (GameObject item in other)
            {
                Color randomColor = color[Random.Range(0, color.Count)];
                item.GetComponent<Renderer>().material.color = randomColor;
                color.Remove(randomColor);
            }
        }
    }
}
