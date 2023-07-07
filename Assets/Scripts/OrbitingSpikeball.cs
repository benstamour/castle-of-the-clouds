using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingSpikeball : MonoBehaviour
{
	[SerializeField] public float orbitSpeed = -50f;
	[SerializeField] public Vector3 orbitAround = new Vector3(-49.5f, 12f, 14.75f);
	[SerializeField] public float tiltSpeed = 80f;
	private float totalRotation = 0;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotateAmount = this.orbitSpeed*Time.deltaTime;
		//float radius = 7.5f;
		//Vector3 offset = new Vector3(Mathf.Sin(rotateAmount), 0, Mathf.Cos(rotateAmount))*radius;
		//gameObject.transform.position = orbitAround + offset;
		gameObject.transform.RotateAround(orbitAround, Vector3.up, rotateAmount);
		this.totalRotation = (this.totalRotation + rotateAmount) % 360;
		//Debug.Log("Tile: " + gameObject.transform.position);
		float tiltAmount = this.tiltSpeed*Time.deltaTime;
		gameObject.transform.Rotate(new Vector3(tiltAmount, 0f, 0f));
		//gameObject.transform.Rotate(new Vector3(tiltAmount*Mathf.Sin(totalRotation), 0f, tiltAmount*Mathf.Cos(totalRotation)));
		//Debug.Log("sin: " + tiltAmount*Mathf.Sin(totalRotation));
		//Debug.Log("cos: " + tiltAmount*Mathf.Cos(totalRotation));
    }
}
