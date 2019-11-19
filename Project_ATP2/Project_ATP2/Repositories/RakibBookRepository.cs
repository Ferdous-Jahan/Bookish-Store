using Project_ATP2.Interfaces;
using Project_ATP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_ATP2.Repositories
{
    public class RakibBookRepository : Repository<Book>
    {
        public RakibBookRepository(ProjectDBEntities Context) : base(Context)
        {
        }
        //Guys please copy paste the EContext property in all your created repositories
        public ProjectDBEntities EContext
        {
            get { return Context as ProjectDBEntities; }
        }






    }
}