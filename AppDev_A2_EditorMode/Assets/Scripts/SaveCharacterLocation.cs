using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCharacterLocation : MonoBehaviour
{

    public static Vector3 CXY;

    // Start is called before the first frame update
    void Start()
    {
        CXY = GlobalStats.Instance.location;
        CXY.z = -10;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveLocation()
    {
        CXY = Camera.main.transform.position;
        GlobalStats.Instance.location = CXY;
    }
}
