using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCubeSpawner : CubeSpawner {

	public GameObject cube;
    
    private float delayTimer = 3.0f;

	// Use this for initialization
	void Start () {
		base.onStart ();
		base.setMyCube (cube);
		base.setDelayLowCap (0.01f);
	}

	void Update(){
		base.onUpdate ();
	}

	public void stageChangeDelay(){
        if (StageChange.getTotalStages() > 5)
        {
            base.startSpawning();
            base.setDelayTimer(delayTimer);
        }
        if (StageChange.getTotalStages () < 15)
			base.setDelayTimer (base.getDelayTimer() - (0.25f * (1 / Mathf.Sqrt (StageChange.getTotalStages ()))));
		else
			base.setDelayTimer (base.getDelayTimer() + 0.005f);

		if (base.getDelayTimer() <= 0)
			base.setDelayTimer (base.getDelayLowCap());
	}

}
