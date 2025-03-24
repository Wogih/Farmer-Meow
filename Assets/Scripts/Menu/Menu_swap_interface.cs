using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Menu_swap_interface : MonoBehaviour
{
    [SerializeField] public GameObject unload_interface;
    [SerializeField] public GameObject load_interface;
    public float animation_duration = 0.7f;
    private static bool animation_plays = false;

    public void MenuSwapInterface()
    {
        if (animation_plays) return;

        StartCoroutine(MenuSwapInterfaceEnumeration());
    }

    private IEnumerator MenuSwapInterfaceEnumeration()
    {
        animation_plays = true;

        load_interface.transform.localScale = Vector3.one;
        unload_interface.transform.DOScale(0, animation_duration);
        yield return new WaitForSeconds(animation_duration);

        load_interface.gameObject.SetActive(true);

        load_interface.transform.localScale = Vector3.zero;
        load_interface.transform.DOScale(1, animation_duration);
        yield return new WaitForSeconds(animation_duration);

        unload_interface.gameObject.SetActive(false);

        animation_plays = false;
    }

}
