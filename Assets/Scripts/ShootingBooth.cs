using TMPro;
using UnityEngine;

public class ShootingBooth : MonoBehaviour
{

    private bool playerInside;
    private bool inBooth;
    private PlayerMovement playerMovement;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera boothCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement = other.GetComponent<PlayerMovement>();
            playerInside = true;
            Debug.Log("Press E to enter booth");
        }
    }

   private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            Debug.Log("Press E to exit booth");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(playerInside && Input.GetKeyDown(KeyCode.E))
        {
            if (!inBooth)
            {
                EnterBooth();
            } else
            {
                ExitBooth();
            }
        }
    }

    private void EnterBooth()
    {
        Debug.Log("Entered booth mode");
        playerMovement.SetCanMove(false);
        mainCamera.enabled = false;
        boothCamera.enabled = true;
        inBooth = true;
    }

    private void ExitBooth()
    {
        Debug.Log("Exited booth mode");
        playerMovement.SetCanMove(true);
         mainCamera.enabled = true;
        boothCamera.enabled = false;
        inBooth = false;
    }
}
