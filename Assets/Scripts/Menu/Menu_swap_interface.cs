using System.Collections;
using UnityEngine;

public class Menu_swap_interface : MonoBehaviour
{
    [SerializeField] public GameObject unload_interface;
    [SerializeField] public GameObject load_interface;
    public float animation_duration = 0.5f;

    public void MenuSwapInterface()
    {
        StartCoroutine(MenuSwapInterfaceEnumeration());
    }

    private IEnumerator MenuSwapInterfaceEnumeration()
    {
        float elapsed_time = 0;
        while (elapsed_time < animation_duration)
        {
            elapsed_time += Time.deltaTime;
            unload_interface.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(0, 0, 0), elapsed_time / animation_duration);
            yield return null;
        }
        unload_interface.transform.localScale = new Vector3(0, 0, 0);

        elapsed_time = 0;
        load_interface.gameObject.SetActive(true);
        while(elapsed_time < animation_duration)
        {
            elapsed_time += Time.deltaTime;
            load_interface.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(1, 1, 1), elapsed_time / animation_duration);
            yield return null;
        }
        load_interface.transform.localScale = new Vector3(1, 1, 1);

        unload_interface.gameObject.SetActive(false);
    }

}
