using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine.UI;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

public class Sq : MonoBehaviour {
    public Text ScoreText;

    void Start () {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/BazaDanych.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT id, imie, punkty" + " FROM Wyniki " + "ORDER BY punkty DESC;";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(1);
            int value = reader.GetInt32(2);
            ScoreText.text += name + "\t\t" + value + "\n";
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
