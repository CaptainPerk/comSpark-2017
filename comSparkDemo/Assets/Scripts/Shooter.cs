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

        if (shotSpawn == null)
        {
            Debug.Log("Could not find 'ShotSpawn' game object related to transform.  Will use transform.position for future instantiations.");
        }

        if (shotPrefab == null)
        {
            Debug.Log("There is no shot prefab!");
        }
        else
        {
            if (shotPrefab.GetComponent<Rigidbody2D>() == null)
            {
                Debug.Log("There was no Rigidbody2D component on shot prefab.  Adding and setting gravity to 0.");
                shotPrefab.AddComponent<Rigidbody2D>().gravityScale = 0.0f;
            }
        }
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
