using UnityEngine;
using ExpObj;


public class Target : MonoBehaviour
{
    [Header("Health Settings")]
    public float health = 1f;

    private bool isHit = false;
    private ExplosiveObject explodeScript;

    private RoundManager roundManagerScript;
    private void Awake()
    {
        // Get the ExplosiveObject component automatically from the same GameObject
        explodeScript = GetComponent<ExplosiveObject>();

        if (explodeScript == null)
        {
            Debug.LogError("ExplosiveObject component not found on " + gameObject.name);
        }

        // Find the RoundManager in the scene
        RoundManager rm = Object.FindFirstObjectByType<RoundManager>();
        if (roundManagerScript == null)
        {
            Debug.LogError("RoundManager not found in the scene.");
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
        if (!isHit)
        {
            isHit = true;
             if (roundManagerScript != null)
             {
                 roundManagerScript.RegisterHit();
             }
             Debug.Log("Target " + gameObject.name + " hit!");
        }
          
        if (explodeScript != null)
        {
            explodeScript.Explode();
        }
    }
}