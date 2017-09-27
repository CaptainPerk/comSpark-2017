using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField]
    private GameObject shotPrefab;
    private Transform shotSpawn;
    private const float COOLDOWN_TIME = 0.25f;
    private float cooldownRemaining;

    // Use this for initialization
    void Start () {
        shotSpawn = transform.Find("ShotSpawn");
    }
	
	// Update is called once per frame
	void Update () {
        if (cooldownRemaining > 0)
        {
            cooldownRemaining -= Time.deltaTime;
        }

        if (cooldownRemaining <= 0 && Input.GetKey("space"))
        {
            cooldownRemaining = COOLDOWN_TIME;

            // If ShotSpawn is missing from the object or children, use current position.
            var spawnPosition = shotSpawn != null ? shotSpawn.transform.position : transform.position;

            var shot = Instantiate(shotPrefab, spawnPosition, transform.rotation);
            shot.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 500.0f);

            Destroy(shot, 3.0f);
        }
    }
}
