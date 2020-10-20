using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class DataSending : MonoBehaviour
{
    public GameObject nametxtobj;
    public GameObject agetxtobj;

    public string name;
    public string age;



    // Start is called before the first frame update
    void Start()
    {

        print(nametxtobj.GetComponent<Text>().text);
        print(age);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDataSendingRailsServer()
    {
        name = nametxtobj.GetComponent<Text>().text;
        age = agetxtobj.GetComponent<Text>().text;
        StartCoroutine(Connection(name,age));
    }


    public IEnumerator Connection(string name,string age)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("age", age);
        string url_src = "";
#if UNITY_WEBGL  && UNITY_EDITOR
        url_src = "http://127.0.0.1:3000/users_uni";
#endif
#if UNITY_WEBGL  && !UNITY_EDITOR
        url_src = "https://virtual-space-projects.herokuapp.com/users_uni";
#endif
        UnityWebRequest request = UnityWebRequest.Post(url_src, form);
        yield return request.Send();

        Debug.Log(url_src + "URL");

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
        }

    }

}
