/***********************************************************************
 * Module:  GenericFileRepository<TExtendsEntity>.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.GenericFileRepository<TExtendsEntity>
 ***********************************************************************/

using Class_diagram.Model.Patient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace Class_diagram.Repository
{
    public class GenericFileRepository<T> where T :Entity
    {
        private String Path;

        public GenericFileRepository() { }

        public GenericFileRepository(String filePath)
        {
            this.Path = filePath;
        }
        public List<T> GetAll()
        {
            List<T> items = null;
            try
            {
                using (var reader = new StreamReader(this.Path))
                {
                    string json = reader.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<T>>(json);
              
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }

        public void New(T newEntity)
        {
            newEntity.ID = generateID(newEntity);
            List<T> list = GetAll();
            list.Add(newEntity);
            try
            {
                String JsonResult = JsonConvert.SerializeObject(list, Formatting.Indented);
                String path = Path;
                using (var writer = new StreamWriter(path))
                {
                    writer.Write(JsonResult);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Greska pri otvaranju fajla");
            }
        }

        public T GetByID(int id)
        {
            List<T> items = GetAll();
            foreach(T oneItem in items)
            {
                if (oneItem.ID==id)
                {
                    return oneItem;
                }
            }

         return null;
      }


        
        public void NewWithList(List<T> data)
        {
            try
            {
                String JsonResult = JsonConvert.SerializeObject(data, Formatting.Indented);
                String path = Path;

                using (var writer = new StreamWriter(path))
                {
                    writer.Write(JsonResult);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Greska pri otvaranju fajla");
            }

        }
        public void Update(T updateEntity)
        {
            List<T> items = GetAll();
            foreach (T it in items)
            {
                if (it.ID == updateEntity.ID)
                {
                    items.Remove(it);
                    items.Add(updateEntity);
                   NewWithList(items);
                    break;
                }
            }
        }

        public void Delete(int id)
        {
            List<T> items = GetAll();
            foreach (T it in items)
            {
                if (it.ID == id)
                {
                    items.Remove(it);
                    NewWithList(items);
                    break;
                }
            }
        }

        public int generateID(T entity)
        {    int number = 0;
            List<T> items = GetAll();
            foreach (T oneItem in items)
            {
                if (oneItem.ID > number)
                {
                    number = oneItem.ID;
                }
            }
            number += 1;
            return number;
        }

    }
}