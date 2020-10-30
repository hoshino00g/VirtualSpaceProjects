using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;
using System;

public class OpenFloorImg : MonoBehaviour
{
    string file_path;
    public GameObject filepath_txt;
    // Start is called before the first frame update

      #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void ImgImporterCaptureClick();
    #endif

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void OnFileSelecting()
    {
        //var path = @"N:\00_PAI_Projects\PAI0156_ARTS_HubsCloud\02.Program";
        //EditorUtility.RevealInFinder(path);

        #if UNITY_WEBGL  && !UNITY_EDITOR
        Debug.Log("WEbgl selecting");
        ImgImporterCaptureClick();
        #endif

        #if UNITY_WEBGL  && UNITY_EDITOR
         Debug.Log("UnityEdi selecting");
        file_path = EditorUtility.OpenFilePanel("Select Asset",Application.dataPath, "jpg");
        if (string.IsNullOrEmpty(file_path)) {
            return;
        }

        StreamReader sr = new StreamReader(file_path, System.Text.Encoding.GetEncoding("Shift_JIS"));
        string str = sr.ReadToEnd().ToString();

        filepath_txt.GetComponent<Text>().text = file_path;
        filepath_txt.GetComponent<Text>().fontSize = 8;
        OnFileDataCreate();
        Debug.Log(file_path);

        #endif

    }

     public void OpenImg(string url)
    {
        //  #if UNITY_WEBGL && !UNITY_EDITOR
        // ConsoleLog("KOKOKO");
        // ConsoleLog(url);
        // #endif
        Debug.Log("FileSelected!!!!");
        StartCoroutine(LoadJpg(url));
        
    }

    private IEnumerator LoadJpg(string url)
    {
        Debug.Log(url + "ですよ！！！");
        filepath_txt.GetComponent<Text>().text = url;

        WWW www = new WWW(url);
        yield return www;// www.texture;で取り出せる
       // filepath_txt.GetComponent<Text>().text = www.texture.ToString();
        filepath_txt.GetComponent<Text>().fontSize = 8;
        // Debug.Log(www.texture);
    }

    public void OnFileDataCreate()
    {
         
    }
    
}
