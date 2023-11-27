using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{

    // Fields
    [SerializeField] private bool _canControl = true;
    [SerializeField] private float _moveSpeed = 3f; 
    [SerializeField] private float _rotSpeed = 2f;
    private float _verticalInput = 0;
    private float _horizontalInput = 0;
    
    // Component Fields
    private Rigidbody _rigidbody;
    private Animator _animator;
    
    // Animation Caching
    private static readonly int WalkCode = Animator.StringToHash("Walk");
    
    public bool CanControl
    {
        get => _canControl;
        set => _canControl = value;
    }
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    
    private  void Update()
    {
        if (!CanControl)
            return;
        UpdateInputs();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        if (!CanControl)
            return;
        RotatePlayer();
        MovePlayerForward();
    }

    private void UpdateInputs()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");
    }
    
    private void UpdateAnimation()
    {
        bool isMoving = _verticalInput != 0 || _horizontalInput != 0;
        _animator.SetBool(WalkCode, isMoving);
    }
    
    private void RotatePlayer()
    {
        // Increases the rotation on ht Y axis.
        Vector3 rotIncrement = Vector3.up * _rotSpeed * _horizontalInput;
        _rigidbody.angularVelocity = rotIncrement;
    }
    
    private void MovePlayerForward()
    {
        // Moves always forward only.
        if (_verticalInput > 0) _rigidbody.velocity = transform.forward * _moveSpeed * _verticalInput;
        else _rigidbody.velocity = Vector3.zero;
    }

}
