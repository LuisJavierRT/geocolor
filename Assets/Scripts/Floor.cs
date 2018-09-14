using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    [SerializeField] private int SpeedForward = 5;
    [SerializeField] private float resetPosition;
    [SerializeField] private float startPosition;
    private List<Color> colors = new List<Color>() { Color.red, Color.green, Color.blue };
    [SerializeField] private List<Mesh> meshTypes = new List<Mesh>();

    [SerializeField] private float timeBeforeIncSpeed = 20.0f;
 
    private GameObject[] points;

    public GameObject pointSprite;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    [SerializeField] public GameObject[] spawnPoints = new GameObject[18];         // An array of the spawn points this enemy can spawn from.

    private List<Mesh> meshTypesDefault =  new List<Mesh>();
    private List<Color> meshColorDefault = new List<Color>();

    // Use this for initialization
    void Start () {
         // InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Awake()
    {
        meshTypesDefault = new List<Mesh>(meshTypes);
        meshColorDefault = new List<Color>(colors);
        SpawnForms();
        SpawnCoins();
    }

    // Update is called once per frame
    void FixedUpdate () {
        this.transform.Translate(SpeedForward * Vector3.back * Time.deltaTime, Space.World);

        if (this.transform.localPosition.z <= resetPosition)
        {
    
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, startPosition +20);
            this.transform.position = newPos;

            DestroyPoints();

            SpawnForms();
            SpawnCoins();
            
        }

        timeBeforeIncSpeed -= Time.deltaTime;
        if (timeBeforeIncSpeed < 0)
        {
            this.SpeedForward+=5;
            timeBeforeIncSpeed = 20.0f;
        }
    }

    void SpawnForms()
    {
        foreach (Transform child in transform)
        {
            //child is your child transform

            if (child.gameObject.name == "Cube" ) {

                child.gameObject.SetActive(true);

                var randomMesh = Random.Range(0, meshTypes.Count);
                child.gameObject.GetComponent<MeshFilter>().mesh = meshTypes[randomMesh];
                meshTypes.RemoveAt(randomMesh); 

                var randomColor = Random.Range(0, colors.Count);
                child.gameObject.GetComponent<Renderer>().material.color = colors[randomColor];
                colors.RemoveAt(randomColor);

            }
            else if(child.gameObject.name == "Sphere")
            {
                child.gameObject.SetActive(true);

                var randomMesh = Random.Range(0, meshTypes.Count);
                child.gameObject.GetComponent<MeshFilter>().mesh = meshTypes[randomMesh];
                meshTypes.RemoveAt(randomMesh);

                var randomColor = Random.Range(0, colors.Count);
                child.gameObject.GetComponent<Renderer>().material.color = colors[randomColor];
                colors.RemoveAt(randomColor);
            }
            else if(child.gameObject.name == "Capsule")
            {
                child.gameObject.SetActive(true);

                var randomMesh = Random.Range(0, meshTypes.Count);
                child.gameObject.GetComponent<MeshFilter>().mesh = meshTypes[randomMesh];
                meshTypes.RemoveAt(randomMesh);

                var randomColor = Random.Range(0, colors.Count);
                child.gameObject.GetComponent<Renderer>().material.color = colors[randomColor];
                colors.RemoveAt(randomColor);
            }
        }

        meshTypes = new List<Mesh>(meshTypesDefault);
        colors = new List<Color>(meshColorDefault);
    }

    void SpawnCoins()
    {

        points = new GameObject[1];
        for (int i = 0; i < points.Length; i++)
        {
           
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);


            GameObject point = (GameObject)Instantiate(pointSprite, spawnPoints[spawnPointIndex].gameObject.transform.position, spawnPoints[spawnPointIndex].gameObject.transform.rotation);


            point.transform.SetParent(this.transform);

           
            points[i] = point;
        }

    }

    void DestroyPoints()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Destroy(points[i]);
        }
    }
}
