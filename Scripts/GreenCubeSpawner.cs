using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCubeSpawner : CubeSpawner {

	public GameObject cube;

	// Use this for initialization
	void Start () {
		base.onStart ();
		base.setMyCube (cube);
		startSpawning ();
		base.setDelayLowCap (0.005f);
	}

	void Update(){
		base.onUpdate ();
	}

	public void stageChangeDelay(){
		if (StageChange.getTotalStages () < 5)
			base.setDelayTimer (base.getDelayTimer() - (0.1f * (1 / Mathf.Sqrt (StageChange.getTotalStages ()))));
		else
			base.setDelayTimer (base.getDelayTimer() + 0.005f);

		if (base.getDelayTimer() <= 0)
			base.setDelayTimer (base.getDelayLowCap());
	}

}
