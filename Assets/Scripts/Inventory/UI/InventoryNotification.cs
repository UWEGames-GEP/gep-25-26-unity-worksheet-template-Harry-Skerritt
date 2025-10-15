using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class InventoryNotification : MonoBehaviour
{
    [Header("UI References")] 
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private float textLifetime = 2.5f;
    [SerializeField] private float fadeDuration = 0.5f;
    
    private List<GameObject> activeTexts = new List<GameObject>();

    public void ShowMessage(string itemName, int quantity = 1)
    {
        GameObject go = Instantiate(textPrefab, transform);
        go.SetActive(true);
        
        TMP_Text text = go.GetComponent<TMP_Text>();
        text.text = $"Added {quantity}x {itemName}";
        
        activeTexts.Add(go);
        StartCoroutine(RemoveMessage(go, textLifetime, fadeDuration));
    }

    private IEnumerator RemoveMessage(GameObject go, float lifetime, float fadeDuration)
    {
        yield return new WaitForSeconds(lifetime);
        
        TMP_Text text = go.GetComponent<TMP_Text>();
        CanvasGroup group = go.GetComponent<CanvasGroup>();

        if (group == null)
        {
            group = go.AddComponent<CanvasGroup>();
            group.alpha = 1;
        }

        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            group.alpha = 1f - (t / fadeDuration);
            yield return null;
        }
        
        activeTexts.Remove(go);
        Destroy(go);
    }
}
