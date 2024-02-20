using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
public class GoBTN : MonoBehaviour
{
    [SerializeField]
    [Scene]
    public string m_scene;
    // Start is called before the first frame update
    public void OnBtnPress()
    {
        SceneManager.LoadScene(m_scene);
    }
}
