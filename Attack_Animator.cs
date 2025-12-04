using UnityEngine;

public class Attack_Animator : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Klik kiri (Melee attack)
        if (Input.GetMouseButtonDown(0)) // tekan kiri
        {
            anim.SetBool("isMelee", true);
        }
        if (Input.GetMouseButtonUp(0)) // lepas kiri
        {
            anim.SetBool("isMelee", false);
        }

        // Klik kanan (Bow attack)
        if (Input.GetMouseButtonDown(1)) // tekan kanan
        {
            anim.SetBool("isBow", true);
        }
        if (Input.GetMouseButtonUp(1)) // lepas kanan
        {
            anim.SetBool("isBow", false);
        }
    }
}
