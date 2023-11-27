using System;
using UnityEngine;
using UnityEngine.Splines;


public class SplineSync : MonoBehaviour
{

    [SerializeField] private GameObject _cinemaMood;
    private SplineAnimate _splineAnimate;
    private PlayerController _playerController;
    private Animator _animator;
    private static readonly int Walk = Animator.StringToHash("Walk");

    private bool _loggedAlready; 

    private void Awake()
    {
        _splineAnimate = GetComponent<SplineAnimate>();
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerController.CanControl = false;
        _animator.SetBool(Walk, true);
        _loggedAlready = false;
        
        Debug.Log("Player started the animated entrance.");
    }

    void Update()
    {
        bool finishedEntrance = !_splineAnimate.IsPlaying;
        if (finishedEntrance && !_loggedAlready)
        {
            _playerController.CanControl = true;
            _loggedAlready = true;
            Debug.Log("Player finished the animated entrance.");
            _cinemaMood?.GetComponent<Animator>().SetTrigger("Vanish");
        }
    }
    
}
