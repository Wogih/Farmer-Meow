using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    [SerializeField] private GameObject game_interface;
    [SerializeField] private GameObject player;
    private bool world_finish_load = false;

    //Progress bar
    [SerializeField] private Slider progress_bar;
    private int loadedObjects = 0;
    private int totalObjects;

    // Text animation
    [SerializeField] private Text text_load_world;
    [SerializeField] private float text_animation_speed;
    private string base_text = "Загрузка";
    private int dotCount = 0;

    private void Awake()
    {
        GameManager.game_stop = true;

        totalObjects = 1;
        progress_bar.maxValue = totalObjects;


        StartCoroutine(TextLoadWorld());
        StartCoroutine(LoadWorld());
    }

    private IEnumerator LoadWorld()
    {
        //Debug.Log("Загружен " + JsonUtility.ToJson(Data_base.current_world_data));
        player.transform.position = Data_base.current_world_data.player_position != null ?  Data_base.current_world_data.player_position.Convert() : Vector3.zero;
        loadedObjects++;

        UpdateProgressBar();
        FinishLoadWorld();

        yield return null;
    }

    IEnumerator TextLoadWorld()
    {
        while (!world_finish_load)
        {
            text_load_world.text = base_text + new string('.', dotCount);
            dotCount = (dotCount + 1) % 4;
            yield return new WaitForSeconds(text_animation_speed);
        }
    }

    private void UpdateProgressBar()
    {
        progress_bar.value = loadedObjects;
    }

    public void FinishLoadWorld()
    {
        world_finish_load = true;
        GameManager.game_stop = false;
        game_interface.SetActive(true);
        gameObject.SetActive(false);
    }

}
