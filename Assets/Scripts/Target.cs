using UnityEngine;
using ExpObj; // needed for ExplosiveObject

public class Target : MonoBehaviour
{
    [Header("Health Settings")]
    public float health = 1f;

    private ExplosiveObject explodeScript;

    private void Awake()
    {
        // Get the ExplosiveObject component automatically from the same GameObject
        explodeScript = GetComponent<ExplosiveObject>();

        if (explodeScript == null)
        {
            Debug.LogError("ExplosiveObject component not found on " + gameObject.name);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Explode();
        }
    }

    private void Explode()
    {
        if (explodeScript != null)
        {
            explodeScript.Explode();
        }
    }
}