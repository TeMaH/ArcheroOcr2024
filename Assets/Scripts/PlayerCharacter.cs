using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(MovementComponent))]
public class PlayerCharacter : MonoBehaviour
{
    private PlayerInput playerInput;
    private MovementComponent movementComponent;
    
    private void Awake()
    {
        playerInput =  GetComponent<PlayerInput>();
        movementComponent = GetComponent<MovementComponent>();
    }
    private void Update()
    {
        Vector2 moveInput = playerInput.MoveInput;
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);
        movementComponent.Move(movement);
    }

}
