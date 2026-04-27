using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    private InputAction move;
    private Rigidbody rb;

    [SerializeField] private bool Grounded = true;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float rotSpeed = 30, speed = 20;

    [SerializeField] private Vector3 pushBack;

    [SerializeField] private bool didabledControl = false;

    [SerializeField] private float disableTime = 1;
    private float lastcollisionTime;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        rb = GetComponent<Rigidbody>();
      
    
    }

    private void OnEnable()
    {
        Obstacle.OnPlayerHit += TakeDamage;
    }
    void TakeDamage()
    {
        rb.AddForce(pushBack);
        didabledControl = true;
        lastcollisionTime = Time.timeSinceLevelLoad;
        
        Debug.Log("PLAYER GOT HURT");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > lastcollisionTime + disableTime)
            didabledControl = false;
        Grounded = Physics.Linecast(transform.position, transform.position + Vector3.down, groundMask); //checks only what in this layer mask

        Color lineCol = Grounded ? Color.green : Color.red; //check if player on ground and change color, same as if ( if yes ? else : )

        Debug.DrawLine(transform.position, transform.position + Vector3.down, lineCol);
        if (Grounded && !didabledControl)
        {
            Vector2 moveInput = move.ReadValue<Vector2>();
            //Debug.Log(" x: " + moveInput.x + " y: " + moveInput.y);

            transform.Rotate(0, -moveInput.x * rotSpeed * Time.fixedDeltaTime, 0);

            float turnAngle = Mathf.Abs(180 - transform.localEulerAngles.y);
            float speedMult = Mathf.Cos(turnAngle * Mathf.Deg2Rad);
            rb.AddForce(transform.forward * speed * Time.fixedDeltaTime);
        }
        
    }
}
