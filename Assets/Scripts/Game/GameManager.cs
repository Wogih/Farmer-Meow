using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject game_menu_interface;
    [SerializeField] private GameObject game_interface;
    [SerializeField] private GameObject game_settings_interface;
    [SerializeField] private Inventory inventory_interface;

    [SerializeField] private Transform player;
    public static bool game_stop;
    private float time_in_game;

    private void Start()
    {
        time_in_game = Data_base.current_world_data.time_in_game;
        StartCoroutine(AutoSave());
    }

    private void Update()
    {
        if (!game_stop)
        {
            time_in_game += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (game_interface.activeSelf)
            {
                game_stop = true;
                game_interface.SetActive(false);
                game_menu_interface.SetActive(true);
            }
            else if (game_menu_interface.activeSelf) 
            {
                game_stop = false;
                game_menu_interface.SetActive(false);
                game_interface.SetActive(true);
            }
        }
    }

    private IEnumerator AutoSave()
    {
        while (true)
        {
            SaveGame();

            yield return new WaitForSeconds(300f);
        }
    }

    public void SaveGame()
    {
        foreach (WorldData data in Data_base.worlds_data.world_data)
        {
            if (data.world_name == Data_base.current_world_data.world_name)
            {
                data.player_position = new MyVector3(new Vector3(Mathf.Round(player.position.x), Mathf.Round(player.position.y)));
                data.time_in_game = (int)time_in_game;
                //Debug.Log("Сохранен " + JsonUtility.ToJson(data));
                Data_base.SaveData();
            }
        }
    }
}
