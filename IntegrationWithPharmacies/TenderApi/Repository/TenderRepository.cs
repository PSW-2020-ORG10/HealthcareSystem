﻿using System.Collections.Generic;
using System.Linq;
using TenderApi.DbContextModel;
using TenderApi.Model;

namespace TenderApi.Repository
{
    public class TenderRepository
    {
        private MyDbContext DbContext;
        public TenderRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public Tender Create(Tender tender)
        {
            DbContext.Tender.Add(tender);
            DbContext.SaveChanges();
            return tender;
        }

        public List<Tender> GetAll()
        {
            return DbContext.Tender.ToList();
        }

        public void CloseTender(Tender tenderForChange)
        {
            tenderForChange.Closed = true;
            DbContext.SaveChanges();
        }
    }
}
