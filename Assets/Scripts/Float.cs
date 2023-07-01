using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
	[SerializeField] float distance = 0.25f;
	[SerializeField] float duration = 8f;
	[SerializeField] float rotateSpeed = 1f;
	float progress = 0f;
	bool direction = true;
	//float curOffset = 0f;
	Vector3 startPos;
	Vector3 topPos;
	Vector3 bottomPos;
	
    // Start is called before the first frame update
    void Start()
    {
        this.startPos = gameObject.transform.position;
		this.topPos = this.startPos + Vector3.up*this.distance;
		this.bottomPos = this.startPos + Vector3.down*this.distance;
		gameObject.transform.position = this.bottomPos;
    }

    // Update is called once per frame
    void Update()
    {
		float rotateAmount = this.rotateSpeed*Time.deltaTime;
		gameObject.transform.Rotate(new Vector3(0f, rotateAmount, 0f));
		if(this.direction)
		{
			//Vector3 change = Vector3.up * this.speed * Time.deltaTime;
			//gameObject.transform.position += change;
			/*this.curOffset += this.speed * Time.deltaTime;
			if(this.curOffset >= this.distance)
			{
				this.direction = !this.direction;
			}*/
			float t = this.progress/this.duration;
			t = t*t*(3f - t*2f);
			gameObject.transform.position = Vector3.Lerp(this.bottomPos, this.topPos, t);
			this.progress += Time.deltaTime;
			if((gameObject.transform.position - this.topPos).magnitude <= 0.001)
			{
				this.direction = !this.direction;
				this.progress = 0f;
			}
		}
		else
		{
			/*Vector3 change = Vector3.down * this.speed * Time.deltaTime;
			gameObject.transform.position += change;
			this.curOffset -= this.speed * Time.deltaTime;
			if(this.curOffset <= -this.distance)
			{
				this.direction = !this.direction;
			}*/
			float t = this.progress/this.duration;
			t = t*t*(3 - t*2);
			gameObject.transform.position = Vector3.Lerp(this.topPos, this.bottomPos, t);
			this.progress += Time.deltaTime;
			if((gameObject.transform.position - this.bottomPos).magnitude <= 0.001)
			{
				this.direction = !this.direction;
				this.progress = 0f;
			}
		}
    }
}
