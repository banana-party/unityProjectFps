using System;
using UnityEngine;
/// <summary>
/// Класс отвечающий за паузу в игре по нажатию ESC
/// </summary>
public class PauseMenu : MonoBehaviour
{
	private Canvas _canvas;
	public Action<bool> GamePaused = delegate { };
	private bool _isPaused;
	public bool IsPasued
	{
		get => _isPaused;
		private set
		{
			_isPaused = value;
			GamePaused.Invoke(value);
		}
	}

	private void Start()
	{
		_canvas = GetComponent<Canvas>();
		_canvas.enabled = false;
		IsPasued = Time.timeScale == 0;
		if (IsPasued) // Проверка на всякий случай
			UnPause();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && !IsPasued)
			Pause();
		else if (Input.GetKeyDown(KeyCode.Escape) && IsPasued)
			UnPause();
	}

	private void Pause()
	{
		Time.timeScale = 0f;
		Cursor.lockState = CursorLockMode.Confined;
		_canvas.enabled = IsPasued = true;

	}
	private void UnPause()
	{
		Time.timeScale = 1f;
		Cursor.lockState = CursorLockMode.Locked;
		_canvas.enabled = IsPasued = false;
	}
}
