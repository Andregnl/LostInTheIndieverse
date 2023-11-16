using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

	public enum SpawnState { SPAWNING, WAITING, COUNTING , FINISHING};

	[System.Serializable]
	public class Wave
	{
		public string name;
		public Transform[] enemy;
		public int[] count;
		public float rate;
		public bool randSpawn;
	}

	public Wave[] waves;
	private int nextWave = 0;
	public int NextWave
	{
		get { return nextWave + 1; }
	}

	public Transform[] spawnPoints;

	public float timeBetweenWaves = 5f;
	public bool loop;
	private float waveCountdown;
	public float WaveCountdown
	{
		get { return waveCountdown; }
	}

	private float searchCountdown = 1f;

	private SpawnState state = SpawnState.COUNTING;
	public SpawnState State
	{
		get { return state; }
	}

	void Start()
	{
		if (spawnPoints.Length == 0)
		{
			Debug.LogError("No spawn points referenced.");
		}

		waveCountdown = timeBetweenWaves;
	}

	void Update()
	{
		if (state == SpawnState.WAITING)
		{
			if (!EnemyIsAlive())
			{
				WaveCompleted();
			}
			else
			{
				return;
			}
		}

		if (waveCountdown <= 0)
		{
			if ((state != SpawnState.SPAWNING && state != SpawnState.FINISHING))
			{
				StartCoroutine( SpawnWave ( waves[nextWave] ) );
			}
		}
		else
		{
			waveCountdown -= Time.deltaTime;
		}
	}

	void WaveCompleted()
	{
		Debug.Log("Wave Completed!");

		state = SpawnState.COUNTING;
		waveCountdown = timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1)
		{
			if(loop){
				nextWave = 0;
			}
			else{
							state = SpawnState.FINISHING;
			}
		}
		else
		{
			nextWave++;
		}
	}

	bool EnemyIsAlive()
	{
		searchCountdown -= Time.deltaTime;
		if (searchCountdown <= 0f)
		{
			searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag("Enemy") == null)
			{
				return false;
			}
		}
		return true;
	}

	IEnumerator SpawnWave(Wave _wave)
	{
		Debug.Log("Spawning Wave: " + _wave.name);
		state = SpawnState.SPAWNING;

		for (int i = 0; i < _wave.enemy.Length; i++)
		{
			for (int j = 0; j < _wave.count[i]; j++)
			{
				SpawnEnemy(_wave.enemy[i], nextWave, _wave.randSpawn);
				yield return new WaitForSeconds( 1f/_wave.rate );
			}
		}

		state = SpawnState.WAITING;

		yield break;
	}

	void SpawnEnemy(Transform _enemy, int spawnIndex, bool rand = false)
	{
		//Debug.Log("Spawning Enemy: " + _enemy.name);
		if(rand)
		{
			Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];
			Transform enemy = Instantiate(_enemy, _sp.position, _sp.rotation);
			enemy.GetComponent<EnemyBasics>().SetDirection(_sp.GetComponent<Slot>().GetDirection());
			enemy.GetComponent<EnemyBasics>().SetRow(_sp.GetComponent<Slot>().GetRow());
		}
		else{
			if(spawnIndex == null) spawnIndex = 0;
			Transform _sp = spawnPoints[ spawnIndex ];
			Transform enemy = Instantiate(_enemy, _sp.position, _sp.rotation);
			enemy.GetComponent<EnemyBasics>().SetDirection(_sp.GetComponent<Slot>().GetDirection());
			enemy.GetComponent<EnemyBasics>().SetRow(_sp.GetComponent<Slot>().GetRow());			
		}
	}

}
