using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChange : MonoBehaviour {

    public GameObject sPlane;
    public Material Stage1;
    public Material Stage2;
    public Material Stage3;
    public Material Stage4;
    public Material Stage5;
    public Material Stage6;

    private int stageNum = 1;
	private static int totalStages = 0;
    private float delayTimer;
    private GreenCubeSpawner greenCubeSpawner;
    private YellowCoinSpawner yellowCoinSpawner;
    private YellowCubeSpawner yellowCubeSpawner;
    private OrangeCubeSpawner orangeCubeSpawner;
    private RedCubeSpawner redCubeSpawner;
    private BlueCubeSpawner blueCubeSpawner;

    private float speedIncrease;
	private int stageToScaleSpeed;

	// Use this for initialization
	void Start () 
	{
		speedIncrease = 10f;
		stageToScaleSpeed = 8;
        delayTimer = -1;
		greenCubeSpawner = GameObject.FindGameObjectWithTag("CubeSpawner").GetComponent<GreenCubeSpawner>();
        yellowCoinSpawner = GameObject.FindGameObjectWithTag("CubeSpawner").GetComponent<YellowCoinSpawner>();
        yellowCubeSpawner = GameObject.FindGameObjectWithTag("CubeSpawner").GetComponent<YellowCubeSpawner>();
        orangeCubeSpawner = GameObject.FindGameObjectWithTag("CubeSpawner").GetComponent<OrangeCubeSpawner>();
        redCubeSpawner = GameObject.FindGameObjectWithTag("CubeSpawner").GetComponent<RedCubeSpawner>();
        blueCubeSpawner = GameObject.FindGameObjectWithTag("CubeSpawner").GetComponent<BlueCubeSpawner>();
    }

    // Update is called once per frame
    void Update() 
	{
        if (GameControlScript.getScore() == 0 ){
            EnemyCarMove.setSpeed(20f);
            cubeController.setSpeed(10);
            cubeController.cubeRotationSpeed = EnemyCarMove.getSpeed() * 12f;
        }
        delayTimer -= Time.deltaTime;

		if (delayTimer < 0 && GameControlScript.getScore() % 25 == 0 && GameControlScript.getScore() > 1)
        {
            
            switch (stageNum) 
			{
                
                case 1:
                    sPlane.GetComponent<Renderer>().material = Stage2;
                    break;
                case 2:
                    sPlane.GetComponent<Renderer>().material = Stage3;
                    break;
                case 3:
                    sPlane.GetComponent<Renderer>().material = Stage4;
                    break;
                case 4:
                    sPlane.GetComponent<Renderer>().material = Stage5;
                    break;
                case 5:
                    sPlane.GetComponent<Renderer>().material = Stage6;
                    break;
                case 6:
                    sPlane.GetComponent<Renderer>().material = Stage1;
                    stageNum = 0;
                    break;

            }

			incrementSpeed ();
			delayTimer = 3;
			totalStages++;
			stageNum++;
			greenCubeSpawner.stageChangeDelay ();
            yellowCoinSpawner.stageChangeDelay();
            yellowCubeSpawner.stageChangeDelay();
            orangeCubeSpawner.stageChangeDelay();
            redCubeSpawner.stageChangeDelay();
            blueCubeSpawner.stageChangeDelay();
        }

	}

	private void incrementSpeed(){
		if (totalStages <= stageToScaleSpeed) {
			EnemyCarMove.setSpeed (EnemyCarMove.getSpeed () + speedIncrease);
			cubeController.setSpeed (cubeController.getSpeed () + speedIncrease*0.1f);
		} else {
			EnemyCarMove.setSpeed (EnemyCarMove.getSpeed () + (speedIncrease) / Mathf.Sqrt (totalStages));
			cubeController.setSpeed (cubeController.getSpeed () + (speedIncrease) / Mathf.Sqrt (totalStages));
		}
		cubeController.cubeRotationSpeed = EnemyCarMove.getSpeed() * 12f;
	}

	public static int getTotalStages(){
		return totalStages;
	}

}
