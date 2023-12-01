using UnityEngine;


public class PlayerAnimationEvents : MonoBehaviour
{
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Spin()
    {
        _animator.SetTrigger("spin");
    }

    public void Punch()
    {
        _animator.SetTrigger("punch");
    }
    
}
