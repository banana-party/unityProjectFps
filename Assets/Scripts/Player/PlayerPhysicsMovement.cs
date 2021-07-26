using UnityEngine;

namespace Player
{
	/// <summary>
	/// Класс отвечаюший за перемещение персонажа по физике, без использования CharacterController
	/// </summary>
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerPhysicsMovement : MonoBehaviour
	{
		[SerializeField] private GameData gameData;
		private float _movementSpeed;
		private Rigidbody _rb;
		private void Start()
		{
			GetComponent<Collider>().enabled = true;
			_rb = GetComponent<Rigidbody>();
			_rb.useGravity = true;
			_movementSpeed = gameData.MovementSpeed;
		}

		private void Update()
		{
			Move();
		}

		private void Move()
		{
			var x = Input.GetAxis("Horizontal");
			var z = Input.GetAxis("Vertical");
			//_rb.MovePosition(transform.position + Time.deltaTime * _movementSpeed * transform.TransformDirection(x, 0f, z));
			//_rb.position += Time.deltaTime * _movementSpeed * transform.TransformDirection(x, 0f, z);
			_rb.velocity = Time.deltaTime * _movementSpeed * transform.TransformDirection(x, 0f, z) * 50f;
			//Все три способа реализации передвижения требуют доработки
		}

	}
}
