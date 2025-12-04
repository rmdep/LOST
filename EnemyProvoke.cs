using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProvoke : MonoBehaviour
{
    public bool provoked = false;

    void Update()
    {
        if (provoked)
        {
            AttackPlayer();
        }
        else
        {
            // Logika perilaku normal musuh jika tidak diprovokasi
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            provoked = true;
        }
    }

    void AttackPlayer()
    {
        Debug.Log("Musuh menyerang pemain!");
        // Logika serangan terhadap pemain (misalnya animasi atau damage)
    }
}
