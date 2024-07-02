using JPillajoT5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avillarroelS5.Utils
{
    public class PersonRepository
    {
        string dbPath;
        private SQLiteConnection conn;

        public string StatusMessage { get; set; }

        private void init()
        {
            if (conn is not null) 
                return;
            conn = new(dbPath);
            conn.CreateTable<Person>();
        }

        public PersonRepository(string path) 
        { 
            dbPath = path; 
        }

        public void AddNewPerson(string nombre)
        {
            int result = 0;
            try
            {
                init();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("El nombre es requerido");

                Person person = new() { Nombre = nombre };
                result = conn.Insert(person);
                StatusMessage = string.Format("Dato añadido correctamente", result, nombre);

            }
            catch (Exception EX)
            {
                StatusMessage = string.Format("Error al insertar",nombre, EX.Message);
            }
        }

        public List<Person> GetAllPeople()
        {
            try
            {
                init();
                return conn.Table<Person>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al mostrar", ex.Message);
            }
            return new List<Person>();
        }

        public void UpdatePerson(Person person)
        {
            try
            {
                if (person == null || person.Id == 0)
                    throw new Exception("Se requiere persona valida");

                var result = conn.Update(person);
                StatusMessage = string.Format("Dato actualizado correctamente", result, person.Nombre);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al actualizar", ex.Message);
            }
        }

        public void DeletePerson(int id)
        {
            try
            {
                var result = conn.Delete<Person>(id);
                StatusMessage = string.Format("Dato eliminado correctamente", result, id);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al eliminar", ex.Message);
            }
        }
    }
}
