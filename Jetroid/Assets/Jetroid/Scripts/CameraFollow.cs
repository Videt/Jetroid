using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float scale = 4f;

    private Transform t;

    private void Awake()
    {
        Camera cam = GetComponent<Camera>();

        //adjust the camera size based on resolution or aspect ratio
        cam.orthographicSize = (Screen.height / 2f) / scale; //divided by 2f because Unity's coordinate system begins in the center of the screen
    }

    // Start is called before the first frame update
    void Start()
    {
        t = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(t.position.x, t.position.y, transform.position.z);
        }
    }
}
