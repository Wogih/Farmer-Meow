using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World_info : MonoBehaviour
{
    [SerializeField] private Text text_world_name;
    [SerializeField] private Text text_world_info;
    private WorldData world_data;

    private void OnEnable()
    {
        world_data = Data_base.current_world_data;
        string time_in_game = $"{world_data.time_in_game / 3600: 00}:{world_data.time_in_game % 3600 / 60: 00}:{world_data.time_in_game % 60: 00}";

        text_world_name.text = world_data.world_name;
        text_world_info.text = $"Дата создания мира - {world_data.creation_date_world}\nВремя в игре - {time_in_game}";
    }
}
