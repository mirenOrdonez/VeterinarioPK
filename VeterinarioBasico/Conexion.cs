using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VeterinarioBasico
{
    class Conexion
    {
        public MySqlConnection conexion;

        public Conexion()
        {
            try
            {
                conexion = new MySqlConnection("Server = 127.0.0.1; DataBase = veterinario; Uid = root; Pwd =; Port = 3306");
            }
            catch (MySqlException e)
            {
                throw e;
            }

        }

        public Boolean loginCliente(String dni, String password)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM cliente WHERE dni = @dni AND password = @password", conexion);
                consulta.Parameters.AddWithValue("@dni", dni);
                consulta.Parameters.AddWithValue("@password", password);

                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.Read())
                {
                    return true;
                }

                conexion.Close();
                return false;
            }

            catch (MySqlException e)
            {
                return false;
            }
        }

        public Boolean registraUsuario(String dni, String nombreCliente, String apellido1, String apellido2,
                                        String direccion, String telefono, String email, String usuario, String password)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("INSERT INTO cliente (dni, nombreCliente, apellido1, " +
                    "apellido2, direccion, telefono, email, usuario, password) VALUES (@dni, @nombreCliente, @apellido1," +
                    "@apellido2, @direccion, @telefono, @email, @usuario, @password)", conexion);
                consulta.Parameters.AddWithValue("@dni", dni);
                consulta.Parameters.AddWithValue("@nombreCliente", nombreCliente);
                consulta.Parameters.AddWithValue("@apellido1", apellido1);
                consulta.Parameters.AddWithValue("@apellido2", apellido2);
                consulta.Parameters.AddWithValue("@direccion", direccion);
                consulta.Parameters.AddWithValue("@telefono", telefono);
                consulta.Parameters.AddWithValue("@email", email);
                consulta.Parameters.AddWithValue("@usuario", usuario);
                consulta.Parameters.AddWithValue("@password", password);

                consulta.ExecuteNonQuery();

                conexion.Close();
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }
    }
}
