using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Transition : MonoBehaviour
{

    public string SceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger Entered");

        if (collision.gameObject.tag == "Player")
        {
            print("Switching to Scene" + SceneToLoad);
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}

