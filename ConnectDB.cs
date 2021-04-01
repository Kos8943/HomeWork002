using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HomeWork002
{
    public class ConnectDB
    {
        #region 無人機管理

        #region 查詢無人機資料表的Method
        public static DataTable ReadDroneDetail()
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_Detail;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@NumberCol", "2");

                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();

                    //在記憶體中創新的空表
                    DataTable dt = new DataTable();

                    //把值塞進空表
                    dt.Load(reader);
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    Console.WriteLine(
                    //        "\t{0}\t{1}\t{2}",
                    //        dr["ID"],
                    //        dr["Birthday"],
                    //        dr["Name"]
                    //    );
                    //}

                    //關閉資料庫連線
                    reader.Close();

                    //回傳dt
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

                //finally
                //{
                //    connection.Close();
                //}
            }
        }
        #endregion


        #region 新增無人機資料的Method
        public static DataTable InsertIntoDroneDetail(string DroneName, string Manufacturer, string WeightLoad, string Status, string StopReason, string Operator)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"INSERT INTO Drone_Detail
                                        (Drone_ID, Manufacturer, WeightLoad, Status, StopReason, operator)
                                    VALUES
                                        (@Drone_ID, @Manufacturer, @WeightLoad, @Status, @StopReason, @operator)";



            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@Drone_ID", DroneName);
                command.Parameters.AddWithValue("@Manufacturer", Manufacturer);
                command.Parameters.AddWithValue("@WeightLoad", WeightLoad);
                command.Parameters.AddWithValue("@Status", Status);
                command.Parameters.AddWithValue("@StopReason", StopReason);
                command.Parameters.AddWithValue("@operator", Operator);


                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(reader);

                    //受影響的資料筆數(沒有使用)
                    //int totalChangRows = command.ExecuteNonQuery();
                    //Console.WriteLine("Total chang" + totalChangRows + " Rows.");

                    return dt;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }

            }
        }
        #endregion


        #region 刪除無人機資料的Method
        public static DataTable DelectDroneDetail(string ID)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"DELETE FROM Drone_Detail WHERE Drone_ID = @Drone_ID";
            //DELETE FROM TestTable_1 WHERE ID




            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@Drone_ID", ID);



                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(reader);

                    //受影響的資料筆數(沒有使用)
                    //int totalChangRows = command.ExecuteNonQuery();
                    //HttpContext.Current.Response.Write("Total chang" + totalChangRows + " Rows.");
                    //Console.WriteLine("Total chang" + totalChangRows + " Rows.");

                    return dt;
                }
                catch (Exception ex)
                {
                    //HttpContext.Current.Response.Write(ex);
                    //Console.WriteLine(ex);
                    return null;
                }

            }
        }
        #endregion


        #region 修改無人機資料表的Method
        public static void UpDateDroneDetail(string Drone_ID, string Manufacturer, string WeightLoad, string Status, string StopReason, string Operator)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";


            //使用的SQL語法
            string queryString = $@"UPDATE Drone_Detail SET Drone_ID=@Drone_ID, Manufacturer=@Manufacturer, WeightLoad=@WeightLoad, Status=@Status, StopReason=@StopReason, operator=@operator WHERE DroneDetail_ID=@DroneDetail_ID";




            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                //command.Parameters.AddWithValue("@DroneDetail_ID", Sid);
                command.Parameters.AddWithValue("@Drone_ID", Drone_ID);
                command.Parameters.AddWithValue("@Manufacturer", Manufacturer);
                command.Parameters.AddWithValue("@WeightLoad", WeightLoad);
                command.Parameters.AddWithValue("@Status", Status);
                command.Parameters.AddWithValue("@StopReason", StopReason);
                command.Parameters.AddWithValue("@operator", Operator);


                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    //SqlDataReader reader = 
                    command.ExecuteNonQuery();

                    //DataTable dt = new DataTable();

                    //dt.Load(reader);




                    //受影響的資料筆數(沒有使用)
                    //int totalChangRows = command.ExecuteNonQuery();
                    //Console.WriteLine("Total chang" + totalChangRows + " Rows.");


                    //return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                    //return null;
                }

            }
        }
        #endregion


        #region 查詢單筆無人機資料表的Method
        public static DataTable ReadSingleDroneDetail(string ID)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_Detail WHERE Drone_ID=@Drone_ID;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Drone_ID", ID);

                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();

                    //在記憶體中創新的空表
                    DataTable dt = new DataTable();

                    //把值塞進空表
                    dt.Load(reader);

                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    Console.WriteLine(
                    //        "\t{0}\t{1}\t{2}",
                    //        dr["ID"],
                    //        dr["Birthday"],
                    //        dr["Name"]
                    //    );
                    //}

                    //關閉資料庫連線
                    reader.Close();

                    //回傳dt
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

                //finally
                //{
                //    connection.Close();
                //}
            }
        }
        #endregion


        #region 關鍵字模糊查詢
        public static DataTable KeyWordSearchDroneDetail(string WantSearch, string KeyWord)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_Detail WHERE {WantSearch} LIKE @KeyWord;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue($"@KeyWord", "%" + KeyWord + "%");

                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();

                    //在記憶體中創新的空表
                    DataTable dt = new DataTable();

                    //把值塞進空表
                    dt.Load(reader);

                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    Console.WriteLine(
                    //        "\t{0}\t{1}\t{2}",
                    //        dr["ID"],
                    //        dr["Birthday"],
                    //        dr["Name"]
                    //    );
                    //}

                    //關閉資料庫連線
                    reader.Close();

                    //回傳dt
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

                //finally
                //{
                //    connection.Close();
                //}
            }
        } 
        #endregion

        #endregion


        #region 電池管理

        #region 查詢電池資料表的Method
        public static DataTable ReadDroneBattery()
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_Battery;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@NumberCol", "2");

                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();

                    //在記憶體中創新的空表
                    DataTable dt = new DataTable();

                    //把值塞進空表
                    dt.Load(reader);

                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    Console.WriteLine(
                    //        "\t{0}\t{1}\t{2}",
                    //        dr["ID"],
                    //        dr["Birthday"],
                    //        dr["Name"]
                    //    );
                    //}


                    //關閉資料庫連線
                    reader.Close();

                    //回傳dt
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

                //finally
                //{
                //    connection.Close();
                //}
            }
        }
        #endregion


        #region 新增電池資料的Method
        public static DataTable InsertIntoDroneBattery(string BatteryName, string Stutas, string StopReason)
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"INSERT INTO Drone_Battery
                                        (battery_Name, status, stopReason)
                                    VALUES
                                        (@battery_Name, @status, @stopReason)";




            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@battery_Name", BatteryName);
                command.Parameters.AddWithValue("@status", Stutas);
                command.Parameters.AddWithValue("@stopReason", StopReason);



                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();

                    //在記憶體中創新的空表
                    DataTable dt = new DataTable();

                    //把值塞進空表
                    dt.Load(reader);

                    //受影響的資料筆數(沒有使用)
                    //int totalChangRows = command.ExecuteNonQuery();
                    //Console.WriteLine("Total chang" + totalChangRows + " Rows.");

                    return dt;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    //HttpContext.Current.Response.Write(ex);

                    return null;
                }

            }
        }
        #endregion


        #region 刪除電池資料的Method
        public static DataTable DeleteBattery(string Battery_ID)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"DELETE FROM Drone_Battery WHERE Battery_ID = @Battery_ID";
            //DELETE FROM TestTable_1 WHERE ID



            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@Battery_ID", Battery_ID);



                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();

                    //在記憶體中創新的空表
                    DataTable dt = new DataTable();

                    //把值塞進空表
                    dt.Load(reader);

                    //受影響的資料筆數(沒有使用)
                    int totalChangRows = command.ExecuteNonQuery();
                    //HttpContext.Current.Response.Write("Total chang" + totalChangRows + " Rows.");
                    //Console.WriteLine("Total chang" + totalChangRows + " Rows.");

                    return dt;


                }
                catch (Exception ex)
                {
                    //HttpContext.Current.Response.Write(ex);
                    //Console.WriteLine(ex);

                    return null;
                }

            }
        }
        #endregion


        #region 修改電池資料表的Method
        public static DataTable UpDateBattery(string BatteryName, string Status, string StopReason)
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"UPDATE Drone_Battery SET Battery_ID=@Battery_ID, status=@status, stopReason=@stopReason WHERE Battery_ID=@Battery_ID";



            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                //command.Parameters.AddWithValue("@sid", Sid);
                command.Parameters.AddWithValue("@battery_Name", BatteryName);
                command.Parameters.AddWithValue("@status", Status);
                command.Parameters.AddWithValue("@stopReason", StopReason);



                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();

                    //在記憶體中創新的空表
                    DataTable dt = new DataTable();

                    //把值塞進空表
                    dt.Load(reader);

                    //受影響的資料筆數(沒有使用)
                    //int totalChangRows = command.ExecuteNonQuery();
                    //Console.WriteLine("Total chang" + totalChangRows + " Rows.");

                    return dt;

                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex);
                    //HttpContext.Current.Response.Write(ex);

                    return null;
                }

            }
        }
        #endregion


        #region 查詢單筆電池資料表的Method
        public static DataTable ReadSingleBattery(string Battery_ID)
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_Battery WHERE Battery_ID=@Battery_ID;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@Battery_ID", Battery_ID);

                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();

                    //在記憶體中創新的空表
                    DataTable dt = new DataTable();

                    //把值塞進空表
                    dt.Load(reader);
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    Console.WriteLine(
                    //        "\t{0}\t{1}\t{2}",
                    //        dr["ID"],
                    //        dr["Birthday"],
                    //        dr["Name"]
                    //    );
                    //}

                    //關閉資料庫連線
                    reader.Close();

                    //回傳dt
                    return dt;
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    return null;
                }

                //finally
                //{
                //    connection.Close();
                //}
            }
        }
        #endregion
        #endregion


        #region 維修紀錄管理

        #region 查詢維修紀錄

        public static DataTable ReadDroneFixed()
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_Fix;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@NumberCol", "2");

                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();

                    //在記憶體中創新的空表
                    DataTable dt = new DataTable();

                    //把值塞進空表
                    dt.Load(reader);
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    Console.WriteLine(
                    //        "\t{0}\t{1}\t{2}",
                    //        dr["ID"],
                    //        dr["Birthday"],
                    //        dr["Name"]
                    //    );
                    //}

                    //關閉資料庫連線
                    reader.Close();

                    //回傳dt
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

                //finally
                //{
                //    connection.Close();
                //}
            }
        }
        #endregion


        #region 建立維修紀錄
        public static DataTable InsertIntoDroneFix(string Drone_ID, string StopDate, string SendDate, string FixVendor, string StopReason, string FixChange, string Remarks)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"INSERT INTO Drone_Fix
                                        (Drone_ID, FixChange, StopDate, SendDate, FixVendor, StopReason ,Remarks)
                                    VALUES
                                        (@Drone_ID, @FixChange, @StopDate, @SendDate, @FixVendor, @StopReason, @Remarks)";



            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@Drone_ID", Drone_ID);
                command.Parameters.AddWithValue("@StopDate", StopDate);
                command.Parameters.AddWithValue("@SendDate", SendDate);
                command.Parameters.AddWithValue("@FixVendor", FixVendor);
                command.Parameters.AddWithValue("@StopReason", StopReason);
                command.Parameters.AddWithValue("@FixChange", FixChange);
                command.Parameters.AddWithValue("@Remarks", Remarks);

                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(reader);

                    //受影響的資料筆數(沒有使用)
                    //int totalChangRows = command.ExecuteNonQuery();
                    //Console.WriteLine("Total chang" + totalChangRows + " Rows.");

                    return dt;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }

            }
        }
        #endregion


        #region 查詢單筆維修紀錄
        public static DataTable ReadSingleDroneFix(string sid)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_Fix WHERE Sid=@Sid;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Sid", sid);

                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();

                    //在記憶體中創新的空表
                    DataTable dt = new DataTable();

                    //把值塞進空表
                    dt.Load(reader);

                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    Console.WriteLine(
                    //        "\t{0}\t{1}\t{2}",
                    //        dr["ID"],
                    //        dr["Birthday"],
                    //        dr["Name"]
                    //    );
                    //}

                    //關閉資料庫連線
                    reader.Close();

                    //回傳dt
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

                //finally
                //{
                //    connection.Close();
                //}
            }
        }
        #endregion


        #region 修改維修紀錄
        public static void UpDateDroneFix(string Sid, string Drone_ID, string FixChange, string StopDate, string SendDate, string FixVendor, string StopReason,  string Remarks)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";


            //使用的SQL語法
            string queryString = $@"UPDATE Drone_Fix SET Drone_ID=@Drone_ID, FixChange=@FixChange, StopDate=@StopDate, SendDate=@SendDate, FixVendor=@FixVendor, StopReason=@StopReason,  Remarks=@Remarks WHERE Sid=@Sid";




            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@Sid", Sid);
                command.Parameters.AddWithValue("@ItemName", Drone_ID);
                command.Parameters.AddWithValue("@StopDate", StopDate);
                command.Parameters.AddWithValue("@SendDate", SendDate);
                command.Parameters.AddWithValue("@FixVendor", FixVendor);
                command.Parameters.AddWithValue("@StopReason", StopReason);
                command.Parameters.AddWithValue("@FixChange", FixChange);
                command.Parameters.AddWithValue("@Remarks", Remarks);


                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    //SqlDataReader reader = 
                    command.ExecuteNonQuery();

                    //DataTable dt = new DataTable();

                    //dt.Load(reader);




                    //受影響的資料筆數(沒有使用)
                    //int totalChangRows = command.ExecuteNonQuery();
                    //Console.WriteLine("Total chang" + totalChangRows + " Rows.");


                    //return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                    //return null;
                }

            }
        }
        #endregion


        #region 刪除維修紀錄

        public static DataTable DelectDroneFix(string sid)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"DELETE FROM Drone_Fix WHERE Sid = @Sid";
            //DELETE FROM TestTable_1 WHERE ID




            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@Sid", sid);



                try
                {
                    //開始連線
                    connection.Open();

                    //從資料庫中讀取資料
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(reader);

                    //受影響的資料筆數(沒有使用)
                    //int totalChangRows = command.ExecuteNonQuery();
                    //HttpContext.Current.Response.Write("Total chang" + totalChangRows + " Rows.");
                    //Console.WriteLine("Total chang" + totalChangRows + " Rows.");

                    return dt;
                }
                catch (Exception ex)
                {
                    //HttpContext.Current.Response.Write(ex);
                    //Console.WriteLine(ex);
                    return null;
                }

            }
        }
        #endregion 
        #endregion 
    }
}