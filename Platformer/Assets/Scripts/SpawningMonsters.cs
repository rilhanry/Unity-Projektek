using System.Collections;
using UnityEngine;

public class SpawningMonsters : MonoBehaviour
{
    public GameObject monster;
    private void Start()
    {
        StartCoroutine(Spawning());
    }
    IEnumerator Spawning()
    {
        while (true)
        {
            Vector2 spawnPoint = new Vector2(Random.Range(-48,20), Random.Range(10,20));
            Instantiate(monster, spawnPoint, Quaternion.identity, transform);
            yield return new WaitForSeconds(3f);
        }
    }
}
