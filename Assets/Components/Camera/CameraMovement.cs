using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private void Update()
    {
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, transform.position + new Vector3(0, 32f, 0), 5 * Time.deltaTime);
        Camera.main.transform.rotation = Quaternion.Euler(new Vector3(90f, 0, 0));   
    }
}
