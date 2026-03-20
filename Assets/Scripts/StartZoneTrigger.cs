using UnityEngine;

public class StartZoneTrigger : MonoBehaviour
{
    [SerializeField] private RoundManager roundManagerScript;

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roundManagerScript.StartRound();
            Debug.Log("Player entered start zone");
        }
    }
}
