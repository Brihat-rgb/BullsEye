using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowBheav : MonoBehaviour
{
    void Start()
    {
        Invoke("DestoryGameObj", 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Main Enemy")
        {
            collision.GetComponent<enemyHealthSystem>().arrowHit();
            DestoryGameObj();
        }
    }

    void DestoryGameObj()
    {
        Destroy(gameObject);
    }
}
