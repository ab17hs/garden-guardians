using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public float attackRange = 2f;

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= attackRange)
            {
                Destroy(enemy);
            }
        }
    }
}