using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCoinSpawner : CubeSpawner {

	public GameObject coin;

	// Use this for initialization
	void Start () {
		base.onStart ();
		base.setMyCube (coin);
		base.setDelayTimer (0.8f);
		base.setCubeRotation(new Quaternion(90f, 0f, 0f, 0f));
		base.startSpawning ();
		base.setDelayLowCap (0.005f);
	}

	void Update(){
		base.onUpdate ();
	}

	public void stageChangeDelay(){
		if (StageChange.getTotalStages () < 15)
			base.setDelayTimer (base.getDelayTimer() - (0.1f * (1 / Mathf.Sqrt (StageChange.getTotalStages ()))));
		else
			base.setDelayTimer (base.getDelayTimer() + 0.005f);

		if (base.getDelayTimer() <= 0)
			base.setDelayTimer (base.getDelayLowCap());
	}

}
