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
        //無人機資料相關Method
        #region 無人機管理

        #region 查詢無人機資料表的Method
        public static DataTable ReadDroneDetail()
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_Detail ORDER BY Sid ASC;";

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
            string queryString = $@" SELECT * FROM Drone_Detail  WHERE {WantSearch} LIKE @KeyWord ORDER BY {WantSearch} ASC;";

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


        #region 無人機單頁查詢
        public static DataTable ReadTenDataDroneDetail(int firstData, int lastData)
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM 
                                        (SELECT *,ROW_NUMBER() OVER (ORDER BY [Sid]) AS ROWSID FROM Drone_Detail)
                                     a WHERE ROWSID >= @ROWSID1 AND ROWSID <= @ROWSID2;";

            //string queryString = $@" SELECT * FROM Drone_Detail WHERE Sid >= @Sid and Sid <= @ID ORDER BY Sid ASC;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ROWSID1", firstData);
                command.Parameters.AddWithValue("@ROWSID2", lastData);
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




        //電池管理相關Method
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
        public static DataTable InsertIntoDroneBattery(string Battery_ID, string Stutas, string StopReason)
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"INSERT INTO Drone_Battery
                                        (Battery_ID, status, stopReason)
                                    VALUES
                                        (@Battery_ID, @status, @stopReason)";




            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@Battery_ID", Battery_ID);
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
        public static DataTable DeleteBattery(int Sid)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"DELETE FROM Drone_Battery WHERE Sid = @Sid";
            //DELETE FROM TestTable_1 WHERE ID



            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@Sid", Sid);



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
        public static DataTable UpDateBattery(int Sid,string Battery_ID, string Status, string StopReason)
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"UPDATE Drone_Battery SET Battery_ID=@Battery_ID, status=@status, stopReason=@stopReason WHERE Sid=@Sid";



            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                //command.Parameters.AddWithValue("@sid", Sid);
                command.Parameters.AddWithValue("@Sid", Sid);
                command.Parameters.AddWithValue("@Battery_ID", Battery_ID);
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
        public static DataTable ReadSingleBattery(string Sid)
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_Battery WHERE Sid=@Sid;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@Sid", Sid);

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

        #region 單頁10筆電池查詢

        public static DataTable ReadTenDataDroneBattery(int firstData, int lastData)
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM 
                                        (SELECT *,ROW_NUMBER() OVER (ORDER BY [Sid]) AS ROWSID FROM Drone_Battery)
                                     a WHERE ROWSID >= @ROWSID1 AND ROWSID <= @ROWSID2;";

            //string queryString = $@" SELECT * FROM Drone_Detail WHERE Sid >= @Sid and Sid <= @ID ORDER BY Sid ASC;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ROWSID1", firstData);
                command.Parameters.AddWithValue("@ROWSID2", lastData);
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

        #region 電池關鍵字模糊查詢

        public static DataTable KeyWordSearchDroneBattery(string WantSearch, string KeyWord)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_Battery  WHERE {WantSearch} LIKE @KeyWord ORDER BY {WantSearch} ASC;";

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




        //維修紀律相關Method
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
        public static DataTable InsertIntoDroneFix(string Drone_ID, string FixChange, string StopDate, string SendDate, string FixVendor, string StopReason,  string Remarks)
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

        #region 單頁讀取10筆維修紀錄

        public static DataTable ReadTenDataDroneFix(int firstData, int lastData)
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM 
                                        (SELECT *,ROW_NUMBER() OVER (ORDER BY [Sid]) AS ROWSID FROM Drone_Fix)
                                     a WHERE ROWSID >= @ROWSID1 AND ROWSID <= @ROWSID2;";

            //string queryString = $@" SELECT * FROM Drone_Detail WHERE Sid >= @Sid and Sid <= @ID ORDER BY Sid ASC;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ROWSID1", firstData);
                command.Parameters.AddWithValue("@ROWSID2", lastData);
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


        #region 維修紀錄關鍵字模糊查詢

        public static DataTable KeyWordSearchDroneFixed(string WantSearch, string KeyWord)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_Fix  WHERE {WantSearch} LIKE @KeyWord ORDER BY {WantSearch} ASC;";

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




        //使用者帳號相關Method
        #region 使用者帳號管理

        #region 讀取使用者一覽表
        public static DataTable ReadDroneUserList()
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_UserAccount WHERE Hidden = @Hidden;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Hidden", 0);

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

        #region 單頁讀取10筆維修紀錄

        public static DataTable ReadTenDataDroneUserList(int firstData, int lastData)
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM 
                                        (SELECT *,ROW_NUMBER() OVER (ORDER BY [Sid]) AS ROWSID FROM Drone_UserAccount)
                                     a WHERE ROWSID >= @ROWSID1 AND ROWSID <= @ROWSID2 AND Hidden = @Hidden;";

            //string queryString = $@" SELECT * FROM Drone_Detail WHERE Sid >= @Sid and Sid <= @ID ORDER BY Sid ASC;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ROWSID1", firstData);
                command.Parameters.AddWithValue("@ROWSID2", lastData);
                command.Parameters.AddWithValue("@Hidden", 0);
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

        #region 讀取單筆使用者帳號

        public static DataTable ReadSingleDroneUser(string sid)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_UserAccount WHERE Sid=@Sid;";

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

        #region 新增使用者帳號

        public static DataTable InsertIntoDroneUser(string account, string Pwd, string Name)
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"INSERT INTO Drone_UserAccount
                                        (Account, Pwd, Name, Hidden)
                                    VALUES
                                        (@Account, @Pwd, @Name, @Hidden)";




            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@account", account);
                command.Parameters.AddWithValue("@Pwd", Pwd);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Hidden", 0);


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

        #region 修改使用者帳號
        public static DataTable UpDateUserAccount(int Sid, string account, string Pwd, string name)
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"UPDATE Drone_UserAccount SET account=@account, Pwd=@Pwd, name=@name WHERE Sid=@Sid";



            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                //command.Parameters.AddWithValue("@sid", Sid);
                command.Parameters.AddWithValue("@Sid", Sid);
                command.Parameters.AddWithValue("@account", account);
                command.Parameters.AddWithValue("@Pwd", Pwd);
                command.Parameters.AddWithValue("@name", name);



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

        #region 刪除使用者資料的Method
        public static DataTable DeleteUser(int Sid)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"DELETE FROM Drone_UserAccount WHERE Sid = @Sid";
            //DELETE FROM TestTable_1 WHERE ID



            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@Sid", Sid);



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

        #region 使用者關鍵字模糊查詢

        public static DataTable KeyWordSearchDroneUser(string WantSearch, string KeyWord)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_UserAccount  WHERE Hidden = @Hidden AND {WantSearch} LIKE @KeyWord ORDER BY {WantSearch} ASC;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue($"@KeyWord", "%" + KeyWord + "%");
                command.Parameters.AddWithValue($"@Hidden", 0);

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




        //客戶資料管理相關Method
        #region 客戶資料管理

        #region 查詢客戶資料表

        public static DataTable ReadDroneCustomer()
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_Customer ORDER BY Sid ASC;";

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

        #region 10筆客戶資料讀取

        public static DataTable ReadTenDataDroneCustomer(int firstData, int lastData)
        {
            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM 
                                        (SELECT *,ROW_NUMBER() OVER (ORDER BY [Sid]) AS ROWSID FROM Drone_Customer)
                                     a WHERE ROWSID >= @ROWSID1 AND ROWSID <= @ROWSID2;";

            //string queryString = $@" SELECT * FROM Drone_Detail WHERE Sid >= @Sid and Sid <= @ID ORDER BY Sid ASC;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ROWSID1", firstData);
                command.Parameters.AddWithValue("@ROWSID2", lastData);
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

        #region 新增客戶資料

        public static DataTable InsertIntoDroneCustomer(string Name, string Tel, string Address, string Crop, string Area, string Pesticide, string Pesticide_Date, string Farm_Address)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"INSERT INTO Drone_Customer
                                        (Name, Tel, Address, Crop, Area, Pesticide, Pesticide_Date, Farm_Address)
                                    VALUES
                                        (@Name, @Tel, @Address, @Crop, @Area, @Pesticide, @Pesticide_Date, @Farm_Address)";



            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Tel", Tel);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Crop", Crop);
                command.Parameters.AddWithValue("@Area", Area);
                command.Parameters.AddWithValue("@Pesticide", Pesticide);
                command.Parameters.AddWithValue("@Pesticide_Date", Pesticide_Date);
                command.Parameters.AddWithValue("@Farm_Address", Farm_Address);

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

        #region 修改客戶資料

        public static void UpDateDroneCustomer(string Sid, string Name, string Tel, string Address, string Crop, string Area, string Pesticide, string Pesticide_Date, string Farm_Address)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";


            //使用的SQL語法
            string queryString = $@"UPDATE Drone_Customer SET Name=@Name, Tel=@Tel, Address=@Address, Crop=@Crop, Area=@Area, Pesticide=@Pesticide, Pesticide_Date=@Pesticide_Date, Farm_Address=@Farm_Address WHERE Sid=@Sid";




            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                //command.Parameters.AddWithValue("@DroneDetail_ID", Sid);
                command.Parameters.AddWithValue("@Sid", Sid);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Tel", Tel);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Crop", Crop);
                command.Parameters.AddWithValue("@Area", Area);
                command.Parameters.AddWithValue("@Pesticide", Pesticide);
                command.Parameters.AddWithValue("@Pesticide_Date", Pesticide_Date);
                command.Parameters.AddWithValue("@Farm_Address", Farm_Address);


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

        #region 讀取單筆客戶資料
        public static DataTable ReadSingleCustomer(string sid)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_Customer WHERE sid=@sid;";

            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@sid", sid);

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

        #region 刪除客戶資料
        public static DataTable DelectCustomer(string sid)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@"DELETE FROM Drone_Customer WHERE sid = @sid";
            //DELETE FROM TestTable_1 WHERE ID




            //建立連線
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //轉譯成SQL看得懂的語法
                SqlCommand command = new SqlCommand(queryString, connection);

                //將值丟進相對應的位子
                command.Parameters.AddWithValue("@sid", sid);



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

        #region 客戶資料關鍵字模糊查詢
        public static DataTable KeyWordSearchDroneCustomer(string WantSearch, string KeyWord)
        {

            //建立連線資料庫的字串變數Catalog=Drone的Drone為資料庫名稱
            string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=Drone; Integrated Security=true";

            //使用的SQL語法
            string queryString = $@" SELECT * FROM Drone_Customer  WHERE {WantSearch} LIKE @KeyWord ORDER BY {WantSearch} ASC;";

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
    }
}