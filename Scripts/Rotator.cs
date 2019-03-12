using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    //float timer = 0;
    Vector3 rotation;
    float x, y, z;
    int flipX = 1, flipY = 1, flipZ = 1;

    private void Start()
    {
        x = 10;
        y = 30;
        z = 40;
        rotation = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update () {
        //timer += Time.deltaTime;
        transform.Rotate(rotation * Time.deltaTime);

        x += 10 * Time.deltaTime * flipX;
        y += 3 * Time.deltaTime * flipY;
        z += 4 * Time.deltaTime * flipZ;

        if (x > 90 || x < -90)
            flipX = flipX * -1;
        if (y > 90 || y < -90)
            flipY = flipY * -1;
        if (z > 90 || z < -90)
            flipZ = flipZ * -1;
        rotation = new Vector3(x, y, z);
        /*if (timer > 1.5f)
        {
            x += Random.Range(-10, 10);
            timer = 0.0f;
        }*/
    }

    
}
