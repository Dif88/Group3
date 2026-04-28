using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class AddStarsScriptToChildren : MonoBehaviour
{
    [MenuItem("Tools/Setup Stars - Add Scripts & Scale")]
    public static void AddStarsScriptToAllChildren()
    {
        GameObject starsParent = GameObject.Find("Stars");
        
        if (starsParent == null)
        {
            EditorUtility.DisplayDialog("Error", "Could not find 'Stars' object in scene!", "OK");
            return;
        }

        int starsCount = 0;
        int collidersFixed = 0;
        int animationsFixed = 0;
        int scaled = 0;
        
        foreach (Transform child in starsParent.transform)
        {
            if (child.GetComponent<stars>() == null)
            {
                child.gameObject.AddComponent<stars>();
                starsCount++;
            }

            BoxCollider2D boxCollider2D = child.GetComponent<BoxCollider2D>();
            if (boxCollider2D != null)
            {
                boxCollider2D.isTrigger = true;
                collidersFixed++;
            }

            child.localScale = Vector3.one * 0.04f;
            scaled++;
            EditorUtility.SetDirty(child.gameObject);

            var gemsAnim = child.GetComponent("SimpleGemsAnim");
            if (gemsAnim != null)
            {
                var isFloatingField = gemsAnim.GetType().GetField("isFloating");
                var isScalingField = gemsAnim.GetType().GetField("isScaling");
                var isRotatingField = gemsAnim.GetType().GetField("isRotating");
                
                if (isFloatingField != null) isFloatingField.SetValue(gemsAnim, false);
                if (isScalingField != null) isScalingField.SetValue(gemsAnim, false);
                if (isRotatingField != null) isRotatingField.SetValue(gemsAnim, false);
                    
                animationsFixed++;
                EditorUtility.SetDirty((MonoBehaviour)gemsAnim);
            }
        }

        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        EditorUtility.DisplayDialog("Success", "Stars Setup Complete and Saved!", "OK");
    }
}
