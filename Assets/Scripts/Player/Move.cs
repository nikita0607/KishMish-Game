using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Move : NetworkBehaviour
{
    [SerializeField] private float speedMultiplier;
    private CapsuleCollider _collider;
    private Rigidbody _body;

    private void Awake() {
        _body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!IsOwner) return;
        Vector3 forward = gameObject.transform.forward;
        Vector3 moveAxis = GameInputcontroller.GetMoveAxis();

        Vector3 velocity = Vector3.RotateTowards(Vector3.forward*moveAxis.z, forward, 10, 0) * moveAxis.z;
        velocity += Vector3.RotateTowards(Vector3.forward*moveAxis.x, gameObject.transform.right, 10, 0) * moveAxis.x;
        
        float yVelocity = _body.velocity.y;

        velocity = velocity.normalized*speedMultiplier;
        velocity.y = yVelocity;
        _body.velocity = velocity;
    }
}
