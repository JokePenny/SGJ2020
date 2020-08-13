using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
	[SerializeField] private Button buttonSettings;
	[SerializeField] private Button buttonPlay;
	[SerializeField] private Button buttonShop;

	/// <summary>
	/// Вызывается при открытии окна
	/// </summary>
	public void OnShow()
	{

	}

	/// <summary>
	/// Вызывается при закрытии окна
	/// </summary>
	public void OnHide()
	{

	}

	private void Awake()
	{
		buttonSettings.onClick.AddListener(OnClickButtonSettings);
		buttonPlay.onClick.AddListener(OnClickButtonPlay);
		buttonShop.onClick.AddListener(OnClickButtonShop);
	}

	private void OnClickButtonSettings()
	{
		///TODO: Открывает окно настроек
	}

	private void OnClickButtonPlay()
	{
		///TODO: Открывает окно игры
	}

	private void OnClickButtonShop()
	{
		///TODO: Открывает окно магазина
	}
}
