using UnityEngine;

public class EnemyPool : InstanceFactory<EnemyPool>
{
	[SerializeField] private GameObject[] enemyPrefabs = new GameObject[3];
	private GameObject[] enemies = new GameObject[100];
	private int enemyIndex = 0;
	protected override void Awake()
	{
		base.Awake();
		for (int i = 0; i < enemies.Length; ++i)
		{
			int _enemyIndex = Random.Range(0, enemyPrefabs.Length);
			enemies[i] = Instantiate(enemyPrefabs[_enemyIndex], Vector3.zero, Quaternion.identity, transform);
			enemies[i].SetActive(false);
		}
	}
	public void GetEnemy()
	{
		//get an enemy from the pool
		//Debug.Log("Enemy");
		enemies[enemyIndex].SetActive(true);
		enemies[enemyIndex].transform.position = new Vector3(10, 0, Random.Range(-2, 3));
		enemyIndex = (enemyIndex + 1) % enemies.Length;
	}
}
