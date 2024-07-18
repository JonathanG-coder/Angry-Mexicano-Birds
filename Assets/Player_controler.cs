using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_controler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject ball;
    [SerializeField] float detachDelayTime = 0.25F ;


    private Camera cam;
    private Rigidbody2D ballRigidBody;
    private SpringJoint2D ballSpringJoint;
    private bool isDragging = false;


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
        if (!Touchscreen.current.primaryTouch.press.IsPressed())
        {
            Debug.Log("Je touche pas");
            ballRigidBody.isKinematic = false;
            if(isDragging) 
            {
                Invoke(nameof(DetachBall), detachDelayTime);
                isDragging = false;
            }

            return;
        }

        isDragging = true;
        ballRigidBody.isKinematic = true;
        Vector2 worldPosition = cam.ScreenToWorldPoint
            (Touchscreen.current.primaryTouch.position.ReadValue());
        ballRigidBody.position = worldPosition;

    }

    private void DetachBall()
    {
        ballSpringJoint.enabled = false;
    }
}
