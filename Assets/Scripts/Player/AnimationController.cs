using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _body;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _animator.SetFloat("MoveSpeed", Mathf.Abs(_body.velocity.x)+Mathf.Abs(_body.velocity.z));
    }
}
