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
            SceneManager.LoadScene(targetSceneAsset.Name);
        }
    }

    public void AddToScene()
    {
        if (targetSceneAsset != null && targetSceneAsset.State != SceneReferenceState.Unsafe)
        {
            SceneManager.LoadScene(targetSceneAsset.Name, LoadSceneMode.Additive);
        }
    }
}
