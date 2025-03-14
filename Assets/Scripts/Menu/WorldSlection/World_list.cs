using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class World_list : MonoBehaviour
{
    [SerializeField] private GameObject world_loader;
    [SerializeField] private GameObject content;
    [SerializeField] private InputField input_world_name;
    [SerializeField] private GameObject worlds_list_panel;
    [SerializeField] private GameObject input_world_name_panel;
    [SerializeField] private GameObject worlds_info_panel;
    [SerializeField] private int id_game_scene;
    void OnEnable()
    {
        LoadWorlds();
    }

    void Update()
    {
        
    }

    public void LoadWorlds()
    {
        foreach (Transform world in content.transform)
        {
            Destroy(world.gameObject);
        }

        if (Data_base.worlds_data.world_data.Count != 0)
        {
            Data_base.worlds_data.world_data.ForEach(world =>
            {
                World_loader spawned_world_loader = Instantiate(world_loader, content.transform).GetComponent<World_loader>();
                spawned_world_loader.world_data = world;
                spawned_world_loader.world_list = GetComponent<World_list>();
                spawned_world_loader.world_info_panel = worlds_info_panel;
                spawned_world_loader.world_list_panel = worlds_list_panel;
            });
        }
    }

    public void CreateWorld()
    {
        WorldData new_world = new WorldData();

        new_world.world_name = GenerateUniqueWorldName(input_world_name.text.Length != 0 ? input_world_name.text : "Новый мир");

        input_world_name.text = "";

        new_world.creation_date_world = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        new_world.time_in_game = 0;

        Data_base.worlds_data.world_data.Add(new_world);
        LoadWorlds();
        Data_base.SaveData();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(id_game_scene);
    }

    private string GenerateUniqueWorldName(string baseName)
    {
        string newName = baseName;
        int copyNumber = 1;

        while (WorldNameExists(newName))
        {
            newName = $"{baseName} {copyNumber}";
            copyNumber++;
        }

        return newName;
    }

    private bool WorldNameExists(string worldName)
    {
        foreach (WorldData data in Data_base.worlds_data.world_data)
        {
            if (data.world_name == worldName) return true;
        }
        return false;
    }
}
