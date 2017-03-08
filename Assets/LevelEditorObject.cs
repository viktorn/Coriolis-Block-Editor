using UnityEngine;
using UnityEngine.EventSystems;

public class LevelEditorObject : MonoBehaviour, IPointerClickHandler
{
    public string PrefabName { get; set; }

    private bool isPlaced = false;
    public bool IsPlaced
    {
        get { return isPlaced; }
        set { isPlaced = value; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsPlaced)
        {
            Debug.LogError("Del" + Time.frameCount);
            if (eventData.button == PointerEventData.InputButton.Right)
                Destroy(gameObject);
        }
    }
}
