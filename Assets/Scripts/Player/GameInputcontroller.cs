using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputcontroller 
{
    public static Vector3 GetMoveAxis() {
        return new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    public static Vector3 GetMouseAxis() {
        return new Vector3(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"));
    }

    public static bool GetJumpButton() {
        return Input.GetButtonDown("Jump");
    }
}
