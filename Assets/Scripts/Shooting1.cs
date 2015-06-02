using UnityEngine;
using System.Collections;

public class Shooting1 : MonoBehaviour {

    private float _time = 0;
    private float _cooldown = 0.5f;
    public GameObject Bullet;
	
	void Start () {
	    
	}

    void Update()
    {
        _time = _time + Time.deltaTime;
	    if(Input.GetAxisRaw("Trigger") >= 1.0f && _time >= _cooldown)
        {
            Shoot();
            _time = 0;
        }
	}

    void Shoot()
    {
        Instantiate(Bullet, this.transform.position, transform.rotation);
    }
}
