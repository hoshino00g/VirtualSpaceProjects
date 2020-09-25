using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class DataShowing : MonoBehaviour
{

    public GameObject numtxt;
    public int num;

    public GameObject resulttxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDataShowing()
    {

        int num = int.Parse(numtxt.GetComponent<Text>().text);
        StartCoroutine(Connection(num));

    }

    private IEnumerator Connection(int num)
    {
        WWWForm form = new WWWForm();
        UnityWebRequest request = UnityWebRequest.Get("http://127.0.0.1:3000/show_uni/"+num.ToString());

        yield return request.Send();

        if (request.isHttpError)
        {
            print("エラー" + request.error);
        }
        else
        {
            if(request.responseCode == 200)
            {
                print("成功");
                print(request.downloadHandler.text);
                resulttxt.GetComponent<Text>().text = request.downloadHandler.text;
            }
            else
            {
                print("失敗" + request.responseCode);
            }
        }
    }
}
