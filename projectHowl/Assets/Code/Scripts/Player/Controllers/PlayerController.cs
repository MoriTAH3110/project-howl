using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [Header("PLAYER INPUT")]
    [SerializeField] public PlayerInput playerInput;

    [Header("MOVEMENT VARIABLES")]
    [SerializeField] float _speed = 500f;
    [SerializeField] float _fallingSpeedFactor = 0.5f;
    float _realSpeed;
    [SerializeField] float fallSpeedLerp = 10.0f;
    float fallSpeedT;
    [SerializeField] float _jumpForce = 2.5f;
    [SerializeField] int _maxJumps = 2;
    [SerializeField] int remainingJumps;
    [SerializeField] float _maxGroundSpeed = 10f;
    [SerializeField] float _maxFallSpeed = 10f;

    [Header("COLLISIONS")]
    [SerializeField] Vector3 rightCollisionOffset;
    [SerializeField] Vector3 leftCollisionOffset;
    [SerializeField] Vector3 groundCollisionOffset;
    [SerializeField] float collisionRadius = 2.5f;
    [SerializeField] bool onGround;
    [SerializeField] bool onLeftWall, onRightWall;

    [Header("LAYER MASKS")]
    [SerializeField] LayerMask groundLayer;


    Vector2 _movement;
    Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector3(_realSpeed * _movement.x, _rb.velocity.y, _rb.velocity.z);

        //Speed limits 
        if (Mathf.Abs(_rb.velocity.x) > _maxGroundSpeed)
        {
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxGroundSpeed);
        }

        if (_rb.velocity.y < 0f)
        {
            fallSpeedT += Time.fixedDeltaTime / fallSpeedLerp;
            _realSpeed = Mathf.Lerp(_speed, _speed * _fallingSpeedFactor, Mathf.Clamp(fallSpeedT, 0f, 1.0f));
        }
        else
        {
            _realSpeed = _speed;
        }

        if (_rb.velocity.y < -(_maxFallSpeed))
        {
            _rb.velocity = new Vector3(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y, -(_maxFallSpeed), 0f), _rb.velocity.z);
        }
    }

    void Update()
    {
        //Collisions
        onGround = Physics.OverlapSphere(transform.position + groundCollisionOffset, collisionRadius, groundLayer).Length > 0;
        onLeftWall = Physics.OverlapSphere(transform.position + leftCollisionOffset, collisionRadius, groundLayer).Length > 0;
        onRightWall = Physics.OverlapSphere(transform.position + rightCollisionOffset, collisionRadius, groundLayer).Length > 0;

        if (isGrounded() && _rb.velocity.y <= 0f)
        {
            remainingJumps = _maxJumps;
            fallSpeedT = 0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere((Vector3)transform.position + groundCollisionOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector3)transform.position + rightCollisionOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector3)transform.position + leftCollisionOffset, collisionRadius);
    }

    // Player Input
    public void OnMove(InputAction.CallbackContext ctx)
    {
        _movement.x = ctx.ReadValue<float>();

    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.started){
            if (isGrounded() || remainingJumps > 0)
            {
                _rb.velocity = new Vector3(_rb.velocity.x, _jumpForce, _rb.velocity.z);
                remainingJumps -= 1;
                fallSpeedT = 0f;
            }
        }
    }

    // Collisions
    bool isGrounded() => onGround | onLeftWall | onRightWall;

}
