using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public NetworkCustom networkCustom;

    public void setToPlayer1()
    {
        networkCustom.btn1();
        Debug.Log("setToPlayer1()");
    }

    public void setToPlayer2()
    {
        networkCustom.btn2();
        Debug.Log("setToPlayer2()");
    }
}
