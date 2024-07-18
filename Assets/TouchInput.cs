using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInput : MonoBehaviour
{
    [SerializeField]private GameObject ball;
    private Camera cam;
    private Rigidbody2D ballRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; // OT cette phrase ?

        ballRigidBody = ball.GetComponent<Rigidbody2D>(); 
        //Touchscreen.current.primaryTouch.press.IsPressed();
        //Touchscreen.current.primaryTouch.position.ReadValue();
    }

    // Update is called once per frame
    void Update()
    {
        ballRigidBody = ball.GetComponent<Rigidbody2D>();



        if (!Touchscreen.current.primaryTouch.press.IsPressed())
        {

            Vector2 worldPosition = cam.ScreenToWorldPoint
            (Touchscreen.current.primaryTouch.position.ReadValue());


            ballRigidBody.isKinematic = true;
            ballRigidBody.position = worldPosition;
            
        }

        if(ballRigidBody != null)
        {
            ballRigidBody.isKinematic = false;
        }
        
        


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