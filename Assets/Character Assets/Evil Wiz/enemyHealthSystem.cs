using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthSystem : MonoBehaviour
{
    public int numofArwTokill = 4;
    int numofArwTaken = 1;
    gameManager gameGM;

    private void Start()
    {
        gameGM = FindAnyObjectByType<gameManager>();
    }

    public void arrowHit()
    {
        if (numofArwTokill > numofArwTaken)
        {
            numofArwTaken++;
            Debug.Log("Arrow Hit : " + numofArwTaken);

        }
        else
        {
            gameGM.AddKills();
            Destroy(gameObject);
        }
    }
}
