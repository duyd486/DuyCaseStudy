using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject BossBlock;
    public GameObject Boss;
    public GameObject bossBar;
    public Transform positionEnemy;
    public GameObject loveGhost;
    //private bool isSpawn = false;

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
        if (collision.gameObject.tag == "Player")
        {
            BossBlock.SetActive(true);
            Boss.SetActive(true);
            bossBar.SetActive(true);
            loveGhost.SetActive(false);
        }
    }

}
