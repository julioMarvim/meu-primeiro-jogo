using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    [SerializeField] public float runSpeed = 8f;

    private Rigidbody2D rigidBody;
    private float initialSpeed;
    public bool IsRunning {get; private set;}
    public bool IsRolling {get; private set;}
    public Vector2 Direction {get; private set;}

    private void Start() 
    {
        rigidBody = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update() 
    {
        OnInput(); 
        OnRun();
        OnRolling();  
    }

    private void FixedUpdate() 
    {
        OnMove();
    }

    # region Moviment

    void OnInput()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove() 
    {
        rigidBody.MovePosition(rigidBody.position + Direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            IsRunning = true;
        }

        
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            IsRunning = false;
        }
    }

    void OnRolling()
    {
        if(Input.GetMouseButtonDown(1))
        {
            speed = runSpeed;
            IsRolling = true;
        }

        if(Input.GetMouseButtonUp(1))
        {
            speed = initialSpeed;
            IsRolling = false;
        }
    }

    # endregion
}