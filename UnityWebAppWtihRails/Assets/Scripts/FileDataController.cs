using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine.UI;
using System.IO;

public class FileDataController : MonoBehaviour
{
    private Vector3 position;
    string file_path;
    public Object prefab; 
    public GameObject filepath_txt;
    GameObject obj_inst;
    private Vector3 screenToWorldPointPosition;
    private bool created = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(created){
        position = Input.mousePosition;
        position.z = 10f;
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        obj_inst.transform.position = screenToWorldPointPosition;
        }

        if (Input.GetMouseButtonDown(0)){
            created = false;
        }
    }

    public void OnFileSelecting()
    {
        //var path = @"N:\00_PAI_Projects\PAI0156_ARTS_HubsCloud\02.Program";
        //EditorUtility.RevealInFinder(path);

        file_path = EditorUtility.OpenFilePanel("Select Asset",Application.dataPath, "jpg");
        if (string.IsNullOrEmpty(file_path)) {
            return;
        }
        filepath_txt.GetComponent<Text>().text = file_path;
        Debug.Log(file_path);
    }

    public void OnFileDataCreate()
    {
        obj_inst = Instantiate(prefab, new Vector3(0,0,0), Quaternion.Euler(90f,0f,0f)) as GameObject;//ここがきちんとプレファブでなければならない
        byte[] byteData = File.ReadAllBytes(file_path);
        Texture2D texture = new Texture2D(0, 0, TextureFormat.RGBA32, false);
        texture.LoadImage(byteData);
        obj_inst.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/Texture");
        obj_inst.GetComponent<Renderer>().material.mainTexture = texture;
        created = true;

        // Texture2D tex = new Texture2D(128, 128);

        // //Texture2DをSpriteに変換
        // Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);



    }
}

