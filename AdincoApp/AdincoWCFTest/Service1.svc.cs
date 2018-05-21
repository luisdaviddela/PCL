using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AdincoWCFTest
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        //public string validaUsuario(string usuario, string password)
        //{
        //    return "Usuario válido";
        //}
        
            //CADENA DE CONEXIÓN CON VARIABLE LOCAL PARA HACER USO DE UNA SOLA C.S
        SqlConnection con = new SqlConnection("Data Source = sqldev.adinco.mx; " +
                                                                "Initial Catalog=Adinco;" +

                                                                "User id=Desarrollo; Password=SqlDev2017;");
        

        //OBTENER NOMBRE DE UN USUARIO 
        public List<string> GetNamePrueba()
        {
            List<string> PruebaData = new List<string>();
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from prueba;", con);
              //cmd.Parameters.AddWithValue("@Name", CutomerName);
       
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        
                       string n = dt.Rows[i]["name"].ToString();

                        PruebaData.Add(n);
                    }
                }
                con.Close();
            }
            return PruebaData;
        }

        //METODO PARA INSERTAR
        public string InsertUserData()

        {
            string Message;

            
            con.Open();
            //SqlCommand cmd = new SqlCommand("Select *  from AP_usuario;", con);

            SqlCommand cmd = new SqlCommand("Insert into Prueba (name) values ('Luis');", con);
            int result = cmd.ExecuteNonQuery();

            if (result == 1)

            {

                Message =  " Details inserted successfully";

            }

            else

            {
                Message = " Details not inserted successfully";
            }

            con.Close();

            return Message;

        }
        //LOGIN, VALIDACIÓN DE USUARIO Y CONTRASEÑA
        public string ValidateLogin(string user, string pass)
        {
            string mensaje = "";
            List<string> UserPassword = new List<string>();
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from AP_Usuario where Usuario =@Name And Contraseña=@pass", con);
                cmd.Parameters.AddWithValue("@Name", user);
                cmd.Parameters.AddWithValue("@pass", pass);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                
                if (dt.Rows.Count > 0)
                {
                    mensaje = "Usuario encontrado";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        string name = dt.Rows[i]["Usuario"].ToString();
                        string password = dt.Rows[i]["Contraseña"].ToString();
                        string id = dt.Rows[i]["UsuarioID"].ToString();

                        UserPassword.Add(name);
                        UserPassword.Add(password);
                        UserPassword.Add(id);
                    }
                }
                else
                {
                    mensaje = "No hubo coincidencias";
                }
                con.Close();
            }
            return mensaje;
        }
        //-----------------Login principal
        public bool ValidateLoginBool(string user, string pass)
        {
            
            bool login = false;
            List<string> UserPassword = new List<string>();
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from AP_Usuario where Usuario =@Name And Contraseña=@pass", con);
                cmd.Parameters.AddWithValue("@Name", user);
                cmd.Parameters.AddWithValue("@pass", pass);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                   
                    login = true;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        string name = dt.Rows[i]["Usuario"].ToString();
                        string password = dt.Rows[i]["Contraseña"].ToString();

                        UserPassword.Add(name);
                        UserPassword.Add(password);
                    }
                }
                else
                {
                  
                    login = false;
                }
                con.Close();
            }
            return login;
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        //--------------Select 
    }
}
