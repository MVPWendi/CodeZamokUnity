using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WendiPC : MonoBehaviour
{
    private CharacterController controller;
    public float gravity;
    public float jumppower = 10f;
    public float CheckRadius;
    public Transform GroundChecker;
    public LayerMask GroundMask;
    public float speed;
    private Vector3 move;
    private Vector3 velocity;
    private float SpeedMultiple = 2f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        velocity = Vector3.zero;
    }
    private bool isGrounded;


    private void Update()
    {
        isGrounded = Physics.CheckSphere(GroundChecker.position, CheckRadius, GroundMask);

        if (!isGrounded && velocity.y > -4)
        {
            velocity.y += -10f * Time.deltaTime;
        }
        if (!isGrounded && velocity.y <= 0)
        {
            velocity.y = -6f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = 10f;
            Debug.Log("Прыгаю");
        }
    }
    // Update is called once per frame

    void FixedUpdate()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && isGrounded)
        {
            controller.Move(move * Time.deltaTime * speed * SpeedMultiple);
        }
        else
        {
            controller.Move(move * Time.deltaTime * speed);
        }
        controller.Move(velocity * Time.deltaTime);
    }
}