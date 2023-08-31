using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelTriggerPlane : MonoBehaviour
{
	public GameObject angel;
	bool triggered = false;
	
    // Start is called before the first frame update
    void Start()
    {
        this.angel = GameObject.Find("angelStatue");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	// when player goes through trigger plane, laser lions are activated
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Character" && this.triggered == false)
		{
			this.triggered = true;
			AngelStatue angelStatueScript = this.angel.GetComponent<AngelStatue>();
			angelStatueScript.triggerAngel();
		}
	}
}
