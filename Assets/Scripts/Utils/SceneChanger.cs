using UnityEngine;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;

public class SceneChanger : MonoBehaviour
{
    [SerializeField, Tooltip("The scene to load when the player enters this trigger.")]
    private SceneReference targetSceneAsset;

    public void SwitchToScene()
    {
        if (targetSceneAsset != null && targetSceneAsset.State != SceneReferenceState.Unsafe)
        {
            // Debug.Log($"Switching to scene: {targetSceneAsset.Name}");
            SceneManager.LoadScene(targetSceneAsset.Name);
        }
    }
}
