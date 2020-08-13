using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : MonoBehaviour
{
	[SerializeField] private Button buttonWatchAds;
	[SerializeField] private Button buttonClose;
	[SerializeField] private Button buttonBuy;

	[Header("Скролл бар с персонажами")]
	[SerializeField] private Scrollbar scrollHumans;

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
		buttonWatchAds.onClick.AddListener(OnClickButtonWatchAds);
		buttonClose.onClick.AddListener(OnClickButtonClose);
		buttonBuy.onClick.AddListener(OnClickButtonBuy);
	}

	private void OnClickButtonClose()
	{
		///TODO: Закрытие окна
	}

	private void OnClickButtonWatchAds()
	{
		///TODO: Просмотр рекламы за валюту
	}

	private void OnClickButtonBuy()
	{
		///TODO: Покупка выбранного персонажа
	}
}
