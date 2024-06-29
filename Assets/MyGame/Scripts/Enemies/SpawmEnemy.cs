using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmEnemy : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public Transform positionEnemy;
    private bool isSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!isSpawn)
        {
            isSpawn = true;
            Instantiate(enemyPrefabs, positionEnemy.position, Quaternion.identity);
        }
    }

}
