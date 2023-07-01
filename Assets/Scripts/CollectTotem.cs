using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTotem : MonoBehaviour
{
	[SerializeField] int id = 0;
	GameObject character;
	
    // Start is called before the first frame update
    void Start()
    {
        this.character = GameObject.FindWithTag("Character");
    }

    // Update is called once per frame
    void Update()
    {
		/*if(this.angelFollow)
		{
			GameObject angelStatue = GameObject.Find("angelStatue");
			Quaternion lookRotation = Quaternion.LookRotation(character.transform.position - angelStatue.transform.position);
			lookRotation.x = 0;
			lookRotation.z = 0;
			Quaternion offset = Quaternion.Euler(0,45,0);
			
			angelStatue.transform.rotation = Quaternion.Slerp(angelStatue.transform.rotation, lookRotation*offset, progress/duration);
			progress += Time.deltaTime;
		}*/
		
		float distance = Vector3.Distance(transform.position, character.transform.position);

		if(Input.GetKeyDown(KeyCode.E) && distance <= 3f)
		{
			if(this.id == 0) // air totem
			{
				Debug.Log("Air totem collected!");
				
				GameObject angelStatue = GameObject.Find("angelStatue");
				AngelStatue angelScript = angelStatue.GetComponent<AngelStatue>();
				//angelScript.setAngelFollow(true);
				angelScript.triggerAngel();
				
				//this.angelFollow = true;
				gameObject.SetActive(false);
			}
		}
    }
}
