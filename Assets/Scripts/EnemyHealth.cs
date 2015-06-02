using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    private float _health = 100;

	void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "bullet")
        {
            _health -= 50;
        }
        if (_health <= 0)
        {
            Destroy(this.transform.parent.gameObject);
        }
	}

}
