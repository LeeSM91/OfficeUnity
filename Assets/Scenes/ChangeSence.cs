using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSence : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneLoad()
    {
        SceneManager.LoadScene("MainOffice");
    }


}
