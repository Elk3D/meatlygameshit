using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField]
	private MoveSettings _settings;

	private Vector3 _moveDirection;

	private CharacterController _controller;

	private void Awake()
	{
		_controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		DefaultMovement();
	}

	private void FixedUpdate()
	{
		_controller.Move(_moveDirection * Time.deltaTime);
	}

	private void DefaultMovement()
	{
		if (_controller.isGrounded)
		{
			Vector2 vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			if (vector.x != 0f && vector.y != 0f)
			{
				vector *= 0.777f;
			}
			_moveDirection.x = vector.x * _settings.speed;
			_moveDirection.z = vector.y * _settings.speed;
			_moveDirection.y = 0f - _settings.antiBump;
			_moveDirection = base.transform.TransformDirection(_moveDirection);
			Input.GetKey(KeyCode.Space);
			Input.GetKey(KeyCode.JoystickButton0);
		}
		else
		{
			_moveDirection.y -= _settings.gravity * Time.deltaTime;
		}
	}

	private void Jump()
	{
		_moveDirection.y += _settings.jumpForce;
	}
}
