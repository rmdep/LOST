using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyChase : MonoBehaviour
{
    [Header("Chase Settings")]
    public float chaseRange = 10.0f; 
    public float moveSpeed = 3.0f;   
    public Transform player;        

    [Header("Jumpscare Settings")]
    public GameObject jumpscareImage; // Gambar jumpscare (UI)
    
    private bool isTouchingPlayer = false; 

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasing();
        }

        // Kalau musuh lagi nyentuh player, tampilkan gambar
        if (isTouchingPlayer)
        {
            if (jumpscareImage != null)
                jumpscareImage.SetActive(true);
        }
        else
        {
            if (jumpscareImage != null)
                jumpscareImage.SetActive(false);
        }
    }

    void ChasePlayer()
    {
        Vector3 moveDirection = (player.position - transform.position).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        transform.LookAt(player);
    }

    void StopChasing()
    {
        // Bisa diisi nanti (animasi idle misalnya)
    }

    // Ketika musuh mulai menyentuh player
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = true;
        }
    }

    // Ketika musuh berhenti menyentuh player
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }
}
