using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
	[SerializeField] private TMP_Text insanityText;
	[SerializeField] private TMP_Text healthText;
	[SerializeField] private GameObject defeatScreen;

	private void Start()
	{
		GameManager.Instance.OnInsanityChange += OnInsanityChanged;
		GameManager.Instance.OnHealthChanged += OnHealthChanged;
		GameManager.Instance.OnEndGame += OnEndGame;
	}
	private void OnInsanityChanged(float _insanity)
	{
		insanityText.text = "Insanity: " + _insanity;
	}
	private void OnHealthChanged(int _hp)
	{
		healthText.text = "Health: " + _hp;
	}
	private void OnEndGame(bool _win)
	{
		switch (_win)
		{
			case true:
				
				break;
			case false:
				defeatScreen.SetActive(true);
				break;
		}
	}
}
