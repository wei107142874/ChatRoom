using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ZDSoft.CR.Manager
{
    /// <summary>
    /// 数据库访问类
    /// </summary>
    public class SqlHelper
    {
        #region 属性或字段
        //数据库访问字符串
        private static string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CRConnection"].ConnectionString;
        /// <summary>
        /// 数据库访问字符串
        /// </summary>
        public static string ConnectionString
        {
            get {
                return connString;
            }
        }
        #endregion

        /// <summary>
        /// 数据库的链接对象
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            //链接数据库
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            return conn; 
        }

        public static int Count(CommandType cmdType, string commandText)
        {
            //链接数据库
            using (SqlConnection conn = GetConnection())
            {
                //初始化crud执行对象
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;//指定数据库的链接对象
                cmd.CommandType = cmdType;
                //组织SQL语句
                cmd.CommandText = commandText;

                cmd.ExecuteScalar();

                int roCwount =Convert.ToInt32(cmd.ExecuteScalar());
                return roCwount;
            }
        }

        #region 执行数据的增加、修改和删除
        /// <summary>
        /// 执行数据的增加、修改和删除
        /// </summary>
        /// <param name="cmdType">数据库执行的命令类型:sql语句，存储 过程</param>
        /// <param name="commandText">sql语句或存储过程</param>
        /// <param name="parames">参数，可以为空</param>
        /// <returns>返回影响数据的行数：-1表示未执行，0表示执行失败，1表示执行成功</returns>
        public static int ExecuteNonQuery(CommandType cmdType, string commandText, params SqlParameter[] parames)
        {
            //链接数据库
            using (SqlConnection conn = GetConnection())
            {
                //初始化crud执行对象
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;//指定数据库的链接对象
                cmd.CommandType = cmdType;
                //组织SQL语句
                cmd.CommandText = commandText;
                if (parames != null)
                {
                    cmd.Parameters.AddRange(parames);
                }

                //执行数据库的增加，修改和删除操作命令，并返回影响数据的行数
                int roCwount = cmd.ExecuteNonQuery();//执行修改操作
                return roCwount;
            }
        }

        /// <summary>
        /// 执行数据的增加、修改和删除(使用数据库事务)
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdType">数据库执行的命令类型:sql语句，存储 过程</param>
        /// <param name="commandText">查询的SQL语句或存储过程</param>
        /// <param name="parames">参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string commandText, params SqlParameter[] parames)
        {
            //初始化crud执行对象
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = trans.Connection;
            cmd.Transaction = trans;//指定事物对象
            cmd.CommandType = cmdType;
            //组织SQL语句
            cmd.CommandText = commandText;
            if (parames != null)
            {
                cmd.Parameters.AddRange(parames);
            }

            //执行数据库的增加，修改和删除操作命令，并返回影响数据的行数
            int roCwount = cmd.ExecuteNonQuery();//执行修改操作
            return roCwount;
        }
        #endregion

        #region 查询并返回单个值
        /// <summary>
        /// 查询并返回单个值
        /// </summary>
        /// <param name="cmdType">数据库执行的命令类型:sql语句，存储 过程</param>
        /// <param name="commandText">查询的SQL语句或存储过程</param>
        /// <param name="parames">参数</param>
        /// <returns>查询并返回单个值</returns>
        public static object ExecuteScalar(CommandType cmdType,string commandText,params SqlParameter[] parames)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                //指定属性
                cmd.Connection = conn;
                cmd.CommandType = cmdType;
                cmd.CommandText = commandText;
                //指定参数
                if (parames != null)
                {
                    cmd.Parameters.AddRange(parames);
                }
                //执行查询炒作
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// 查询并返回单个值(使用数据库事务)
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdType">数据库执行的命令类型:sql语句，存储 过程</param>
        /// <param name="commandText">查询的SQL语句或存储过程</param>
        /// <param name="parames">参数</param>
        /// <returns>查询并返回单个值</returns>
        public static object ExecuteScalar(SqlTransaction trans, CommandType cmdType, string commandText, params SqlParameter[] parames)
        {
            SqlCommand cmd = new SqlCommand();
            //指定属性
            cmd.Connection = trans.Connection;
            cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            cmd.CommandText = commandText;
            //指定参数
            if (parames != null)
            {
                cmd.Parameters.AddRange(parames);
            }
            //执行查询炒作
            return cmd.ExecuteScalar();
        }
        #endregion

        #region 查询并返回集合(2个方法)
        /// <summary>
        /// 查询数据集合，返回DataSet对象的查询
        /// </summary>
        /// <param name="cmdType">数据库执行的命令类型:sql语句，存储 过程</param>
        /// <param name="commandText">查询的SQL语句或存储过程</param>
        /// <param name="parames">参数</param>
        /// <returns></returns>
        public static DataSet Fill(CommandType cmdType, string commandText, params SqlParameter[] parames)
        {
            using (SqlConnection conn = GetConnection())
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                //指定属性
                cmd.Connection = conn;
                cmd.CommandType = cmdType;
                cmd.CommandText = commandText;
                //指定参数
                if (parames != null)
                {
                    cmd.Parameters.AddRange(parames);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                return ds;
            }
        }

        /// <summary>
        /// 查询数据集合，返回DataSet对象的查询(使用数据库事务)
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdType">数据库执行的命令类型:sql语句，存储 过程</param>
        /// <param name="commandText">查询的SQL语句或存储过程</param>
        /// <param name="parames">参数</param>
        /// <returns>查询数据集合，返回DataSet对象的查询</returns>
        public static DataSet Fill(SqlTransaction trans, CommandType cmdType, string commandText, params SqlParameter[] parames)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            //指定属性
            cmd.Connection = trans.Connection;
            cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            cmd.CommandText = commandText;
            //指定参数
            if (parames != null)
            {
                cmd.Parameters.AddRange(parames);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);

            return ds;
        }

        /// <summary>
        /// 查询数据集合，返回SqlDataReader对象
        /// </summary>
        /// <param name="cmdType">数据库执行的命令类型:sql语句，存储 过程</param>
        /// <param name="commandText">查询的SQL语句或存储过程</param>
        /// <param name="parames">参数</param>
        /// <returns>查询数据集合，返回SqlDataReader对象</returns>
        public static SqlDataReader GetDataReader(CommandType cmdType, string commandText, params SqlParameter[] parames)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand();
            //指定属性
            cmd.Connection = conn;
            cmd.CommandType = cmdType;
            cmd.CommandText = commandText;
            //指定参数
            if (parames != null)
            {
                cmd.Parameters.AddRange(parames);
            }
            //执行查询炒作
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 查询数据集合，返回SqlDataReader对象(使用数据库事务)
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdType">数据库执行的命令类型:sql语句，存储 过程</param>
        /// <param name="commandText">查询的SQL语句或存储过程</param>
        /// <param name="parames">参数</param>
        /// <returns>查询数据集合，返回SqlDataReader对象</returns>
        public static SqlDataReader GetDataReader(SqlTransaction trans, CommandType cmdType, string commandText, params SqlParameter[] parames)
        {
            SqlCommand cmd = new SqlCommand();
            //指定属性
            cmd.Connection = trans.Connection;
            cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            cmd.CommandText = commandText;
            //指定参数
            if (parames != null)
            {
                cmd.Parameters.AddRange(parames);
            }
            //执行查询炒作
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

    }
}