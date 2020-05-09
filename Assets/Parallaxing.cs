using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    public Transform[] backgrounds;
    private float[] scales;
    public float smoothing = 1;

    private Transform camera;
    private Vector3 previousCamPos;

    //Called before Start
    //used for calling logic before start but after all game objects are set up, assigning references
    void Awake()
    {
        camera = Camera.main.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = camera.position;
        scales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            scales[i] = backgrounds[i].position.z * (-1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - camera.position.x) * scales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].posiition.z);

            backgrounds[i].position = Vextor3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPos = camera.position;
    }
}
