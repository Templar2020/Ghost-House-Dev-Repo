using UnityEngine;
using System.Collections;

public class GhostAI : MonoBehaviour {

	public float moveSpeed;
	public Transform target;
	public int damage;

	
	
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.name == "Player"){
			Follow();
		}
		else{
			print("Ghost is grounded");
			Wander();
		}
	}

	void Wander(){

		transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
    	int randomNum = Random.Range(0,360);
    	Vector3 fwd = transform.TransformDirection(Vector3.forward);
    	RaycastHit hit;


    	Debug.DrawRay(transform.position,fwd*3,Color.red);

    	if(Physics.Raycast(transform.position,fwd,out hit,3)){

			if(hit.collider.tag == "Wall"){
				transform.Rotate(0,randomNum,0);
			}
		}	
	}

	void Follow(){
		transform.LookAt(target);
		transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
	}

	
	// void OnCollisionEnter(Collision other)
	// {
	// 	var hit = other.gameObject;
	// 	var health = hit.GetComponent<playerHealth>();

	// 	if(health != null){
	// 		health.TakeDamage(damage);
	// 	}	
	// }
}

