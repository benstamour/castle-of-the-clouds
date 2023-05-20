using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for when player is on a special object
public class CharacterPlatform : MonoBehaviour
{	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
		{
			// character should follow moving tiles when they are on top of them
			if((hit.collider.gameObject.tag == "RisingTile") && hit.distance <= 0.1)
			{
				gameObject.transform.parent = hit.collider.gameObject.transform;
			}
			else
			{
				gameObject.transform.parent = null;
			}
		}
		else
		{
			gameObject.transform.parent = null;
		}
	}
}
