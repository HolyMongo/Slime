using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneGameData
{
    public Vector3[] scenePos;
    //Will Save what scene you exited in
    public bool[] firstTime;

    //Tutorial -8.3, -4.6, 0
    //FlowerForest -329.46f, -60.036f, 0f

    public SceneGameData()
    {
        scenePos[0] = new Vector3(-16f, -0.5f, 0f);

        scenePos[1] = new Vector3(-283.7f, 63.9f, 01644756f);

        scenePos[2] = new Vector3(-8.333063f, -4.634978f, 0.016447560f);

        bool boolScene1 = false;
        firstTime[0] = boolScene1;
        bool boolScene2 = false;
        firstTime[1] = boolScene2;
        bool boolScene3 = false;
        firstTime[2] = boolScene3;

    }
}
