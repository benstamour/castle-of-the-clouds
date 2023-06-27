using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingPlatform : MonoBehaviour
{
	[SerializeField] public float rotateSpeed = -10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float rotateAmount = this.rotateSpeed*Time.deltaTime;
		gameObject.transform.Rotate(new Vector3(rotateAmount, 0f, 0f));
    }
}
