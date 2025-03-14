using UnityEngine;
using UnityEngine.UI;

public class World_loader : MonoBehaviour
{
    [SerializeField] Text name_world;

    public WorldData world_data;
    public World_list world_list;
    public GameObject world_list_panel;
    public GameObject world_info_panel;
    private Menu_swap_interface menu_swap;

    private void Start()
    {
        name_world.text = world_data.world_name;
        menu_swap = GetComponent<Menu_swap_interface>();
        menu_swap.unload_interface = world_list_panel;
    }

    public void DeleteWorld()
    {
        Data_base.worlds_data.world_data.RemoveAll(world => world.world_name == world_data.world_name);
        world_list.LoadWorlds();
        Data_base.SaveData();
    }

    public void InfoWorld()
    {
        Data_base.current_world_data = world_data;
        menu_swap.load_interface = world_info_panel;
        menu_swap.MenuSwapInterface();
    }

    public void PlayWorld()
    { 
        Data_base.current_world_data = world_data;
        world_list.StartGame();
    }
}
