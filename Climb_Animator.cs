using UnityEngine;

public class Climb_Animator : MonoBehaviour
{
    private Animator anim;
    private bool nearObstacle = false;
    private bool nearRope = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // climb obstacle (H)
        if (nearObstacle && Input.GetKeyDown(KeyCode.H))
            anim.SetBool("isClimb", true);
        if (Input.GetKeyUp(KeyCode.H))
            anim.SetBool("isClimb", false);

        // climb rope (P)
        if (nearRope && Input.GetKeyDown(KeyCode.P))
            anim.SetBool("isClimbRope", true);
        if (Input.GetKeyUp(KeyCode.P))
            anim.SetBool("isClimbRope", false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Climbable"))
            nearObstacle = true;

        if (other.CompareTag("Rope"))
            nearRope = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            nearObstacle = false;
            anim.SetBool("isClimb", false);
        }

        if (other.CompareTag("Rope"))
        {
            nearRope = false;
            anim.SetBool("isClimbRope", false);
        }
    }
}
