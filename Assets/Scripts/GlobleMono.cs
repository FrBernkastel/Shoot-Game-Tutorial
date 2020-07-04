using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobleMono : MonoBehaviour
{
    // ScreenSize params
    // global parameter
    public static float screenRatio = 16f / 9;
    public static float screenWidth = -Camera.main.transform.position.z;
    public static float screenHeight = -Camera.main.transform.position.z / screenRatio;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
