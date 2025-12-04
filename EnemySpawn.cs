using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform player;
    public GameObject enemyModel;
    public float appearRange = 10f;
    public float moveSpeed = 3f;

    bool hasAppeared = false;

    void Start()
    {
        enemyModel.SetActive(false);
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        if (!hasAppeared && dist <= appearRange)
        {
            hasAppeared = true;
            enemyModel.SetActive(true);
        }

        if (hasAppeared)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            transform.Translate(dir * moveSpeed * Time.deltaTime, Space.World);
            transform.LookAt(player);
        }
    }
}
