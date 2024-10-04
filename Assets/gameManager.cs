using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] private float playerHealth = 10f;
    float damageTaken = 0;
    public healthUIsystem UIsystem;

    public void PlayerHit()
    {
        if (damageTaken < playerHealth)
        {
            damageTaken += damageTaken;
            UIsystem.removeHealth((playerHealth - damageTaken) / playerHealth);
        }
        else
        {
            Debug.Log("Player Dead");
            Time.timeScale = 0f;
        }
    }
}