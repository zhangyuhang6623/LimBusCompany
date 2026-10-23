using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeByBottom : MonoBehaviour
{
   
    public void SceneChange(string scene)
    {
       
            SceneManage.instance.SenceChange(scene);
        
    }
}
