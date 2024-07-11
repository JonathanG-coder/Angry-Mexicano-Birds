using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb; // Corrigé : Rigidbody2D au lieu de RigidBody2D
    private SpringJoint2D springJoint;
    private bool isPressed; // Déplacé en dehors de la méthode Start

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Corrigé : Rigidbody2D au lieu de RigidBody2D
        springJoint = GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false; // Corrigé : should be false instead of true
        rb.isKinematic = false;

        StartCoroutine("Release");
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(0.15f);
        springJoint.enabled = false;
    }
}
