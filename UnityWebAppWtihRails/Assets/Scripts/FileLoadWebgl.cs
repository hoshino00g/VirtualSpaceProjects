using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class FileLoadWebgl : MonoBehaviour
{
    GameObject obj_inst;
    public Object prefab;


    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void FileImporterCaptureClick();
    private static extern void ConsoleLog(string logString);
    #endif

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonPointerDown()
    {
        #if UNITY_WEBGL  && !UNITY_EDITOR
        Debug.Log("OOOOOO");
        FileImporterCaptureClick();
        #endif
    }

    // public void FileSelected(string url)
    // {
    //     Debug.Log("Test_FileSelected");
    //     Debug.Log(url + "Test no URL!!!");
    //     StartCoroutine(LoadJson(url));
        
    // }

    // private IEnumerator LoadJson(string url)
    // {
    //     WWW www = new WWW(url);
    //     yield return www;


    //     obj_inst = Instantiate(prefab, new Vector3(0,0,0), Quaternion.Euler(90f,0f,0f)) as GameObject;//ここがきちんとプレファブでなければならない
    //     obj_inst.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/Texture");
    //     obj_inst.GetComponent<Renderer>().material.mainTexture = www.texture;
    // }
}