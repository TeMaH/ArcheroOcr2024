using UnityEngine;
public class Hero : BaseCharacter
{
   private PlayerInput _playerInput;
   private Vector3 _moveDir;
   private MovementComponent _movementComponent;
   
   protected override void Start()
   {
      base.Start();
      
      _movementComponent = GetMovementComponent();
      _playerInput = _playerInput ? _playerInput : GetComponent<PlayerInput>();

      _playerInput.OnMove += OnMove;
   }

   private void Update()
   {
      if (_moveDir != Vector3.zero)
      {
         _movementComponent.Move(_moveDir);
      }
   }
   
   private void OnMove(Vector2 direction)
   {
      _moveDir = new Vector3(direction.x, 0, direction.y);
   }

   private void OnDestroy()
   {
      _playerInput.OnMove -= OnMove;
   }
}
