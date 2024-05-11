﻿using Servicios.Models;
using Servicios_PD.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Clases
{
    public class clsUsuario
    {
        private DBSuperEntities dbSuper = new DBSuperEntities();
        public Usuario usuario { get; set; }

        public string Insertar(int idPerfil)
        {
            try
            {
                //Instanciamos la clase de cifrado
                clsCypher Cifrado = new clsCypher();
                //Pasamos la contraseña del usuario
                Cifrado.Password = usuario.Clave;
                //Ciframos la clave
                if (Cifrado.CifrarClave())
                {
                    //Si el cifrado es exitoso pasamos la contraseña cifrada al usuario nuevamente
                    usuario.Clave = Cifrado.PasswordCifrado;
                    usuario.Salt = Cifrado.Salt;
                    //Para grabar se utiliza el metodo Add
                    dbSuper.Usuarios.Add(usuario);
                    //Para garantizar la grabacion en la base de datos, se invoca el metodo SaveChanges
                    dbSuper.SaveChanges();

                    Usuario_Perfil usuario_Perfil = new Usuario_Perfil();
                    usuario_Perfil.idPerfil = idPerfil;
                    usuario_Perfil.Activo = true;
                    usuario_Perfil.idUsuario = usuario.id;
                    dbSuper.Usuario_Perfil.Add(usuario_Perfil);
                    dbSuper.SaveChanges();

                    return "Se ingresó el usuario: " + usuario.userName;
                }
                else { return "No se pudo generar la clave del usuario"; }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable ListarUsuariosEmpleados()
        {
            return from E in dbSuper.Set<EMPLeado>()
                   join EC in dbSuper.Set<EMpleadoCArgo>()
                   on E.Documento equals EC.Documento
                   join C in dbSuper.Set<CARGo>()
                   on EC.CodigoCargo equals C.Codigo
                   join U in dbSuper.Set<Usuario>()
                   on E.Documento equals U.Documento_Empleado
                   join UP in dbSuper.Set<Usuario_Perfil>()
                   on U.id equals UP.idUsuario
                   join P in dbSuper.Set<Perfil>()
                   on UP.idPerfil equals P.id
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEdit\" class=\"btn-block btn-sm btn-danger\" " +
                                 "onclick=\"Editar('" + E.Documento + "', '" + E.Nombre + " " + E.PrimerApellido + " " +
                                 E.SegundoApellido + "', '" + C.Nombre + "', '" + U.userName + "', " + UP.idPerfil + ")\">EDIT</button>",
                       Documento = E.Documento,
                       Empleado = E.Nombre + " " + E.PrimerApellido + " " + E.SegundoApellido,
                       Cargo = C.Nombre,
                       Usuario = U.userName,
                       Perfil = P.Nombre
                   };
        }
    }
}