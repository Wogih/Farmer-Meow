using System.Collections;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventory_interface;
    [SerializeField] private float animation_duration;
    float elapsed_time;

    private void Update()
    {
        Debug.Log("I'm worcking");
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Debug.Log("E press");
            if (!inventory_interface.activeSelf)
            {
                Debug.Log("I'm activate");
                GameManager.game_stop = true;
                inventory_interface.SetActive(true);
                StartCoroutine(InventoryOpen());
            }
            else
            {
                GameManager.game_stop = false;
                StartCoroutine(InventoryClose());
            }
        }
    }

    public void CloseInventoryButton()
    {
        GameManager.game_stop = false;
        StartCoroutine(InventoryClose());
    }

    public IEnumerator InventoryOpen()
    {
        elapsed_time = 0;
        while (elapsed_time < animation_duration) 
        {
            elapsed_time += Time.deltaTime;
            inventory_interface.transform.position = Vector3.Lerp(new Vector3(0, -1080, 0), new Vector3(0, 0, 0), elapsed_time / animation_duration);
            yield return null;
        }
        inventory_interface.transform.position = new Vector3(0, 0, 0);
    }

    public IEnumerator InventoryClose()
    {
        elapsed_time = 0;
        while (elapsed_time < animation_duration)
        {
            elapsed_time += Time.deltaTime;
            inventory_interface.transform.position = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, -1080, 0), elapsed_time / animation_duration);
            yield return null;
        }
        inventory_interface.transform.position = new Vector3(0, -1080, 0);
        inventory_interface.SetActive(false);
    }
}
