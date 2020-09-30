using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileDataSending : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFileShowing()
    {
        //var path = @"N:\00_PAI_Projects\PAI0156_ARTS_HubsCloud\02.Program";
        //EditorUtility.RevealInFinder(path);

        var path = EditorUtility.OpenFilePanel("Select Asset",Application.dataPath, "glb");
        if (string.IsNullOrEmpty(path)) {
            return;
        }
        Debug.Log(path);
    }
}
