using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb; 
    private Vector2 moveInput;   
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform cameraTransform; 
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private float mouseSensitivity = 2f;  
    [SerializeField] private float minPitch = -35f;  
    [SerializeField] private float maxPitch = 60f;  
    private float pitch;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");// A/D
        float y = Input.GetAxisRaw("Vertical"); // WS
        moveInput = new Vector2(x,y);
        Debug.Log(moveInput);

        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        // Rotate the player (left/right)
        transform.Rotate(Vector3.up * mouseX);

        //Pitch: rotate pivot (up/down)
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void FixedUpdate()
    {

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        
        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();


        Vector3 moveDirection = camRight * moveInput.x + camForward * moveInput.y;
        
        if(moveDirection.sqrMagnitude > 1f)
        {
            moveDirection.Normalize();
        }

        Vector3 newPosition = rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}