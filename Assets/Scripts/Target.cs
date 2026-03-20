using UnityEngine;
using ExpObj;
using System.Diagnostics; // needed for ExplosiveObject

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
            UnityEngine.Debug.LogError("ExplosiveObject component not found on " + gameObject.name);
        }

        // Find the RoundManager in the scene
        roundManagerScript = FindObjectOfType<RoundManager>();
        if (roundManagerScript == null)
        {
            UnityEngine.Debug.LogError("RoundManager not found in the scene.");
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
             UnityEngine.Debug.Log("Target " + gameObject.name + " hit!");
        }
          
        if (explodeScript != null)
        {
            explodeScript.Explode();
        }
    }
}