using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Player PlayerScript;
    private PlayerInputs Input = null;

    [SerializeField]
    private int MoveSpeed = 10;

    private Vector2 moveVector = Vector2.zero;

    public void Initialise(Player playerScript)
    {
        PlayerScript = playerScript;
        Input = new PlayerInputs();
        EnableMovement();
    }

    private void EnableMovement()
    {
        if(PlayerScript != null)
        {
            Input.Enable();
            Input.Player.Movement.performed += OnMovementPerformed;
            Input.Player.Movement.canceled += OnMovementCancelled;
        }
    }

    private void DisableMovement()
    {
        Input.Disable();
        Input.Player.Movement.performed -= OnMovementPerformed;
        Input.Player.Movement.canceled -= OnMovementCancelled;
    }

    private void OnDisable()
    {
        DisableMovement();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        PlayerScript.RigidBody.velocity = moveVector * MoveSpeed;
        PlayerScript.UpdateDirection(moveVector);
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
}
