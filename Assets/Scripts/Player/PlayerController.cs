using UnityEngine;

namespace Player
{
	/// <summary>
	/// Игрок является фасадом с использваонием CharacterController
	/// </summary>
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private PlayerControllerCamera camera;
		[SerializeField] private PlayerControllerMovement movement;
		[SerializeField] private RayCastShooting shooting;

		public PlayerControllerCamera Camera => camera;
		public PlayerControllerMovement Movement => movement;
		public RayCastShooting Shooting => shooting;

	}
}
