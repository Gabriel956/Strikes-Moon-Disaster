using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;

    Vector2 curentMovementInput;
    Vector3 currentMovement;

    void OnMovementInput(InputAction.CallbackContext context)
    {
        curentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = curentMovementInput.x;
        currentMovement.z = curentMovementInput.y;  // Player controls movement on xz plane
    }

    void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();

        playerInput.CharacterControls.Move.started += OnMovementInput;
        playerInput.CharacterControls.Move.canceled += OnMovementInput;
        playerInput.CharacterControls.Move.performed += OnMovementInput;
    }

    void OnEnable()
    {
        playerInput.CharacterControls.Enable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move(currentMovement * Time.deltaTime);
    }

    void OnDisable()
    {
        playerInput.CharacterControls.Disable();
    }
}
