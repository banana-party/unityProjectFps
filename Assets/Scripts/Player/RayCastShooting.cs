using System.Collections;
using Controllers;
using Enemies;
using UI.Controllers;
using UnityEngine;

namespace Player
{
	/// <summary>
	/// Класс отвечаюший за выстрелы по целям с использованием рейкаста
	/// </summary>
	[RequireComponent(typeof(AudioSource))]
	[RequireComponent(typeof(GunBulletsController))]
	public class RayCastShooting : MonoBehaviour
	{
		[Header("Parameters")]
		[SerializeField] private int damage = 3;
		[SerializeField] private float maxShootDistance = 100f;
		[Header("SFX")]
		[SerializeField] private AudioClip shootSound;
		[SerializeField] private AudioClip outOfAmmoSound;
		[SerializeField] private AudioClip reloadSound;

		private PauseMenu _pauseMenu;
		private RaycastHit _hit;
		private int _layerMask;
		private AudioSource _audioSource;
		private GunBulletsController _gunBulletsController;
		private Coroutine _reloadCoroutine;
		private bool _isReloading;
		private Animator _animator;

		private void Awake()
		{
			_pauseMenu = FindObjectOfType<PauseMenu>();
		}

		void Start()
		{
			_layerMask = 1 << gameObject.layer;
			_audioSource = GetComponent<AudioSource>();
			_gunBulletsController = GetComponent<GunBulletsController>();
			_gunBulletsController.onBulletsEnded += NoAmmo;
			_gunBulletsController.onBulletsChanged += Shoot;
			if (_reloadCoroutine != null)
				StopCoroutine(_reloadCoroutine);
			_isReloading = false;
			_animator = GetComponent<Animator>();
		}

		void Update()
		{
			if (_isReloading || _pauseMenu.IsPasued)
				return;
			if (Input.GetMouseButtonDown(0))
				_gunBulletsController.Shoot();
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _hit, maxShootDistance, ~_layerMask))
			{
				Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _hit.distance, Color.red);
			}
			if (Input.GetKeyDown(KeyCode.R) && !_gunBulletsController.IsEmpty) //Свойство IsEmpty введено для того что бы нельзя было перезаряжать оружие, если нет патронов в запасе
			{
				_reloadCoroutine = StartCoroutine(ReloadCoroutine());
			}
		}

		void Shoot(int bullets)
		{
			if (bullets + 1 > 0) // +1 из за префиксного инкремента в _gunBulletsController.Shoot();
			{
				_audioSource.PlayOneShot(shootSound);
				Shootable shootable = null;
				if (_hit.collider != null)
					_hit.collider.TryGetComponent(out shootable);
				if (shootable != null)
					shootable.TakeDamage(damage);
				if (_hit.rigidbody != null)
					_hit.rigidbody.AddForce(-_hit.normal * 300f); // 300 - сила отталкивания от выстрела
			}
		}
		private void NoAmmo()
		{
			_audioSource.PlayOneShot(outOfAmmoSound);
		}
		private IEnumerator ReloadCoroutine()
		{
			_isReloading = true;
			_animator.SetBool("Reloading", _isReloading);
			_audioSource.PlayOneShot(reloadSound);
			yield return new WaitForSeconds(reloadSound.length);
			_gunBulletsController.Reload();
			_isReloading = false;
			_animator.SetBool("Reloading", _isReloading);

		}
		private void OnDisable()
		{
			_gunBulletsController.onBulletsEnded -= NoAmmo;
			_gunBulletsController.onBulletsChanged -= Shoot;
		}
	}
}
