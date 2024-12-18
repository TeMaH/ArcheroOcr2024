using UnityEngine;

public class MovementComponent: MonoBehaviour
{
    public float movementSpeed = 3f;
    public CharacterController characterController;

    private CharacterController Controller { get { return characterController = characterController ? characterController : GetComponent<CharacterController>(); } }
    
    public void Move(Vector3 movement)
    {
        Vector3 moveTo = movement * movementSpeed * Time.deltaTime;
        Controller.Move(moveTo);
    }
}
