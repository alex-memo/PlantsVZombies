using UnityEngine;
using System.Collections;

public class GameManager : InstanceFactory<GameManager>
{
	[field: SerializeField] public GameObject BulletPrefab { get; private set; }
	[field: SerializeField] public GameObject EnemyBulletPrefab { get; private set; }
	private float insanity = 0;
	public OnInsanityChange OnInsanityChange;
	public OnEndGame OnEndGame;
	public OnHealthChanged OnHealthChanged;
	private int round = 1;
	private void Start()
	{
		StartCoroutine(rounds());
		OnEndGame += EndGame;
	}
	private IEnumerator rounds()
	{
		while (true)
		{
			for(int i = 0; i < round; ++i)
			{
				EnemyPool.Instance.GetEnemy();
			}
			++round;
			yield return new WaitForSeconds(5);
		}
	}
	public void AddInsanity(float _insanity)
	{
		insanity += _insanity;
		OnInsanityChange?.Invoke(insanity);
	}
	public void EndGame(bool _win)
	{
		StopAllCoroutines();
		switch (_win)
		{
			case true:
				Debug.Log("Victory");
				break;
			case false:
				Debug.Log("Defeat");
				break;
		}	
	}

}
public delegate void OnInsanityChange(float _insanity);
public delegate void OnHealthChanged(int _health);
public delegate void OnEndGame(bool _win);