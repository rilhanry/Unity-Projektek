using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnController : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    public Transform PlayerSummon;
    public Transform EnemySummon;

    private GameController game;
    public int price = 100;

    private void Start()
    {
        game = FindObjectOfType<GameController>();
        StartCoroutine(SummonEnemy());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (game.Gold >= price)
            {
                Instantiate(PlayerPrefab, PlayerSummon.position, Quaternion.identity, PlayerSummon);
                game.Gold -= price;
            }
        }
    }
    IEnumerator SummonEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            Instantiate(EnemyPrefab, EnemySummon.position, Quaternion.Euler(0, 180, 0), EnemySummon);
        }
    }
}
