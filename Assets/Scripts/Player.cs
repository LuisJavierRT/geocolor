using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    [SerializeField] private int SpeedRotation = 2;
    [SerializeField] private int SpeedForward = 5;

    [SerializeField] private Color[] colors = new Color[6];
    [SerializeField] private Mesh[] meshTypes = new Mesh[3];

    private MeshFilter mFilter;
    private Renderer mRenderer;
    private int pos = 1;
    private Vector2 fp; // first finger position
    private Vector2 lp; // last finger position

    // Use this for initialization
    void Start()
    {
        mFilter = GetComponent<MeshFilter>();
        mRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
     
        if (other.gameObject.GetComponent<MeshFilter>().mesh.name == mFilter.mesh.name && other.gameObject.GetComponent<Renderer>().material.color == mRenderer.material.color)
        {
            Debug.Log("Correcto");
        }
        else
        {
            Debug.Log("Incorrecto");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Translate(SpeedForward * Vector3.forward * Time.deltaTime, Space.World);


        // If Mobile
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fp = touch.position;
                    lp = touch.position;
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    lp = touch.position;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    if ((fp.x - lp.x) > 80) // left swipe
                    {
                        SlideLeft();
                    }
                    else if ((fp.x - lp.x) < -80) // right swipe
                    {
                        SlideRight();
                    }
                    else if ((fp.y - lp.y) < -80) // up swipe
                    {
                        Debug.Log("up swipe here...");
                    }
                    else if ((fp.y - lp.y) > 80) // down swipe
                    {
                        Debug.Log("down swipe here...");
                    }
                }
            }
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        { // Else if Desktop
            if (Input.GetKeyDown(KeyCode.A))
            {
                SlideLeft();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                SlideRight();
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                mFilter.mesh = meshTypes[Random.Range(0, meshTypes.Length)];
            }
            if (Input.GetMouseButtonDown(1))
            {
                mRenderer.material.color = colors[Random.Range(0, colors.Length)];
            }
            
        }
    }


    // Call Translate on this transform passing SPEED * Direction * deltaTime

    public void SlideLeft()
    {
        if (pos == 1 || pos == 2)
        {
            this.transform.Translate(SpeedRotation * Vector3.left, Space.World);
            pos--;
        }
        
    }

    public void SlideRight()
    {
        if (pos == 0 || pos == 1)
        {
            this.transform.Translate(SpeedRotation * Vector3.right, Space.World);
            pos++;
        }
        
    }
}