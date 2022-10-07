using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BackgroundEffect : MonoBehaviour
{
    public Transform cam;
    [SerializeField]
    public float effect = 5f;
    void Update()
    {
        transform.position = new Vector2(cam.position.x / effect, cam.position.y / effect);
    }
}
