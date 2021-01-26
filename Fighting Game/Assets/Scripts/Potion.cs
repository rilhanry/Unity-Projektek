using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        transform.Rotate(0,0,3f);
        transform.position = startPos + new Vector3(0f, Mathf.Sin(Time.time) * 0.5f, 0f);
    }
}
