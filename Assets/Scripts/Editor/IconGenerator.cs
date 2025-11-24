using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public static class IconGenerator
{

   private const string ICON_OUTPUT_DIR = "Assets/GeneratedIcons";
   
   [MenuItem("Assets/Generate Icon", true)]
   private static bool ValidateGenerateIcon()
   {
      return Selection.activeGameObject is GameObject;
   }

   [MenuItem("Assets/Generate Icon")]
   private static void GenerateIcon()
   {
      var prefab = Selection.activeGameObject;
     
      if(!Directory.Exists(ICON_OUTPUT_DIR))
         Directory.CreateDirectory(ICON_OUTPUT_DIR);
      

      EditorApplication.delayCall += () => ProcessPreview(prefab);
   }

   private static void ProcessPreview(GameObject prefab)
   {
      Texture2D preview = AssetPreview.GetAssetPreview(prefab);

      if (preview == null)
      {
         EditorApplication.delayCall += () => ProcessPreview(prefab);
         return;
      }
      
      EditorUtility.DisplayProgressBar("Generating Icon", "Saving...", 0.6f);
      SaveIcon(prefab.name, preview);
      
      Debug.Log($"IconGenerator: Icon generated for: {prefab.name} at {ICON_OUTPUT_DIR}/{prefab.name}.png");
   }

   private static void SaveIcon(string iconName, Texture2D icon)
   {
      byte[] png = icon.EncodeToPNG();
      string path = Path.Combine(ICON_OUTPUT_DIR, iconName + ".png");
      File.WriteAllBytes(path, png);
      
      EditorUtility.DisplayProgressBar("Generating Icon", "Converting type...", 0.8f);
      
      AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
      
      TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
      importer.textureType = TextureImporterType.Sprite;
      importer.spriteImportMode = SpriteImportMode.Single;
      importer.spritePixelsPerUnit = icon.width;
      importer.SaveAndReimport();
      
      EditorUtility.ClearProgressBar();
   }

 
}
