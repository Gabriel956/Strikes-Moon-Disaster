using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    private PlayerInput playerInput;
    private CharacterController characterController;

    private Vector2 curentMovementInput;
    private Vector3 currentMovement;

    private bool isAscending = false;
    private bool isDescending = false;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float elevationSpeed = 5f;

    void OnMove(InputValue inputValue)
    {
        curentMovementInput = inputValue.Get<Vector2>() * moveSpeed;
        Debug.Log("currentMovementInput = " + curentMovementInput);
        currentMovement.x = curentMovementInput.x;
        currentMovement.z = curentMovementInput.y;  // Player controls movement on xz plane
    }

    void OnChangeElevation(InputValue inputValue)
    {
        currentMovement.y = inputValue.Get<float>() * elevationSpeed;
        Debug.Log("changeElevation = " + inputValue.Get<float>());
    }

    void OnFire(InputValue inputValue)
    {
        Debug.Log("Fire!");
    }

    void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
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

}
