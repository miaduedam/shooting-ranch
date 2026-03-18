using TMPro;
using UnityEngine;

public class ShootingBooth : MonoBehaviour
{

    private bool playerInside;
    private bool inBooth;
    private PlayerMovement playerMovement;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera boothCamera;
    [SerializeField] private Transform standPoint;
    [SerializeField] private Transform exitPoint;

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
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (inBooth)
            {
                ExitBooth();
            } else if (playerInside)
            {
                EnterBooth();
            }
        }
    }

    private void EnterBooth()
    {
        Debug.Log("Entered booth mode");
        var rb = playerMovement.GetComponent<Rigidbody>();
        rb.position = standPoint.position;
        rb.rotation = Quaternion.Euler(0f, standPoint.eulerAngles.y,0f);
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        playerMovement.SetCanMove(false);
        mainCamera.enabled = false;
        boothCamera.enabled = true;
        inBooth = true;
    }

   private void ExitBooth()
{
    Debug.Log("Exited booth mode");
    
    // TELEPORT PLAYER TIL EXIT POINT
    var rb = playerMovement.GetComponent<Rigidbody>();
    rb.position = exitPoint.position;
    rb.rotation = Quaternion.Euler(0f, exitPoint.eulerAngles.y, 0f);
    rb.linearVelocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;
    playerMovement.SetCanMove(true);

    mainCamera.enabled = true;
    boothCamera.enabled = false;

    

    inBooth = false;
}

}
