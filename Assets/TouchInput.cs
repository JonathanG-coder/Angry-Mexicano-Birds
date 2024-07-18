using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInput : MonoBehaviour
{
    private Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        Camera = Camera.main; // OT cette phrase ? 
        //Touchscreen.current.primaryTouch.press.IsPressed();
        //Touchscreen.current.primaryTouch.position.ReadValue();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Touchscreen.current.primaryTouch.position.ReadValue());
        Vector2 worldPosition = Camera.ScreenToWorldPoint(Touchscreen.current.primaryTouch.position.ReadValue());


        // // Out the method if not touching the screen
        // if (!Touchscreen.current.primaryTouch.press.IsPressed())
        // {
        //     return;
        // }

        // Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        // Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

        // Debug.Log("TOUCH POSITION: " + touchPosition);
        // Debug.Log("WORLD POSITION: " + worldPosition);
    }
}