using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawn : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] GameObject[] attackerPrefabs;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 5f;
    float randomSpawnTime;
    GameTimer gameTimer;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        gameTimer = GetComponent<GameTimer>();
        randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        do
        {
            randomSpawnTime -= Time.deltaTime;
            if (randomSpawnTime <= 0)
            {
                yield return StartCoroutine(AttackerSpawnMoves());
            }
        } while (spawn);
        randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    IEnumerator AttackerSpawnMoves()
    {
        int randomNumber = Random.Range(0, attackerPrefabs.Length);
        randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        GameObject newAttacker = Instantiate(attackerPrefabs[randomNumber], transform.position, Quaternion.Euler(new Vector3(0,0,270))) as GameObject;
        //newAttacker.transform.parent = transform;
        yield return new WaitForSeconds(randomSpawnTime);
    }

    public void StopSpawning()
    {
        spawn = false;
    }

}
