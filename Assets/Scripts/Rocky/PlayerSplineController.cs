using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerSplineController : MonoBehaviour
{

    [SerializeField] private float _stopAt = 3.4f;
    [SerializeField] private AnimationClip _punchClip;
    
    private SplineAnimate _splineAnimate;
    private PlayerAnimationEvents _playerAnimationEvents;
    private bool _dirty = false;
    
    private void Awake()
    {
        _dirty = false;
        _splineAnimate = GetComponent<SplineAnimate>();
    }

    private void Start()
    {
        _playerAnimationEvents = GetComponent<PlayerAnimationEvents>();
    }

    void Update()
    {
        if (!_dirty && _splineAnimate.ElapsedTime >= _stopAt)
        {
            _dirty = true;
            _splineAnimate.Pause();
            _playerAnimationEvents.Punch();
            Invoke(nameof(BackToWalk), _punchClip.length);
        }
    }

    private void BackToWalk()
    {
        _splineAnimate.Play();
    }
    
}
