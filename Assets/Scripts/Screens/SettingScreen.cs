using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingScreen : MonoBehaviour
{
	[SerializeField] private Button buttonPrivacyPolicy;
	[SerializeField] private Button buttonVibrationOn;
	[SerializeField] private Button buttonBuyNoAds;
	[SerializeField] private Button buttonSoundOn;
	[SerializeField] private Button buttonClose;
	[SerializeField] private Button buttonTerms;
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
		buttonPrivacyPolicy.onClick.AddListener(OnClickButtonPrivacyPolicy);
		buttonVibrationOn.onClick.AddListener(OnClickButtonVibrationOn);
		buttonBuyNoAds.onClick.AddListener(OnClickButtonBuyNoAds);
		buttonSoundOn.onClick.AddListener(OnClickButtonSoundOn);
		buttonClose.onClick.AddListener(OnClickButtonClose);
		buttonTerms.onClick.AddListener(OnClickButtonTerms);
		buttonRate.onClick.AddListener(OnClickButtonRate);
	}

	private void OnClickButtonClose()
	{
		///TODO: Закрытие окна
	}

	private void OnClickButtonRate()
	{
		///TODO: Переход на страницу гугла/эпл стора
	}

	private void OnClickButtonTerms()
	{
		///TODO: Переход на страницу правил (git)
	}

	private void OnClickButtonSoundOn()
	{
		///TODO: Выключить/Включить звуки
	}

	private void OnClickButtonVibrationOn()
	{
		///TODO: Выключить/Включить вибрацию
	}

	private void OnClickButtonPrivacyPolicy()
	{
		///TODO: Переход на страницу политики конфендициальности (git)
	}

	private void OnClickButtonBuyNoAds()
	{
		///TODO: Отключение рекламы при покупке за 0.99$
	}
}
