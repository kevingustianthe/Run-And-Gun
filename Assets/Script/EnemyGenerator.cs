using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // public ObjectPooler enemyPool;
    // public ObjectPooler[] theEnemyPools;
    public GameObject[] theEnemyPools;
    private int enemySelector;
    public AudioSource enemyDeathSound;

    // private EnemyScript theEnemyScript;
    
    // Start is called before the first frame update
    void Start()
    {
        // theEnemyScript = FindObjectOfType<EnemyScript>();
    }

    public void SpawnEnemy(Vector3 startPosition)
    {
        // enemySelector = Random.Range(0, theEnemyPools.Length);
        enemySelector = Random.Range(0, theEnemyPools.Length);
        // GameObject enemy1 = enemyPool.GetPooledObject();
        // GameObject enemy1 = theEnemyPools[enemySelector].GetPooledObject();
        Instantiate(theEnemyPools[enemySelector], startPosition, transform.rotation);
        // enemy1.transform.position = startPosition;
        // enemy1.SetActive (true);
    }

    public void PlayAudio()
    {
        enemyDeathSound.Play();
    }
}
