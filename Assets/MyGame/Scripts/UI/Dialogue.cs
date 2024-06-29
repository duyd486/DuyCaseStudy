using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject npcDialogue;

    // Start is called before the first frame update
    void Start()
    {
        npcDialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        npcDialogue.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        npcDialogue.SetActive(false);
    }

}
