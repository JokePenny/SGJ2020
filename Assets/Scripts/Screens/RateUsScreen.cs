using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RateUsScreen : MonoBehaviour
{
	[SerializeField] private Button buttonClose;
	[SerializeField] private Button buttonRate;

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
		buttonClose.onClick.AddListener(OnClickButtonClose);
		buttonRate.onClick.AddListener(OnClickButtonRate);
	}

	private void OnClickButtonClose()
	{
		///TODO: Закрытие окна
	}

	private void OnClickButtonRate()
	{
		///TODO: Закрытие окна и переход на страницу гугла/эпл стора
	}
}
