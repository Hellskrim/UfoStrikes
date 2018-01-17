using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine.UI;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

public class SqlWriter : MonoBehaviour {
    public Text ScoreText;

    void Start()
    {        
        string conn = "URI=file:" + Application.dataPath + "/Plugins/BazaDanych.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlInsert = "INSERT INTO Wyniki (imie, punkty) " + "VALUES('" + NameKeeper.KeepDaText() + "'" + ", '" + ScoreText.text + "');";        
        dbcmd.CommandText = sqlInsert;
        dbcmd.ExecuteNonQuery();
        Debug.Log(sqlInsert + ": inserted!");

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
