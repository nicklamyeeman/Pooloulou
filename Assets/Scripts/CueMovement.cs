using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueMovement : MonoBehaviour
{
    public GameObject cueBall;

    private Vector3 currentEulerAngles;
    private Quaternion currentRotation;
    private float x;
    private float y;
    private float z;
    public float multiplier = 50.0f;

    float speed;

    // Start is called before the first frame upate
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameObject.FindWithTag("CueBall").gameObject.GetComponent<Rigidbody>().velocity.magnitude;

        if(speed < 0.5) {
            GameObject.FindWithTag("CueBall").gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            
            if (Input.GetKey(KeyCode.LeftArrow)) y += 1;
            if (Input.GetKey(KeyCode.RightArrow)) y -= 1;

            if (Input.GetKey(KeyCode.DownArrow)) {
                if (multiplier < 80.0f) {
                    multiplier += 1.0f;

                    rotateCue(-1);
                }

            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                if (multiplier > 20.0f) {
                    multiplier -= 1.0f;

                    rotateCue(1);
                }
            }
        } else {
            y = 0;

            currentEulerAngles = new Vector3(x, y, z);
            currentRotation.eulerAngles = currentEulerAngles;
            transform.rotation = currentRotation;

            Vector3 pos = transform.position;
            pos.z += -30.9f;
            transform.GetChild(0).transform.position = pos;

            multiplier = 50.0f;
        }

        currentEulerAngles = new Vector3(x, y, z);

        currentRotation.eulerAngles = currentEulerAngles;

        transform.rotation = currentRotation;

        transform.position = cueBall.transform.position;
    }

    void rotateCue(int pow)
    {
        if (pow == -1) {
            Vector3 pos = transform.GetChild(0).transform.position;

            float z = transform.GetChild(0).transform.rotation.eulerAngles.y;

            if (z <= 90.0f && z >= 0.0f) {
                z = (90.0f - z) / 90.0f;
                pos.z -= z / 10.0f;
            } else if (z > 90 && z <= 180) {
                z = ((90.0f - z) * -1) / 90.0f;
                pos.z += z / 10.0f;
            } else if (z >= 270 && z <= 360) {
                z = (90.0f - (360.0f - z)) / 90.0f;
                pos.z -= z / 10.0f;
            } else if (z > 180 && z < 270) {
                z = ((90.0f - (360.0f - z)) * -1) / 90.0f;
                pos.z += z / 10.0f;
            }

            float x = transform.GetChild(0).transform.rotation.eulerAngles.y;

            if (x <= 90.0f && x >= 0.0f) {
                x = x / 90.0f;
                pos.x -= x / 10.0f;
            } else if (x > 90 && x <= 180) {
                x = (180.0f - x) / 90.0f;
                pos.x -= x / 10.0f;
            } else if (x >= 270 && x <= 360) {
                x = (360.0f - x) / 90.0f;
                pos.x += x / 10.0f;
            } else if (x > 180 && x < 270) {
                x = (180.0f - (360.0f - x)) / 90.0f;
                pos.x += x / 10.0f;
            }

            transform.GetChild(0).transform.position = pos;
        } else {
            Vector3 pos = transform.GetChild(0).transform.position;

            float z = transform.GetChild(0).transform.rotation.eulerAngles.y;

            if (z <= 90.0f && z >= 0.0f) {
                z = (90.0f - z) / 90.0f;
                pos.z += z / 10.0f;
            } else if (z > 90 && z <= 180) {
                z = ((90.0f - z) * -1) / 90.0f;
                pos.z -= z / 10.0f;
            } else if (z >= 270 && z <= 360) {
                z = (90.0f - (360.0f - z)) / 90.0f;
                pos.z += z / 10.0f;
            } else if (z > 180 && z < 270) {
                z = ((90.0f - (360.0f - z)) * -1) / 90.0f;
                pos.z -= z / 10.0f;
            }

            float x = transform.GetChild(0).transform.rotation.eulerAngles.y;

            if (x <= 90.0f && x >= 0.0f) {
                x = x / 90.0f;
                pos.x += x / 10.0f;
            } else if (x > 90 && x <= 180) {
                x = (180.0f - x) / 90.0f;
                pos.x += x / 10.0f;
            } else if (x >= 270 && x <= 360) {
                x = (360.0f - x) / 90.0f;
                pos.x -= x / 10.0f;
            } else if (x > 180 && x < 270) {
                x = (180.0f - (360.0f - x)) / 90.0f;
                pos.x -= x / 10.0f;
            }

            transform.GetChild(0).transform.position = pos;
        }
    }
}
