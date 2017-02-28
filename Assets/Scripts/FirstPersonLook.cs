using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonLook : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smooth;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject player;

	void Start () {
        player = this.transform.parent.gameObject;
	}
	
	void Update () {
        //transform.Rotate(Input.GetAxis("Mouse Y") * Time.deltaTime * 60f, 0f, 0f);
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smooth.x = Mathf.Lerp(smooth.x, mouseDelta.x, 1f / smoothing);
        smooth.y = Mathf.Lerp(smooth.y, mouseDelta.y, 1f / smoothing);
        mouseLook += smooth;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -50f, 50f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}
