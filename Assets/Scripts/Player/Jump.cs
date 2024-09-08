using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Jump : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _jumpForce;
    private bool _isJumping;
    private bool _onGround;

    private Rigidbody _body;

    private void Awake() {
        _body = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision other) {
        _onGround = false;
        foreach (ContactPoint cont in other.contacts) {
            if (cont.normal.y > 0.5f) {
                _onGround = true;
                _isJumping = false;
            }
        }
    }

    private void OnCollisionExit(Collision other) {
        _onGround = false;
    }

    void Update()
    {
        if (!IsOwner) return;
        
        if (GameInputcontroller.GetJumpButton() && !_isJumping && _onGround) {
            _onGround = false;
            _isJumping = true;
            _body.velocity = new Vector3(_body.velocity.x, _jumpForce, _body.velocity.z);
        }

    }
}
