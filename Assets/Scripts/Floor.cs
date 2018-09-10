using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    [SerializeField]  private int SpeedForward = 5;
    [SerializeField]  private float resetPosition;
    [SerializeField]  private  float startPosition;
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.Translate(SpeedForward * Vector3.back * Time.deltaTime, Space.World);

        if (this.transform.localPosition.z <= resetPosition)
        {

            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, startPosition + 20);
            this.transform.position = newPos;
        }

    }
}
