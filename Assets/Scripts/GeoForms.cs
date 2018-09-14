using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoForms : MonoBehaviour {

    // Use this for initialization

    [SerializeField] private GameObject sparkle;
    [SerializeField] private GameObject remainsCube;
    [SerializeField] private GameObject remainsSphere;
    [SerializeField] private GameObject remainsCapsule;
    

    void Start () {
       
        //ParticleSystem ps = sparkle.GetComponent<ParticleSystem>();
        //var emision = ps.emission;
        //emision.enabled = false;
    }


    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        var newObj = new GameObject();

        Debug.Log(this.GetComponent<MeshFilter>().mesh.name);

        if(this.GetComponent<MeshFilter>().mesh.name == "Cube Instance")
        {
            newObj = Instantiate(remainsCube, transform.position, transform.rotation);
        }
        else if (this.GetComponent<MeshFilter>().mesh.name == "Sphere Instance")
        {
            newObj = Instantiate(remainsSphere, transform.position, transform.rotation);
        }
        else if (this.GetComponent<MeshFilter>().mesh.name == "Capsule Instance")
        {
            newObj = Instantiate(remainsCapsule, transform.position, transform.rotation);
        }
        

        foreach (Transform child in newObj.transform)
        {
            child.GetComponent<MeshRenderer>().material.SetColor("_Color", this.GetComponent<Renderer>().material.color);

        }
        //Debug.Log("SIIII");

        //ParticleSystem ps = sparkle.GetComponent<ParticleSystem>();
        //var emision = ps.emission;
        //emision.enabled = true;

        // StartCoroutine(stopSparkles());
    }

    //IEnumerator stopSparkles()
    //{
    //    yield return new WaitForSeconds(.4f);

    //    var particleSystem = sparkle.GetComponent<ParticleSystem>();
    //    var emision = particleSystem.emission;
    //    emision.enabled = true;

    //}
}
