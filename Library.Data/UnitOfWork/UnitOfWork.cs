﻿using Library.Data.Repository;
using System;
using System.Data.Entity;

namespace Library.Data.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private LibraryDBEntities db;
        private DbContextTransaction transaction;

        public UnitOfWork()
        {
            db = new LibraryDBEntities();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool Commit()
        {
            transaction = db.Database.BeginTransaction();
            int affected = db.SaveChanges();
            transaction.Commit();
            return affected > 0;
        }

        public void RollBack()
        {
            transaction.Rollback();
        }

        public Repository<Book> Books { get { return new Repository<Book>(db); } }
        public Repository<Borrow> Borrows { get { return new Repository<Borrow>(db); } }
        public Repository<Genre> Genres { get { return new Repository<Genre>(db); } }
        public Repository<RecordStatus> RecordStatuses { get { return new Repository<RecordStatus>(db); } }
        public Repository<Student> Students { get { return new Repository<Student>(db); } }
        public Repository<User> Users { get { return new Repository<User>(db); } }
    }
}
