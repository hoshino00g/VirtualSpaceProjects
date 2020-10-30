using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RoomSceneController : MonoBehaviour
{
    public GameObject floorPlane;

    public string rn;
    public string iu;
    public static int visit_create = 99;//ここでどっちかを判別するのが良し、判別してどちらのクラスからstaticをとるか見極める

    // Start is called before the first frame update
    void Start()
    {
        if(visit_create == 0){
            rn = CreateRoom.roomName;
            iu = CreateRoom.imageUrl;
            Debug.Log(rn + "And..." + iu + "number is" + visit_create);
        }else{
            rn = VisitRoom.roomName;
            iu = VisitRoom.imageUrl;
            Debug.Log(rn + "And..." + iu + "number is" + visit_create);

        }

        bool result = iu.Contains("blob:http:");
        if(result){
            StartCoroutine(LoadJpg(iu));
        }else{
            OnFileDataCreate(iu);
        }

    }
    private IEnumerator LoadJpg(string url)
    {
        WWW www = new WWW(url);
        yield return www;


       // obj_inst = Instantiate(prefab, new Vector3(0,0,0), Quaternion.Euler(90f,0f,0f)) as GameObject;//ここがきちんとプレファブでなければならない
        // obj_inst.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/Texture");
        floorPlane.GetComponent<Renderer>().material.mainTexture = www.texture;
        // created = true;
        Debug.Log("LoadJpg");
    }

    public void OnFileDataCreate(string file_path)
    {
       // obj_inst = Instantiate(prefab, new Vector3(0,0,0), Quaternion.Euler(90f,0f,0f)) as GameObject;//ここがきちんとプレファブでなければならない
        byte[] byteData = File.ReadAllBytes(file_path);
        Texture2D texture = new Texture2D(0, 0, TextureFormat.RGBA32, false);
        texture.LoadImage(byteData);
        // floorPlane.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/Texture");
        floorPlane.GetComponent<Renderer>().material.mainTexture = texture;
        // created = true;

        // Texture2D tex = new Texture2D(128, 128);

        // //Texture2DをSpriteに変換
        // Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
    }

}
