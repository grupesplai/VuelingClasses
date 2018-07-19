using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVC.FileManager
{
    public class Usings
    {
        public static void GetJson(List<MvcAlumnoModel> lista)
            {

                string path = @"C:\Users\G1\source\repos\alumnos.json";
            List<MvcAlumnoModel> listaAlumno = FileExists(lista);
            string alumJson = JsonConvert.SerializeObject(listaAlumno, Formatting.Indented);
                //List<Alumno> listaAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(File.ReadAllText(path));

                using (StreamWriter sw = File.CreateText(path))
                    sw.WriteLine(alumJson);
    
        }
        public static List<MvcAlumnoModel> FileExists(List<MvcAlumnoModel> alumnos)
        {
            StreamReader sr = null;
            try
            {
                if (File.Exists(path))
                {
                    using (sr = new StreamReader(path))
                    {
                        string read = sr.ReadToEnd();
                        alumnos = JsonConvert.DeserializeObject<List<MvcAlumnoModel>>(read);
                    }
                }
            }
            catch (Exception e) { throw e; }
            return alumnos;
        }
    }
}