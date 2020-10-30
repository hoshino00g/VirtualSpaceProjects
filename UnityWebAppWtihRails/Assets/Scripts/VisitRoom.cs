using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class VisitRoom : MonoBehaviour
{
    public GameObject roomnameField;
    public GameObject passwordField;

    public GameObject errorText;

    string rntxt = null;
    string pwtxt = null;

    public static string roomName;
    public static string imageUrl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnVisitRoom(){
        rntxt = roomnameField.GetComponent<Text>().text;
        pwtxt = passwordField.GetComponent<Text>().text;
    
        StartCoroutine(Connection(rntxt, pwtxt));
    }

    private IEnumerator Connection(string rntxt, string pwtxt)
    {
        WWWForm form = new WWWForm();
        string url_src = "";
#if UNITY_WEBGL  && UNITY_EDITOR
        url_src = "http://127.0.0.1:3000/rooms/";
#endif

#if UNITY_WEBGL  && !UNITY_EDITOR
        url_src = "https://virtual-space-projects.herokuapp.com/rooms/";
#endif
        UnityWebRequest request = UnityWebRequest.Get(url_src+ rntxt + "/" + pwtxt.ToString());
        yield return request.Send();

        if (request.isHttpError)
        {
            print("エラー" + request.error);
            print(url_src);
        }
        else
        {
            if(request.responseCode == 200)
            {
                print("成功");
                print(request.downloadHandler.text);
                string error = request.downloadHandler.text;
                if(error == "null"){
                    errorText.SetActive(true);
                }else{
                    var jsonData = MiniJSON.Json.Deserialize(request.downloadHandler.text) as Dictionary<string, object>;
                    var name = jsonData["password"] as string;
                    var url = jsonData["floor_image_url"] as string;
                   // var expression = results["expression"] as string;
                    roomName = name;
                    imageUrl = url;
                    RoomSceneController.visit_create = 1;
                    SceneManager.LoadScene("RoomScene");

                    Debug.Log(name + url + "だよ～");
                }
            }
            else
            {
                print("失敗" + request.responseCode);
            }
        }
    }
}
