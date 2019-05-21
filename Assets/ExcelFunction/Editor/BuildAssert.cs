using UnityEngine;
using UnityEditor;

/// <summary>
/// 利用ScriptableObject创建资源文件
/// </summary>
public class BuildAsset : Editor {

    [MenuItem("BuildAsset/Build Scriptable Asset")]
    public static void ExcuteBuild()
    {
        BookHolder holder = ScriptableObject.CreateInstance<BookHolder>();

        //查询excel表中数据，赋值给asset文件
        holder.menus = ExcelAccess.SelectMenuTable();

        string path= "Assets/Resources/booknames.asset";

        AssetDatabase.CreateAsset(holder, path);
        AssetDatabase.Refresh();

        Debug.Log("BuildAsset Success!");
    }

    [MenuItem("BuildAsset/Export Excel")]
    public static void ExportExcel()
    {
        string excelName = "william_test.xlsx";
        string sheetName = "randomTest";
        string path = Application.dataPath + "/" + excelName;
        ExcelAccess.WriteExcel(excelName, sheetName, path);
        
        AssetDatabase.Refresh();

        Debug.Log("ExportExcel Success!");
    }
}
