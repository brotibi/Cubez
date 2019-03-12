using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cubeController : MonoBehaviour {

    public static float cubeRotationSpeed = 0f;
    CharacterController controller;
    Vector3 position;

    private static float speed = 10;
    public float maxPos = 3.0f;
    private Camera camera;
    private bool isPlaying;
    private float camAngle = 0.0f;

    private GameControlScript control;

    private Rigidbody myBody;
    private Renderer rend;
    private BoxCollider box;

    private bool canFade = false;
    private Color alphaColor;
    private float timeToFade = 1.0f;

    public Text rightButton;
    public Text leftButton;
    public Text healthText;

    public GameObject Buttons;
    public GameObject selectCubeBttn;

    public Mesh defaultCube;
    public Mesh cubo;
    public Mesh witchCube;
    public Material cubeMat;
    public Material green;

    public Mesh cube;
    public Mesh cube2;
    private int cubeNumber;

    private int health = 100;
    public Text coinsText;
    private int coins;
    public int touches = 0;

    // Use this for initialization
    void Awake() {
        SetSelectedCharacter();
        isPlaying = false;
        selectCubeBttn.SetActive(true);
        healthText.text = "Health: " + health;
        coins = 0;
        coinsText.text = "Coins: " + coins;
        box = GetComponent<BoxCollider>();
        rend = GetComponent<Renderer>();
        myBody = GetComponent<Rigidbody>();
        position = transform.position;
        speed = 10;

        alphaColor = gameObject.GetComponent<MeshRenderer>().material.color;
        alphaColor.a = 0;

        cubeNumber = 1;
        cubeRotationSpeed = EnemyCarMove.getSpeed() * 12f;

        control = GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameControlScript>();
        controller = GetComponent<CharacterController>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
        
    
        
        
	

    // Update is called once per frame
    void Update()
    {
		checkIfPlaying ();
		if (!GameControlScript.isGameOver ()) {
			moveCube ();

			if (Input.GetKeyDown (KeyCode.Space)) {
				SwitchCube ();
			}
		} else {
			gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color, alphaColor, timeToFade * Time.deltaTime);
		}
        rotateCamera();
    }

    public void rotateCamera()
    {
        camAngle *= Mathf.Pow(.9f + Mathf.Clamp(StageChange.getTotalStages(), 0, 9)/10 , Time.deltaTime * (1000));

        if (!GameControlScript.isGameOver() && camAngle < speed && camAngle > -speed)
        {
            camAngle += Input.GetAxis("Horizontal") * -1;
        }
		if(GameControlScript.isGameOver())
        	camAngle *= Mathf.Pow(.99f, Time.deltaTime * 100);
		
        camera.transform.eulerAngles = new Vector3(camera.transform.eulerAngles.x, camera.transform.eulerAngles.y, camAngle);
    }          

    public void moveCube()
    {
		/////////////////////////
		/// 
		/// 
		if (touches < Input.touchCount) {
			touches++;
			touches = 0;
		}
		Touch touch = Input.GetTouch(touches);
	

		if (PlayerPrefs.GetInt("selectedCharacter") == 3)
        {
			if (Input.GetKey(KeyCode.LeftArrow)||touch.position.x < (Screen.width / 2))
            {
                if (transform.rotation != Quaternion.Euler(0f, 256f, 0f))
                    transform.Rotate(new Vector3(0f, -2f, 0f));
            }

			if (Input.GetKey(KeyCode.RightArrow)||touch.position.x > (Screen.width / 2))
            {
                if (transform.rotation != Quaternion.Euler(0f, 286f, 0f))
                    transform.Rotate(new Vector3(0f, 2f, 0f));
            }
        }

        /*
		if (Input.GetKey (KeyCode.RightArrow)) {
			if (transform.rotation != Quaternion.Euler (0f, 285f, 0f))
				transform.Rotate (new Vector3 (0f, 2f, 0f));
		}*/

        if (PlayerPrefs.GetInt("selectedCharacter") != 2)
        {
			transform.Rotate(new Vector3(cubeRotationSpeed, 0, 0) * Time.deltaTime);
            //adjust height for cube
			float rot = transform.localRotation.eulerAngles.x % 90f;
			if (rot > 45)
				rot = 90 - rot;
			rot = rot * (Mathf.PI / 180);
			Vector3 temp = transform.position;
			temp.y = ((1/Mathf.Cos(rot)) * transform.localScale.y)/2;
			transform.position = temp;

            transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
        }
        else
            transform.Translate(0f, 0f, Input.GetAxis("Horizontal") * -speed * Time.deltaTime);

		/////////////////////////////////////
		/// 


		//Touch[] myTouches = Input.touches;

		if (touch.position.x > (Screen.width / 2)) {


			//if (transform.rotation != Quaternion.Euler(0f, 256f, 0f))
				//transform.Rotate(new Vector3(0f, -2f, 0f));
			transform.Translate (new Vector3(1,0,0) * speed * Time.deltaTime);
		} //else
			//transform.Translate(0f, 0f, Input.GetAxis("Horizontal") * -speed * Time.deltaTime);

		if (touch.position.x < (Screen.width / 2)) {
			
			//if (transform.rotation != Quaternion.Euler(0f, 286f, 0f))
				//transform.Rotate(new Vector3(0f, 2f, 0f));
			//transform.Translate(0f, 0f, touch.position.x * -speed * Time.deltaTime);
			transform.Translate (new Vector3(-1,0,0) * speed * Time.deltaTime);
		} //else
			//transform.Translate(0f, 0f, Input.GetAxis("Horizontal") * -speed * Time.deltaTime);
		
		Debug.Log(Input.touchCount); 

    }

    public void checkIfPlaying()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.touchCount > 1)
        {
			GameControlScript.scoreIncreasing = true;
            isPlaying = true;
			CubeSpawner.globalSpawning = true;
			alphaColor.a = 0;
        }
        if (!isPlaying)
        {
			GameControlScript.scoreIncreasing = false;
			CubeSpawner.globalSpawning = false;
        }
        else
        {
            Time.timeScale = 1;
			RemoveButtons ();
        }
    }
	
	public void RemoveButtons()
	{
		selectCubeBttn.SetActive(false);
		Buttons.SetActive (false);
		leftButton.enabled = false;
		rightButton.enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Coin") 
		{
			control.PowerupCollected ();
			coins++;
			coinsText.text = "Coins: " + coins;
		} 
		else if (other.gameObject.tag == "Enemy" || other.gameObject.name == "EnemyCube(Clone)") 
		{
			health -= 50;
			healthText.text = "Health: " + health;
			if (health <= 50) 
			{
				healthText.color = Color.red;
				if (health == 0) 
				{
					EndGame ();
				}
			}	
			
		}

	}

	public void SwitchCube()
	{
		if (cubeNumber == 1)
		{
			cube = this.gameObject.GetComponent<MeshFilter>().mesh;
			this.gameObject.GetComponent<MeshFilter>().mesh = cube2;

			cubeNumber = 2;
		}
		else if (cubeNumber == 2)
		{
			cubeNumber = 1;
			this.gameObject.GetComponent<MeshFilter>().mesh = cube;
		}
	}

	public void EndGame ()
	{
		//rend.enabled = false;
		box.enabled = false;
		Time.timeScale = 0;
		control.endCurrentSession();
	}

	public void SelectDefault()
	{
		PlayerPrefs.SetInt ("selectedCharacter", 0);
		SceneManager.LoadScene ("testscene");
	}

	public void SelectWitch()
	{
		PlayerPrefs.SetInt ("selectedCharacter", 1);
		SceneManager.LoadScene ("testscene");
	}

	public void SelectCubo()
	{
		PlayerPrefs.SetInt ("selectedCharacter", 2);
		SceneManager.LoadScene ("testscene");
	}
    

	void SetSelectedCharacter()
	{
		int selectedCharacterValue = PlayerPrefs.GetInt ("selectedCharacter");

		switch (selectedCharacterValue) {
		case 0:
			GetComponent<MeshFilter> ().mesh = defaultCube;
			GetComponent<MeshRenderer> ().material = cubeMat;
			break;

		case 1:
			GetComponent<MeshFilter> ().mesh = witchCube;
			GetComponent<MeshRenderer> ().material = cubeMat;
			break;

		case 2:
			GetComponent<MeshFilter> ().mesh = cubo;
			GetComponent<MeshRenderer> ().material = green;
			break;

		case 3:
			
			myBody.gameObject.SetActive (false);
			break;
		}

	}

    // Sets speed
    public static void setSpeed(float spd)
    {
        speed = spd;
    }

    public static float getSpeed()
    {

        return speed;
    }

}

