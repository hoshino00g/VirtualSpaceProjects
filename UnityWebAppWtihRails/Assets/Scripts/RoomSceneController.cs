using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSceneController : MonoBehaviour
{
    public string rn;
    public string iu;
    public static int visit_create = 99;//ここでどっちかを判別するのが良し、判別してどちらのクラスからstaticをとるか見極める

    // Start is called before the first frame update
    void Start()
    {
        rn = CreateRoom.roomName;
        iu = CreateRoom.imageUrl;
        Debug.Log(rn + "And..." + iu + "number is" + visit_create);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
