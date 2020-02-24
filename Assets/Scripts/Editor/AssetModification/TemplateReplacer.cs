using UnityEditor;
using System.IO;

public class TemplateReplacer : UnityEditor.AssetModificationProcessor
{
    public static void OnWillCreateAsset(string metaFilePath)
    {
        string fileName = Path.GetFileNameWithoutExtension(metaFilePath);

        if (!fileName.EndsWith(".cs"))
            return;


        string actualFilePath = $"{Path.GetDirectoryName(metaFilePath)}\\{fileName}";

        string content = File.ReadAllText(actualFilePath);
        string newcontent = content.Replace("#PROJECTNAME#", PlayerSettings.productName);

        string date = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        newcontent = newcontent.Replace("#DATE#", date);

        if (content != newcontent)
        {
            File.WriteAllText(actualFilePath, newcontent);
            AssetDatabase.Refresh();
        }
    }
}
