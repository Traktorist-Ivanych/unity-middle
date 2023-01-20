using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityGoogleDrive;
using UnityGoogleDrive.Data;

public static class GoogleDriveTools
{
    public const string UGDFileName = "GameData.json";

    public static List<File> GetFileList()
    {
        List<File> outputFiles = new List<File>();
        GoogleDriveFiles.List().Send().OnDone += fileList => { outputFiles = fileList.Files; };
        return outputFiles;
    }

    public static File Upload(string obj)
    {
        File file = new UnityGoogleDrive.Data.File 
        { 
            Name = UGDFileName, Content = Encoding.ASCII.GetBytes(obj) 
        };

        GoogleDriveFiles.Create(file).Send();
        return file;
    }

    public static File Download(string fileId)
    {
        File output = new File();
        GoogleDriveFiles.Download(fileId).Send().OnDone += file => { output = file; };
        return output;
    }
}
