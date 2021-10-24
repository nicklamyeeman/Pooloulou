using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour {

    public GameObject CueObject;
    private Rigidbody rigidBody;
    private float multiplier;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        multiplier = CueObject.gameObject.GetComponent<CueMovement>().multiplier;
    }

    public void MoveBall() {
        float x = CueObject.transform.rotation.eulerAngles.y;
    
        if (x > 180 && x <= 360)
            x = 360 - x;
        if (x <= 90 && x >= 0)
            x = x * multiplier;
        else if (x <= 180 && x > 90)
            x = (180 - x) * multiplier;
        if (CueObject.transform.rotation.eulerAngles.y > 180 && CueObject.transform.rotation.eulerAngles.y <= 360)
            x = x * -1;

        float y = 0;

        float z = CueObject.transform.rotation.eulerAngles.y;
        if (z <= 180 && z >= 0)
            z = (90 - CueObject.transform.rotation.eulerAngles.y) * multiplier;
        else {
            z = 360 - CueObject.transform.rotation.eulerAngles.y;
            z = (90 - z) * multiplier;
        }

        Vector3 randomDirection = new Vector3(x,y,z);
        rigidBody.AddForce(randomDirection);
    }
}
