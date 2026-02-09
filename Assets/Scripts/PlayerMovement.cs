using UnityEditor.Callbacks;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb; 
    private Vector2 moveInput;                          
    
    [SerializeField] private float moveSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");// A/D
        float y = Input.GetAxisRaw("Vertical"); // WS

        moveInput = new Vector2(x,y);
        Debug.Log(moveInput);

    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        Vector3 newPostion = rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(newPostion);
    }
}