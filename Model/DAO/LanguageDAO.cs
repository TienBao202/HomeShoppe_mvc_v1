using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using Model.CustomModel;

namespace Model.DAO
{
    public class LanguageDAO
    {
        HomeShoppeDBContext db = null;
        public LanguageDAO()
        {
            db = new HomeShoppeDBContext();
        }
        public List<Language> List(string searchString)
        {
            var query = from a in db.Languages
                        select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.ID.Contains(searchString));
            }
            return query.ToList();
        }
        public Language GetByID(string ID)
        {
            return db.Languages.SingleOrDefault(x => x.ID == ID);
        }
    }
}
