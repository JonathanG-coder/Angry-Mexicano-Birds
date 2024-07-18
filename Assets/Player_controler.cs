using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_controler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject ballPrefab;

    [SerializeField]private GameObject pivot;

    [SerializeField]private GameObject currentPrefab;
    [SerializeField] float detachDelayTime = 0.25F ;


    private Camera cam;
    private Rigidbody2D ballRigidBody;
    private SpringJoint2D ballSpringJoint;
    private bool isDragging = false;

    private Vector2 initialBalPosition;


    void Start()
    {
        cam = Camera.main;
        SpawnBall

        ballRigidBody = currentBall.GetComponent<Rigidbody2D>();
        initialBalPosition = currentBallRigidBody.position;
        ballSpringJoint = currentBall.GetComponent<SpringJoint2D>();  


        //manque kkl chose 
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
                Invoke(nameof(RestartBall), 0.3F);
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

    private void RestartBall()
    {
        ballRigidBody.position = initialBalPosition;
        ballRigidBody.velocity = new Vector2(0,0);
        ballSpringJoint.enabled = true ;
    }

    private void SpawnBall()
    {
        currentBall = Instantiate(ballPrefab, pivot.transform);
        ballSpringJoint.connectedBody= pivot.GetComponent<Rigidbody2D>();
    }
}
