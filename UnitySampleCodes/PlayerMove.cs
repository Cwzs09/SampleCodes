
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float MaxSpeed = 5f;
    float shipBoundaryRadius = 0.7f;

    void Start () {
        
	}
	
	void Update () {
        Vector3 pos = transform.position;
        pos.y += Input.GetAxis("Vertical") * MaxSpeed * Time.deltaTime;
        pos.x += Input.GetAxis("Horizontal") * MaxSpeed * Time.deltaTime;
        transform.position = pos;
        //vertical sınırlar
        if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }
        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }
        // orthographic genişliğe bağlı ekran oranı
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float width0rtho = Camera.main.orthographicSize * screenRatio;
        //horizontal sınırlar
        if (pos.x + shipBoundaryRadius > width0rtho)
        {
            pos.x = width0rtho - shipBoundaryRadius;
        }
        if (pos.x - shipBoundaryRadius < -width0rtho)
        {
            pos.x = -width0rtho + shipBoundaryRadius;
        }

        transform.position = pos;
    }
}
