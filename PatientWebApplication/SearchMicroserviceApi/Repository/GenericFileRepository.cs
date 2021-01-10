/***********************************************************************
 * Module:  GenericFileRepository<TExtendsEntity>.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.GenericFileRepository<TExtendsEntity>
 ***********************************************************************/

using Newtonsoft.Json;
using SearchMicroserviceApi.Model;
using System;
using System.Collections.Generic;
using System.IO;


namespace SearchMicroserviceApi.Repository
{
    public class GenericFileRepository<T> where T : Entity
    {
        private string Path;

        public GenericFileRepository() { }

        public GenericFileRepository(string filePath)
        {
            Path = filePath;
        }
        public List<T> GetAll()
        {
            List<T> items = null;
            try
            {
                using (var reader = new StreamReader(Path))
                {
                    items = JsonConvert.DeserializeObject<List<T>>(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }

        public void New(T newEntity)
        {
            newEntity.Id = generateid(newEntity);
            List<T> list = GetAll();
            list.Add(newEntity);
            try
            {
                using (var writer = new StreamWriter(Path))
                {
                    writer.Write(JsonConvert.SerializeObject(list, Formatting.Indented));
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Greska pri otvaranju fajla");
            }
        }

        public T GetByid(int id)
        {
            foreach (T oneItem in GetAll())
            {
                if (oneItem.Id == id)
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
                using (var writer = new StreamWriter(Path))
                {
                    writer.Write(JsonConvert.SerializeObject(data, Formatting.Indented));
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
                if (it.Id == updateEntity.Id)
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
                if (it.Id == id)
                {
                    items.Remove(it);
                    NewWithList(items);
                    break;
                }
            }
        }

        public int generateid(T entity)
        {
            int number = 0;
            List<T> items = GetAll();
            foreach (T oneItem in items)
            {
                if (oneItem.Id > number)
                {
                    number = oneItem.Id;
                }
            }
            number += 1;
            return number;
        }

    }
}