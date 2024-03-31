using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController2D characterController;

    [SerializeField] float speed;
    float horizontalMove = 0f;
    bool isJumping = false;
    bool isCrouching = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;    

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            isCrouching= false;
        }
    }

    /// <summary>
    /// Using fixed update to move the player  since it is not advised to move inside update
    /// </summary>
    private void FixedUpdate()
    {
        // Move the character
        characterController.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping);
        isJumping = false;
    }
}
