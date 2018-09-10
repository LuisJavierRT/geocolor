using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoForms : MonoBehaviour {

    // Use this for initialization
    public Color[] colors = new Color[6];
    [SerializeField] private Mesh[] meshTypes = new Mesh[3];

    void Start () {
        this.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
        this.GetComponent<MeshFilter>().mesh = meshTypes[Random.Range(0, meshTypes.Length)];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
