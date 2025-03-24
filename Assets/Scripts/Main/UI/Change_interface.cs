using UnityEngine;

public class Change_interface : MonoBehaviour
{
    [SerializeField] private GameObject unload_interface;
    [SerializeField] private GameObject load_interface;

    public void ChangeInterface()
    {
        load_interface.SetActive(true);
        unload_interface.SetActive(false);
    }
}
