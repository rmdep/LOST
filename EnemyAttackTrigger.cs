using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed = 3f;
    public Transform player;

    [Header("Detection")]
    public float chaseRange = 10f;
    public float attackRange = 2f;

    private bool isChasing = false;
    private bool isAttacking = false;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // ==Kondisi ATTACK==
        if (distance <= attackRange)
        {
            isAttacking = true;
            isChasing = false;

            
            FacePlayer();

            SetAnim(false, false, true); 
        }
        // == Kondisi CHASE== 
        else if (distance <= chaseRange)
        {
            isChasing = true;
            isAttacking = false;

            FacePlayer();

            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );

            SetAnim(false, true, false); 
        }
        // == Kondisi IDLE== 
        else
        {
            isChasing = false;
            isAttacking = false;
            SetAnim(true, false, false); 
        }
    }

    void FacePlayer()
    {
       
        Vector3 lookPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookPos);
    }

    void SetAnim(bool idle, bool run, bool attack)
    {
        anim.SetBool("isIdle", idle);
        anim.SetBool("isRun", run);
        anim.SetBool("isAttack", attack);
    }

    // --- Debug di Editor ---
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
