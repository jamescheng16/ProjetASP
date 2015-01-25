using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iBuy.Models
{
    /// <summary>
    /// pesonnalise dropdown list for display and select addresse and categorie
    /// </summary>
    public class MyDropDownList
    {
        private ApplicationDbContext _db = null;

        public MyDropDownList()
        {
            _db= new ApplicationDbContext();


        }
        [Required]
        public virtual string icityid { get; set; }

        [Required]
        public virtual string icategoryid { get; set; }

        public SelectList getCity()
        {
            IEnumerable<SelectListItem> cityList = (from m in _db.Addresses  select m).AsEnumerable().Select(m => new SelectListItem() { Text = m.City, Value = m.Id.ToString() });
            return new SelectList(cityList, "Value", "Text", icityid);
        }

        public SelectList getCategory()
        {
            IEnumerable<SelectListItem> categorieList = (from m in _db.Categories select m).AsEnumerable().Select(m => new SelectListItem() { Text = m.Name, Value = m.Id.ToString() });
            return new SelectList(categorieList, "Value", "Text", icategoryid);
        }
    }
}