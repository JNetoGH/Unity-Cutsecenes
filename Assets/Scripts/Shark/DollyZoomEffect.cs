using System;
using UnityEngine;

public class DollyEffect : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _fovSpeed;
    [SerializeField] private float _fovTarget;

    private Vector3 _initialPosition;
    private float _initialFov;
    
    private Vector3 _initialDistance;
    private Vector3 _direction;
    private Vector3 _destination;

    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        
        _initialPosition = transform.position;
        _initialFov = _camera.fieldOfView;
        
        transform.LookAt(_target);
        _initialDistance = _target.position - transform.position;
        _direction = -_initialDistance.normalized;
        _destination = transform.position + _direction * _maxDistance;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _destination, _moveSpeed * Time.deltaTime);
        _camera.fieldOfView = Mathf.MoveTowards(_camera.fieldOfView, _fovTarget, _fovSpeed * Time.deltaTime);

        bool hasAverred = transform.position == _destination;
        if (!hasAverred)
            return;
        transform.position = _initialPosition;
        _camera.fieldOfView = _initialFov;
    }
}