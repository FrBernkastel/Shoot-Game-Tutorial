using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;  // hold a container for all enemies.

	// Start is called before the first frame update
	void Start()
    {
        StartCoroutine(SpawnRoutine(0.5f));
    }

    // Update is called once per frame
    void Update()
    {
       
    }


	// spawn enemy every 5 seconds
	// Create a coroutine of type IEnumerator -- Yield Events
	IEnumerator SpawnRoutine(float waittime)
	{
        while (!GlobleMono.isDead)
        {
            float randomX = Random.Range(-GlobleMono.screenWidth, GlobleMono.screenWidth);
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(randomX, GlobleMono.screenHeight, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(waittime);
        }
    }
    
}
