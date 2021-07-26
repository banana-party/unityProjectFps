using UnityEngine;

namespace Player
{
	/// <summary>
	/// Класс отвечающий за передвижение персонажа с помощью CharacterController
	/// </summary>
	[RequireComponent(typeof(CharacterController))]
	public class PlayerControllerMovement : MonoBehaviour
	{
		[SerializeField] private GameData gameData;
		[SerializeField] private float jumpHeight = 3f;
		private CharacterController _controller;
		private Vector3 _fallVelocity;
		private float _gravity = -9.81f;

		void Start()
		{
			_controller = GetComponent<CharacterController>();
		}


		void Update()
		{
			if (_controller.isGrounded && _fallVelocity.y < 0)
			{
				_fallVelocity.y = -2f;
			}

			var x = Input.GetAxis("Horizontal");
			var z = Input.GetAxis("Vertical");
			Vector3 move = transform.right * x + transform.forward * z;

			_controller.Move(move * (gameData.MovementSpeed * Time.deltaTime));

			_fallVelocity.y += _gravity * Time.deltaTime;
			_controller.Move(_fallVelocity * Time.deltaTime);

			Jump(); //TODO: прыжок зависит от контроллера, так как есть fallVelocity, которая отвечает за падение
		}

		void Jump()
		{
			if (_controller.isGrounded && Input.GetButtonDown("Jump"))
			{
				_fallVelocity.y += Mathf.Sqrt(jumpHeight * -2 * _gravity);
			}
		}
	}
}
