using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyJumpscare : MonoBehaviour
{
    [Header("Jumpscare Settings")]
    public GameObject jumpscareImage;     
    public float scareDuration = 1.5f;    

    private bool isPlayerTouching = false;

    void Start()
    {
      
        if (jumpscareImage != null)
            jumpscareImage.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            isPlayerTouching = true;
            ShowJumpscare();
        }
    }

    void OnTriggerExit(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            isPlayerTouching = false;
            HideJumpscare();
        }
    }

    void ShowJumpscare()
    {
        if (jumpscareImage != null)
        {
            jumpscareImage.SetActive(true);
            StopAllCoroutines(); 
            StartCoroutine(HideAfterDelay());
        }
    }

    void HideJumpscare()
    {
        if (jumpscareImage != null)
            jumpscareImage.SetActive(false);
    }

    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(scareDuration);
        if (!isPlayerTouching)
        {
            HideJumpscare();
        }
    }
}
