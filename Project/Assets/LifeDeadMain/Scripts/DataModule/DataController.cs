//********************************************************
//
// 斌哥的代码
//
// CreateTime ：#CreateTime#
//********************************************************


using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;


public class DataController : MonoBehaviour
{
    

    void Start ()
    {
        CreatJson();
	}
	
	
	void Update ()
    {
	
	}


    void CreatJson()
    {
        JsonData Data = new JsonData();
        Data["CharacterUnlock"] = 1;
        Data["LevelCurrent"] = 1;
        Data["LevelStars"] = new JsonData();

        JsonData LevelStar1 = new JsonData();
        LevelStar1["count"] = 0;


        Data["LevelStars"].Add(LevelStar1);
       

        print(Data.ToJson());
    }

}
