using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CameraController : NetworkBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxCameraOffset;
    [SerializeField] private float _step;


    Rigidbody _body;
    Vector3 _baseCameraPosition;
    float _cameraOffset;

    void Start()
    {
        _body = GetComponent<Rigidbody>();

        if (!IsLocalPlayer) {
            _camera.gameObject.SetActive(false);
            return;
        }
        
        Cursor.visible = false;
        Camera.main.gameObject.SetActive(false);

        _baseCameraPosition = _camera.transform.localPosition;
        _cameraOffset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        
        Vector3 mouseAxis = GameInputcontroller.GetMouseAxis()*5;


        Quaternion bodyRot = gameObject.transform.rotation;
        bodyRot.eulerAngles += mouseAxis;

        bodyRot.eulerAngles = new Vector3(0, bodyRot.eulerAngles.y, 0);
        gameObject.transform.localRotation = bodyRot;
        
        Quaternion camRot = _camera.transform.rotation;
        camRot.eulerAngles += mouseAxis;

        camRot.eulerAngles = new Vector3(camRot.eulerAngles.x, bodyRot.eulerAngles.y, 0);
        _camera.transform.rotation = camRot;
    }
}
