using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeflect : MonoBehaviour
{
    [SerializeField] private float damage = 0f;
    private ItakeDame ItakeDame;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItakeDame = collision.gameObject.GetComponent<ItakeDame>();
        if(ItakeDame != null)
        {
            ItakeDame.Damage(damage);
            Destroy(gameObject, 0.2f);
        }
    }

}
