using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lightbug.LaserMachine;

public class AngelStatue : MonoBehaviour
{
	private bool angelTriggered = false;
	private float progress = 0f;
	private float progressEyes = 0f;
	private float duration = 5f;
	private GameObject character;
	public Material eyeMaterial;
	public Material fogBarrierMaterial;
	private int stage = 0;
	private float time = 0f;
	
    // Start is called before the first frame update
    void Start()
    {
		eyeMaterial.SetFloat("_Translucency", 0);
		eyeMaterial.SetFloat("_EmissionPower", 0);
		fogBarrierMaterial.SetFloat("_Density", 0);
    }

    // Update is called once per frame
    void Update()
    {
		this.character = GameObject.FindWithTag("Character");
		float distance = Vector3.Distance(transform.position, this.character.transform.position);
        if(this.angelTriggered && distance <= 50)
		{
			if(this.stage == 0)
			{
				// rotate statue
				Quaternion lookRotation = Quaternion.LookRotation(character.transform.position - gameObject.transform.position);
				lookRotation.x = 0;
				lookRotation.z = 0;
				Quaternion offset = Quaternion.Euler(0,45,0);
				
				if(((lookRotation*offset).eulerAngles - gameObject.transform.rotation.eulerAngles).magnitude >= 0.01)
				{
					gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, lookRotation*offset, progress/duration);
					this.progress += Time.deltaTime;
				}
				else
				{
					this.progress = 0;
				}
				
				// rotate eyes/lasers
				GameObject guide = gameObject.transform.Find("Guiding Sphere").gameObject;
				GameObject leftEye = gameObject.transform.Find("Left Eye").gameObject;
				GameObject rightEye = gameObject.transform.Find("Right Eye").gameObject;
				//GameObject charTarget = GameObject.FindWithTag("Target").gameObject;
				lookRotation = Quaternion.LookRotation(character.transform.position - guide.transform.position);
				offset = Quaternion.Euler(82.5f,-17.5f,0);
				if(((lookRotation*offset).eulerAngles - guide.transform.rotation.eulerAngles).magnitude >= 0.01)
				{
					guide.transform.rotation = Quaternion.Slerp(guide.transform.rotation, lookRotation*offset, progressEyes/duration);
					leftEye.transform.rotation = Quaternion.Slerp(leftEye.transform.rotation, lookRotation*offset, progressEyes/duration);
					rightEye.transform.rotation = Quaternion.Slerp(rightEye.transform.rotation, lookRotation*offset, progressEyes/duration);
					this.progressEyes += Time.deltaTime;
				}
				
				this.time += Time.deltaTime;
				if(this.time >= 0.5)
				{
					this.progress = 0;
					this.progressEyes = 0;
					this.stage++;
					this.time = 0;
				}
			}
			else if(this.stage == 1)
			{
				eyeMaterial.SetFloat("_EmissionPower", this.time*4);
				
				this.time += Time.deltaTime;
				if(this.time >= 1)
				{
					this.stage++;
					this.time = 0;
				}
			}
			else if(this.stage == 2)
			{
				GameObject leftEye = gameObject.transform.Find("Left Eye").gameObject;
				GameObject rightEye = gameObject.transform.Find("Right Eye").gameObject;
				GameObject leftLaser = leftEye.transform.Find("Left Purple Laser").gameObject;
				GameObject rightLaser = rightEye.transform.Find("Right Purple Laser").gameObject;
				
				leftLaser.GetComponent<LaserMachine>().enabled = true;
				rightLaser.GetComponent<LaserMachine>().enabled = true;
				
				this.time += Time.deltaTime;
				if(this.time >= 1)
				{
					this.stage = 0;
					this.time = 0;
					this.progress = 0;
					eyeMaterial.SetFloat("_EmissionPower", 0);
					
					leftLaser.GetComponent<LaserMachine>().RemoveLasers();
					rightLaser.GetComponent<LaserMachine>().RemoveLasers();
					leftLaser.GetComponent<LaserMachine>().enabled = false;
					rightLaser.GetComponent<LaserMachine>().enabled = false;
					Destroy(leftLaser.transform.Find("lineRenderer_0").gameObject);
					Destroy(rightLaser.transform.Find("lineRenderer_0").gameObject);
				}
			}
		}
    }
	
	public void triggerAngel()
	{
		this.angelTriggered = true;
		eyeMaterial.SetFloat("_Translucency", 15);
		StartCoroutine(disperseFog());
	}
	
	IEnumerator disperseFog()
	{
		float density = fogBarrierMaterial.GetFloat("_Density");
		while(density < 2)
		{
			density += Time.deltaTime;
			fogBarrierMaterial.SetFloat("_Density", density);
			yield return null;
		}
		Collider fogCollider = GameObject.Find("Fog Barrier").GetComponent<Collider>();
		fogCollider.enabled = false;
	}
}
