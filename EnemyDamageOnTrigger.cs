using UnityEngine;

public class EnemyDamageOnTrigger : MonoBehaviour
{
    public int damage = 10;
    public float attackCooldown = 1.0f;
    private float lastAttackTime = -999f;

    void OnTriggerEnter(Collider other)
    {
        TryDamage(other);
    }

    void TryDamage(Collider other)
    {
        // Hanya kasih damage kalau yang kena adalah Player
        if (!other.CompareTag("Player")) return;

        // Cek cooldown biar ga hit spam
        if (Time.time - lastAttackTime < attackCooldown) return;

        // Ambil komponen health player
        PlayerHealth ph = other.GetComponent<PlayerHealth>();
        if (ph != null)
        {
            ph.TakeDamage(damage);
            lastAttackTime = Time.time;

            // Optional: aktifkan animasi kena hit
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            if (pm != null)
            {
                pm.TakeDamage();
            }
        }
    }
}
