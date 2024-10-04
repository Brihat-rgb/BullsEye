using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackLogic : MonoBehaviour
{
    float timer = 0;
    public gameManager gameM;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            timer += Time.deltaTime;
            Debug.Log("Timer : " + timer);

            if (collision.gameObject.tag == "Player" && (int) timer == 3)
            {
                gameM.PlayerHit();
                Debug.Log("Hit");
                timer = 0;

            }
        }
    }

}