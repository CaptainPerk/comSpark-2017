using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private GameObject enemyPrefab;

    public const float X_MIN_MAX = 6.0f;
    public const float Y_MIN_MAX = 4.5f;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-X_MIN_MAX, X_MIN_MAX), Random.Range(-Y_MIN_MAX, Y_MIN_MAX), 0.0f), Quaternion.identity);
        }

        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
