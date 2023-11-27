using UnityEngine;

public class CameraHeightController : MonoBehaviour
{
    
    [SerializeField] private Transform _player; 
    [SerializeField] private float _minHeight = 2f; // Minimum height of the camera
    [SerializeField] private float _maxHeight = 10f; // Maximum height of the camera
    [SerializeField] private float _distanceFactor = 1.5f; // Affects the rate of change of camera height

    private Vector3 _initialOffset; 
    
    void Start()
    {
        _player = FindObjectOfType<PlayerController>()?.transform;
        if (_player != null)
            _initialOffset = transform.position - _player.position;
    }

    void Update()
    {
        if (_player is null)
            return;
        
        // Gets the horizontal (XZ) distance between camera and player
        Vector3 playerPosition = new Vector3(_player.position.x, transform.position.y, _player.position.z);
        float distance = Vector3.Distance(playerPosition, transform.position);

        // Calculates the new height based on distance (inverted)
        float targetHeight = Mathf.Clamp((_maxHeight - distance * _distanceFactor), _minHeight, _maxHeight);

        // Sets the camera's position with the new height
        Vector3 newPosition = transform.position;
        newPosition.y = targetHeight;
        transform.position = newPosition;
    }

    private void OnDrawGizmos()
    {
        // Draw gizmos for minimum and maximum height points
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(new Vector3(transform.position.x, _minHeight, transform.position.z), 0.3f); // Draw min height point
        
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(transform.position.x, _maxHeight, transform.position.z), 0.3f); // Draw max height point
    }
    
}