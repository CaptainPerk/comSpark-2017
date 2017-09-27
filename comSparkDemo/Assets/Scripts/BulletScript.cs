using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
        other.gameObject.SendMessage("BlowUp", SendMessageOptions.DontRequireReceiver);

        Destroy(gameObject);
    }
}
