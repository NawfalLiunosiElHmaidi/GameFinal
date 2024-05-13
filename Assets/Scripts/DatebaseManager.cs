/* using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

public class DatabaseManager : MonoBehaviour
{
    #region VARIABLES
    [Header("Database Properties")]
    public string Host = "localhost";
    public string User = "root";
    public string Password = "";
    public string Database = "Unity";
    #endregion
    #region UNITY METHODS
    private void Start()
    {
        Connect();
    }
    #endregion
    #region METHODS
    private void Connect()
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        builder.Server = Host;
        builder.UserID = User;
        builder.Password = Password;
        builder.Database = Database;
        try
        {
            using (MySqlConnection connection = new
            MySqlConnection(builder.ToString()))
            {
                connection.Open();
                print("MySQL - Opened Connection");
            }
        }
        catch (MySqlException exception)
        {
            print(exception.Message);
        }

    }
    #endregion
}
*/