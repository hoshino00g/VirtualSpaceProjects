using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CreateRoom : MonoBehaviour
{
    public GameObject roomnameField;
    public GameObject passwordField;
    public GameObject imgurlField;
    string rntxt = null;
    string pwtxt = null;
    string iutxt = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCreateRoom(){
        rntxt = roomnameField.GetComponent<Text>().text;
        pwtxt = passwordField.GetComponent<Text>().text;
        iutxt = imgurlField.GetComponent<Text>().text;

       if(rntxt == "" || pwtxt == "" || iutxt == ""){
           Debug.Log("NININI");
           Debug.Log(rntxt + "と"  + pwtxt +  "と" + iutxt);
       }else{
           Debug.Log("OKKKKKKKKKKKKKKKKKKK");
           Debug.Log(rntxt + "と"  + pwtxt +  "と" + iutxt);
           StartCoroutine(Connection(rntxt,pwtxt,iutxt));
       }

       //StartCoroutine(Connection(rntxt,pwtxt,iutxt));
    }

    public IEnumerator Connection(string rntxt,string pwtxt, string iutxt)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", rntxt);
        form.AddField("password", pwtxt);
        form.AddField("floor_image_url", iutxt);
        string url_src = "";
#if UNITY_WEBGL  && UNITY_EDITOR
        url_src = "http://127.0.0.1:3000/rooms";
#endif
#if UNITY_WEBGL  && !UNITY_EDITOR
        url_src = "https://virtual-space-projects.herokuapp.com/rooms";
#endif
        UnityWebRequest request = UnityWebRequest.Post(url_src, form);
        yield return request.Send();

        if (request.isHttpError)
        {
            Debug.Log("エラー:" + request.error);
        }
        else
        {
            if (request.responseCode == 204)
            {
                Debug.Log("せいこう！");
            }
            else
            {
                Debug.Log("しっぱい…:" + request.responseCode);
            }
            SceneManager.LoadScene("RoomScene");

        }

    }
}
