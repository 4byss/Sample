using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    float trueSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float gravity = -9.8f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDist = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public float maxSprintDuration = 650f;
    float sprintRemaining = 650f;

    public TextMeshProUGUI sprintRemainingText;

    Animator anim;

    void Start() {
        trueSpeed = walkSpeed;
        anim = GetComponentInChildren<Animator>();
    }

    void Update() {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3(horizontal, 0f, 0f);

        if(Input.GetKey(KeyCode.LeftShift) && sprintRemaining > 0) {
            anim.SetBool("Run", true);
            sprintRemaining -= 1f;
            sprintRemainingText.text = sprintRemaining.ToString();
            trueSpeed = sprintSpeed;
        }
        else {
            trueSpeed = walkSpeed;
            anim.SetBool("Run", false);
        }

        if(direction.magnitude >= 0.1f) {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            // float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            controller.Move(direction * trueSpeed * Time.deltaTime);
            anim.SetBool("Walk", true);
        }
        else {
            anim.SetBool("Walk", false);
        }
    }
}
