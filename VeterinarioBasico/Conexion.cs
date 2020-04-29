using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Authentication;

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

        //LOGIN CLIENTE.
        public Boolean loginCliente(String usuarioCliente, String passwordCliente)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM cliente WHERE usuarioCliente = @usuarioCliente", conexion);
                consulta.Parameters.AddWithValue("@usuarioCliente", usuarioCliente);

                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.Read())
                {
                    string passConHash = resultado.GetString("passwordCliente");
                    if (BCrypt.Net.BCrypt.Verify(passwordCliente, passConHash)) {
                        return true;
                    }
                    return false;
                }

                conexion.Close();
                return false;
            }

            catch (MySqlException e)
            {
                return false;
            }
        }

        //LOGIN TRABAJADOR.
        public Boolean loginTrabajador(String usuarioTrabajador, String passwordTrabajador)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM trabajador WHERE usuarioTrabajador = @usuarioTrabajador", conexion);
                consulta.Parameters.AddWithValue("@usuarioTrabajador", usuarioTrabajador);

                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.Read())
                {
                    string passConHash = resultado.GetString("passwordTrabajador");
                    if (BCrypt.Net.BCrypt.Verify(passwordTrabajador, passConHash))
                    {
                        return true;
                    }
                    return false;
                }

                conexion.Close();
                return false;
            }

            catch (MySqlException e)
            {
                return false;
            }
        }

        //REGISTRO NUEVO USUARIO (SÓLO PARA CLIENTES)
        public Boolean registraUsuario(String dniCliente, String nombreCliente, String apellido1Cliente, String apellido2Cliente,
                                        String direccionCliente, String telfCliente, String emailCliente, String usuarioCliente, 
                                        String passwordCliente)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("INSERT INTO cliente (dniCliente, nombreCliente, apellido1Cliente, " +
                    "apellido2Cliente, direccionCliente, telfCliente, emailCliente, usuarioCliente, passwordCliente) VALUES " +
                    "(@dniCliente, @nombreCliente, @apellido1Cliente, @apellido2Cliente, @direccionCliente, " +
                    "@telfCliente, @emailCliente, @usuarioCliente, @passwordCliente)", conexion);
                consulta.Parameters.AddWithValue("@dniCliente", dniCliente);
                consulta.Parameters.AddWithValue("@nombreCliente", nombreCliente);
                consulta.Parameters.AddWithValue("@apellido1Cliente", apellido1Cliente);
                consulta.Parameters.AddWithValue("@apellido2Cliente", apellido2Cliente);
                consulta.Parameters.AddWithValue("@direccionCliente", direccionCliente);
                consulta.Parameters.AddWithValue("@telfCliente", telfCliente);
                consulta.Parameters.AddWithValue("@emailCliente", emailCliente);
                consulta.Parameters.AddWithValue("@usuarioCliente", usuarioCliente);
                consulta.Parameters.AddWithValue("@passwordCliente", passwordCliente);

                consulta.ExecuteNonQuery();

                conexion.Close();
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }

        //Para el TABCONTROL "Mi perfil" del CLIENTE.
        public DataTable datosCliente(String usuario)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM cliente WHERE usuarioCliente = @usuarioCliente", conexion);
                consulta.Parameters.AddWithValue("@usuarioCliente", usuario);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable datos = new DataTable();
                datos.Load(resultado);
                conexion.Close();
                return datos;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        //Para el TABCONTROL "Mi mascota" del CLIENTE.
        public DataTable datosMascota(String usuario)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM `mascota` WHERE idMascota = " +
                    "(SELECT idMascota FROM cliente_mascota WHERE dniCliente = (SELECT dniCliente FROM cliente " +
                    "WHERE usuarioCliente = @usuarioCliente))", conexion);
                consulta.Parameters.AddWithValue("@usuarioCliente", usuario);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable datos = new DataTable();
                datos.Load(resultado);
                conexion.Close();
                return datos;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        //Para el TABCONTROL "Mi perfil" del TRABAJADOR.
        public DataTable datosTrabajador(String usuario)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM trabajador WHERE usuarioTrabajador " +
                    "= @usuarioTrabajador", conexion);
                consulta.Parameters.AddWithValue("@usuarioTrabajador", usuario);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable datos = new DataTable();
                datos.Load(resultado);
                conexion.Close();
                return datos;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }


        //Para el TABCONTROL "buscador" del TRABAJADOR
        public DataTable buscarMascota()
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT nombreMascota as Mascota, especieMascota as Especie, " +
                    "razaMascota as Raza, colorMascota as Color, fecNacMascota as 'Fecha de nacimiento' , " +
                    "imagenMascota as Imagen FROM mascota", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable datos = new DataTable();
                datos.Load(resultado);
                conexion.Close();
                return datos;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        //Para el TABCONTROL "Mis citas" del CLIENTE
        public DataTable citasCliente(String usuario)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT DATE_FORMAT(fechaConsulta, '%d-%m-%Y') " +
                    "as Fecha, TIME_FORMAT(horaConsulta, '%H:%i') as Hora, tipoConsulta as Servicio " +
                    "FROM `consulta` as c, mascota_consulta as mc WHERE c.idConsulta = mc.idConsulta " +
                    "AND mc.idMascota = (SELECT idMascota FROM `cliente_mascota` WHERE dniCliente = " +
                    "(SELECT dniCliente FROM cliente WHERE usuarioCliente = @usuarioCliente))", conexion);
                consulta.Parameters.AddWithValue("@usuarioCliente", usuario);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable datos = new DataTable();
                datos.Load(resultado);
                conexion.Close();
                return datos;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        //Para el TABCONTROL "Citas" del TRABAJADOR
        public DataTable citasTrabajador(String usuario)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT DATE_FORMAT(fechaConsulta, '%d-%m-%Y') as Fecha, " +
                    "TIME_FORMAT(horaConsulta, '%H:%i') as Hora FROM mascota_consulta as mc, consulta_trabajador as ct " +
                    "WHERE ct.dniTrabajador = (SELECT dniTrabajador FROM trabajador WHERE usuarioTrabajador = @usuarioTrabajador) " +
                    "AND mc.idConsulta = ct.idConsulta AND mc.fechaConsulta >= CURRENT_DATE ORDER BY mc.fechaConsulta", conexion);
                consulta.Parameters.AddWithValue("@usuarioTrabajador", usuario);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable datos = new DataTable();
                datos.Load(resultado);
                conexion.Close();
                return datos;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        //Registro nueva mascota
        //public Boolean registraMascota(String nombreMascota, String especieMascota, String razaMascota,
        //                String colorMascota, String fecNacMascota)
        //{
        //    try
        //    {
        //        conexion.Open();
        //        MySqlCommand consulta = new MySqlCommand("INSERT INTO mascota (nombreMascota," +
        //            "especieMascota, razaMascota, colorMascota, fecNacMascota) VALUES (@nombreMascota," +
        //            "@especieMascota, @razaMascota, @colorMascota, @fecNacMascota)", conexion);
        //        consulta.Parameters.AddWithValue("@nombreMascota", nombreMascota);
        //        consulta.Parameters.AddWithValue("@especieMascota", especieMascota);
        //        consulta.Parameters.AddWithValue("@razaMascota", razaMascota);
        //        consulta.Parameters.AddWithValue("@colorMascota", colorMascota);
        //        consulta.Parameters.AddWithValue("@fecNacMascota", fecNacMascota);

        //        consulta.ExecuteNonQuery();

        //        conexion.Close();
        //        return true;
        //    }
        //    catch (MySqlException e)
        //    {
        //        return false;
        //    }
        //}

    }

}
