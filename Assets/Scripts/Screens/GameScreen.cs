using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
	public static GameScreen Instance;
	[Header("Кнопка выхода в меню")]
	[SerializeField] private Button buttonMenu;

	[Header("Кнопки скилов")]
	[SerializeField] private Button buttonSkillTimeScale;
	[SerializeField] private Button buttonSkillGetAllEat;


	[Header("Прогресс бар до метеорита")]
	[SerializeField] private Slider sliderProgressToAsteroid;
	[SerializeField] private float startTimeToAstroid;

	[Range(0f, 5f)]
	[Header("Скорость замедления времени")]
	[SerializeField] private float speedShowSlowMotion;

	private float currentTimeToAsteroid;
	private float CurrentTimeToAsteroid
	{
		get
		{
			return currentTimeToAsteroid;
		}
		set
		{
			currentTimeToAsteroid = value;
			if(currentTimeToAsteroid < 0)
			{
				///TODO: вызов метода спавна метеорита
			}
		}
	}

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
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		buttonMenu.onClick.AddListener(OnClickButtonMenu);
		buttonSkillTimeScale.onClick.AddListener(OnClickButtonSkillTimeScale);
		buttonSkillGetAllEat.onClick.AddListener(OnClickButtonSkillGetAllEat);

		sliderProgressToAsteroid.onValueChanged.AddListener(OnValueChangeSliderToAsteroid);
	}

	private void OnClickButtonMenu()
	{
		///TODO: Закрытие игрового окна
	}

	private void OnClickButtonSkillTimeScale()
	{
		///TODO: Активация скила замедления времени
	}

	private void OnClickButtonSkillGetAllEat()
	{
		///TODO: Активация скила, которое выдает всем людям капусту
	}

	private void OnValueChangeSliderToAsteroid(float value)
	{
		CurrentTimeToAsteroid = value;
	}
}
