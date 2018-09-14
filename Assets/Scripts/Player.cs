using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] private int SpeedRotation = 2;
    [SerializeField] private Mesh[] meshTypes = new Mesh[3];
    [SerializeField] private Text pointText;
    [SerializeField] private List<Color> colors = new List<Color>() { Color.red, Color.green, Color.blue };

    private MeshFilter mFilter;
    private Renderer mRenderer;
    private int pos = 1;
    private int selectedColor = 0;
    private int selectedMesh = 0;
    private Vector2 fp; // first finger position
    private Vector2 lp; // last finger position
    private float speedTextUp = 2f;
    private int defaultTextSize;
    private bool intermediateTimeFlag = false;

    private int score = 0;
    private List<Color> selectedColorList = new List<Color>() { Color.red, Color.green, Color.blue };
    private int multiplier = 10;
    private int coins = 0;


    // Use this for initialization
    void Start()
    {
        mFilter = GetComponent<MeshFilter>();
        mRenderer = GetComponent<Renderer>();
        mRenderer.material.color = colors[Random.Range(0, colors.Count)];
        pointText.enabled = false;
        defaultTextSize = pointText.fontSize;
    }


    private void checkMultiplier(Color GeometryColor)
    {
        for (int i = 0; i < selectedColorList.Count; i++)
        {
            if (selectedColorList[i] == GeometryColor)
            {
                selectedColorList.RemoveAt(i);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Point")
        {
            ScoreCoin();
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "GeometryForm")
        {
            if (other.gameObject.GetComponent<MeshFilter>().mesh.name == mFilter.mesh.name && other.gameObject.GetComponent<Renderer>().material.color == mRenderer.material.color)
            {
               
                other.gameObject.SetActive(false);

                if (selectedColorList.Count == 0)
                {
                    selectedColorList = new List<Color>() { Color.red, Color.green, Color.yellow, Color.blue };
                    ScorePointWithMultiplier();
                }
                else
                {
                    checkMultiplier(other.gameObject.GetComponent<Renderer>().material.color);
                    ScorePoint();
                }


                Debug.Log("Correcto");
            }
            else
            {
                other.gameObject.SetActive(false);
                selectedColorList = new List<Color>() { Color.red, Color.green, Color.blue };
                Debug.Log("Incorrecto");
            }
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
                
                mFilter.mesh = meshTypes[selectedMesh];
                if(selectedMesh == 2)
                {
                    selectedMesh = 0;
                }
                else
                {
                    selectedMesh++;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                mRenderer.material.color = colors[selectedColor];
                if(selectedColor == 2)
                {
                    selectedColor = 0;
                }
                else
                {
                    selectedColor++;
                }
            }
            
        }

        if (pointText.enabled == true && intermediateTimeFlag == true)
        {

            
            int scaledTextSize = pointText.fontSize - 1;
            pointText.fontSize = scaledTextSize;

        }
        

        intermediateTimeFlag = !intermediateTimeFlag;
    }

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

    public void HidePoint()
    {
        pointText.fontSize = this.defaultTextSize;
        pointText.enabled = false;
       
    }


    public void ScorePoint()
    {
        score++;
        pointText.text = "+" + score;
        pointText.color = mRenderer.material.color;
        pointText.enabled = true;
        Invoke("HidePoint", 2f);
    }

    public void ScorePointWithMultiplier()
    {
        score = score * multiplier;
        pointText.text = "RAIMBOW STREAK!!";
        pointText.color = mRenderer.material.color;
        pointText.enabled = true;
        Invoke("HidePoint", 2f);
    }

    public void ScoreCoin()
    {
        coins++;
    }


}