using UnityEngine;

namespace Player
{
	/// <summary>
	/// Класс отвечаюший за прыжок персонажа, без использования CharacterController
	/// </summary>
	public class Jump : MonoBehaviour
	{
		[SerializeField] private float jumpForce = 300f;
		[SerializeField] private bool isGrounded;
		private Rigidbody _rigidbody;
		private Collider _collider;

		void Start()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_collider = GetComponent<Collider>();
		}
		void Update()
		{
			isGrounded = IsGrounded();
			if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
			{
				_rigidbody.AddForce(Vector3.up * jumpForce);
			}
		}

		private bool IsGrounded()
		{
			return Physics.Raycast(_collider.bounds.center, Vector3.down, _collider.bounds.extents.y + 0.1f);
		}
	}
}
