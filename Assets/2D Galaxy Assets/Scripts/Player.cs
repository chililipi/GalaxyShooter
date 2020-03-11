using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private GameObject _laserPrefab;

	[SerializeField]
	private float _fireRate = 0.25f;

	private float _canFire = 0.0f;

	[SerializeField]
	private float _speed = 5.0f;

	private void Start () {
		transform.position = new Vector3(0 ,0 ,0);
	}
	
	private void Update () {
		Movement();

		if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)){
			Shoot();	
		}
	}

	private void Movement() {
		float horizontalInput = Input.GetAxis("Horizontal");
		transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);

		float verticallInput = Input.GetAxis("Vertical");
		transform.Translate(Vector3.up  * _speed * verticallInput * Time.deltaTime);

		//verify Y
		if(transform.position.y > 0) {
			transform.position = new Vector3(transform.position.x,0,0);
		}else if(transform.position.y < -4.3f){
			transform.position = new Vector3(transform.position.x,-4.3f,0);
		}


		//verify X
		if (transform.position.x >= 9.7f) {
			transform.position = new Vector3(-9.6f,transform.position.y,0);
		}else if(transform.position.x <= -9.7f) {
			transform.position = new Vector3(9.6f,transform.position.y,0);
		}
	}

	private void Shoot() {
		if(Time.time > _canFire) {
			Instantiate( _laserPrefab, transform.position + new Vector3(0 , 0.90f , 0), Quaternion.identity);
			_canFire = Time.time + _fireRate;
		}
	}
}
