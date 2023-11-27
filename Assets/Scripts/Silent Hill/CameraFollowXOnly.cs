using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollowXOnly : MonoBehaviour
{
    
    [SerializeField] private Transform _player;
    [SerializeField] private float _smoothness = 5.0f; // Suavidade do movimento da câmera
    private Vector3 _offset;
    

    void FixedUpdate()
    {
        if (_player is null)
            return;
        
        Vector3 targetPosition = transform.position;
        targetPosition.x = _player.position.x;

        // Lerp Towards
        transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothness * Time.deltaTime);
        
    }
}
