using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_scene : MonoBehaviour
{
    public void LoadScene(int scene_id)
    { 
        SceneManager.LoadScene(scene_id);
    }
}
